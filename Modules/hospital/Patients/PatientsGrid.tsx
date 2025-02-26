import { Decorators, EntityGrid } from '@serenity-is/corelib';
import { PatientsColumns, PatientsRow, PatientsService } from '../../ServerTypes/hospital';
import { PatientsDialog } from './PatientsDialog';
import * as Q from "@serenity-is/corelib";
import "./Patientscolours.css";
import jQuery from "jquery";

@Decorators.registerClass('Serene2.hospital.PatientsGrid')
export class PatientsGrid extends EntityGrid<PatientsRow, any> {
    protected getColumnsKey() { return PatientsColumns.columnsKey; }
    protected getDialogType() { return PatientsDialog; }
    protected getRowDefinition() { return PatientsRow; }
    protected getService() { return PatientsService.baseUrl; }

    private pendingChanges: Q.Dictionary<any> = {};

    constructor(container: JQuery) {
        super(container);
        jQuery('.s-DeviceStandardsEditor').height(700);
        this.slickContainer.on('change', '.edit:input', (e) => this.inputsChange(e));
    }

    protected createToolbarExtensions() {
        super.createToolbarExtensions();

        let tabs = jQuery('<div class="tab-container"/>').appendTo(this.toolbar.element);
        let tabsUl = jQuery('<ul class="nav nav-tabs"/>').appendTo(tabs);

        this.addTab(tabsUl, 'AllPatients', 'All Patients');
        this.addTab(tabsUl, 'MalePatients', 'Male Patients');
        this.addTab(tabsUl, 'FemalePatients', 'Female Patients');

        tabsUl.on('click', 'li a', (e) => {
            e.preventDefault();
            let tab = jQuery(e.target).attr('href')?.substring(1);
            if (tab) {
                this.handleTabChange(tab);
                // Update active state
                tabsUl.find('li').removeClass('active');
                jQuery(e.target).parent().addClass('active');
            }
        });

        // Set first tab as active
        tabsUl.find('li:first').addClass('active');
    }

    private addTab(tabsUl: JQuery, id: string, title: string) {
        jQuery('<li/>').append(
            jQuery('<a/>')
                .attr('href', '#' + id)
                .text(title)
        ).appendTo(tabsUl);
    }

    private handleTabChange(tab: string) {
        const request = this.view.params as Q.ListRequest;
        request.EqualityFilter = request.EqualityFilter || {};

        switch (tab) {
            case 'MalePatients':
                request.EqualityFilter['Gender'] = 1;
                break;
            case 'FemalePatients':
                request.EqualityFilter['Gender'] = 2;
                break;
            default:
                delete request.EqualityFilter['Gender'];
                break;
        }

        this.refresh();
    }

    protected getItemCssClass(item: PatientsRow, index: number): string {
        let klass: string = "";
        if (item.Gender == 1)
            klass += "male-row";
        else {
            klass += "female-row";
        }
        return Q.trimToNull(klass);
    }

    protected getQuickSearchFields(): Q.QuickSearchField[] {
        return [
            { name: "", title: "all" },
            { name: "PatientName", title: "name" },
            { name: "Age", title: "age" }
        ];
    }

    validateEntity(row: PatientsRow) {
        row.PatientId = Q.toId(row.PatientId);
        let samePatient = Q.tryFirst(this.view.getItems(), x => x.PatientId === row.PatientId);
        if (samePatient) {
            Q.alert('This patient is already in the patient list!');
            return false;
        }

        const lookup = PatientsRow.getLookup();
        if (lookup && lookup.itemById && lookup.itemById[row.PatientName]) {
            row.PatientName = lookup.itemById[row.PatientName].PatientName;
        }

        return true;
    }

    protected getButtons(): Q.ToolButton[] {
        let buttons = super.getButtons();
        buttons.push({
            title: Q.text('SaveChanges'),
            cssClass: 'apply-changes-button disabled',
            onClick: e => this.saveClick(),
            separator: true
        });
        return buttons;
    }

