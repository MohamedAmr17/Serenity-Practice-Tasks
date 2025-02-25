import { Decorators, EntityGrid } from '@serenity-is/corelib';
import { PatientsColumns, PatientsRow, PatientsService } from '../../ServerTypes/hospital';
import { PatientsDialog } from './PatientsDialog';
import * as Q from "@serenity-is/corelib";
import "./Patientscolours.css";
import jQuery from "jquery";
import type { JQuery } from 'jquery';

@Decorators.registerClass('Serene2.hospital.PatientsGrid')
export class PatientsGrid extends EntityGrid<PatientsRow, any> {
    protected getColumnsKey() { return PatientsColumns.columnsKey; }
    protected getDialogType() { return PatientsDialog; }
    protected getRowDefinition() { return PatientsRow; }
    protected getService() { return PatientsService.baseUrl; }

    constructor(container: JQuery) {
        super(container);
    }

    protected createToolbarExtensions() {
        super.createToolbarExtensions();

        let tabs = jQuery('<div class=""/>').appendTo(this.toolbar.element);
        let tabsUl = jQuery('<ul class="nav "/>').appendTo(tabs);

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
                jQuery(e.target).parent().addClass('active ');
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
        var klass: string = "";
        if (item.Gender == 1)
            klass += "male-row";
        else {
            klass += "female-row";
        }
        return Q.trimToNull(klass);
    }

    protected getQuickSearchFields():Q.QuickSearchField[] {
        return [
            { name: "", title: "all" },
            { name: "PatientName", title: "name" },
            { name: "Age", title: "age" }
        ];
    }
}

 