    protected getColumns() {
        let columns = super.getColumns();

        columns.unshift({
            field: Q.text('Site.Equipment.Buttons.RemoveFrequencyRange'),
            name: '',
            format: ctx => '<a class="inline-action delete-row" title="delete">' +
                '<i class="fa fa-times text-red"></i></a>',
            width: 24,
            minWidth: 24,
            maxWidth: 24
        });

        let standardPartInput = ctx => this.stringInputFormatter(ctx);

        try {
            const costColumn = Q.first(columns, x => x.field == PatientsRow.Fields.Cost);
            if (costColumn) {
                costColumn.format = standardPartInput;
            }
        } catch (error) {
            console.error("Error setting cost column formatter:", error);
        }

        return columns;
    }

    protected onClick(e: any, row: number, cell: number) {
        super.onClick(e, row, cell);

        let item = this.itemAt(row);
        if (!item) return;

        let target = jQuery(e.target);
        if (target.parent().hasClass('inline-action'))
            target = target.parent();

        if (target.hasClass('inline-action')) {
            e.preventDefault();

            if (target.hasClass('delete-row')) {
                Q.confirm("Are you sure you want to delete this record?", () => {
                    let items = this.getItems();
                    items.splice(row, 1);
                    this.setItems(items);
                });
            }
        }
    }

    private stringInputFormatter(ctx) {
        if (!ctx || !ctx.item) return '';

        let klass = 'edit string';
        let item = ctx.item as PatientsRow;
        let pending = this.pendingChanges[item.PatientId];

        if (pending && pending[ctx.column.field] !== undefined) {
            klass += ' dirty';
        }

        let value = this.getEffectiveValue(item, ctx.column.field) as string;
        if (value === undefined || value === null) value = '';

        return "<input type='text' style='width: 290px;' class='" + klass +
            "' data-field='" + ctx.column.field +
            "' value='" + Q.htmlEncode(value) +
            "' maxlength='" + (ctx.column.sourceItem?.maxLength || 255) + "'/>";
    }

    private getEffectiveValue(item, field): any {
        if (!item) return '';

        // Fix: Use PatientId instead of DeviceStandardId
        let change = this.pendingChanges[item.PatientId];

        if (change && change[field] !== undefined) {
            return change[field];
        }

        return item[field];
    }

    private inputsChange(e: any) {
        // Remove debugger statement
        try {
            let cell = this.slickGrid.getCellFromEvent(e);
            if (!cell) return;

            let item = this.itemAt(cell.row);
            if (!item) return;

            let input = jQuery(e.target);
            let field = input.data('field');
            let text = Q.trimToNull(input.val());
            let pending = this.pendingChanges[item.PatientId];

            let effective = this.getEffectiveValue(item, field);

            let value = text;
            if (!pending) {
                this.pendingChanges[item.PatientId] = pending = {};
            }

            pending[field] = value;
            item[field] = value;

            input.val(value).addClass('dirty');

            this.setSaveButtonState();
        } catch (error) {
            console.error("Error in inputsChange:", error);
        }
    }

    private setSaveButtonState() {
        try {
            this.toolbar.findButton('apply-changes-button').toggleClass('disabled',
                Object.keys(this.pendingChanges).length === 0);
        } catch (error) {
            console.error("Error in setSaveButtonState:", error);
        }
    }

    private saveClick() {
        if (Object.keys(this.pendingChanges).length === 0) {
            return;
        }

        let keys = Object.keys(this.pendingChanges);
        let current = -1;
        let self = this;

        (function saveNext() {
            if (++current >= keys.length) {
                self.refresh()
                self.setSaveButtonState();
                jQuery(".dirty").removeClass('dirty');
                Q.notifySuccess(Q.text("Controls.EntityDialog.SaveSuccessMessage"));
                return;
            }

            let key = keys[current];
            let entity = Q.deepClone(self.pendingChanges[key]);

            // Fix: Use PatientId instead of DeviceStandardId
            entity.PatientId = key;

            Q.serviceRequest(PatientsService.Methods.Update, {
                EntityId: key,
                Entity: entity
            }, (response) => {
                delete self.pendingChanges[key];
                saveNext();
            }, {
                onError: function (response) {
                    Q.notifyError("Failed to save changes: ");
                    console.error("Save error:", response);
                    // Continue to next item even after error
                    delete self.pendingChanges[key];
                    saveNext();
                }
            });
        })();
    }
}