import { Decorators, EntityDialog } from '@serenity-is/corelib';
import { hospitalPermissionKeys, PatientsForm, PatientsRow, PatientsService } from '../../ServerTypes/hospital';
import { SiteValidationTexts } from "../../ServerTypes/Texts";
import * as Q from '@serenity-is/corelib';
import jQuery from "jquery";


@Decorators.registerClass('Serene2.hospital.PatientsDialog')
export class PatientsDialog extends EntityDialog<PatientsRow, any> {
    [x: string]: any;
    protected getFormKey() { return PatientsForm.formKey; }
    protected getRowDefinition() { return PatientsRow; }
    protected getService() { return PatientsService.baseUrl; }

    protected form = new PatientsForm(this.idPrefix);
    private originalFullName: string;
    private originalDateOfBirth: string;

    constructor() {
        super();

        this.form.LoyaltyYears.change(e => this.calculateTotalDiscount());
        this.form.LoyaltyYears.changeSelect2(e => this.calculateTotalDiscount());
        this.form.Cost.change(e => this.calculateTotalDiscount());
        this.form.Cost.changeSelect2(e => this.calculateTotalDiscount());
        this.form.Gender.changeSelect2(e => this.checkGenderValidation());

        // If your form has PatientName and DateOfBirth fields, add change handlers
        if (this.form.PatientName) {
            this.form.PatientName.change(e => this.checkForDuplicatePatient());
        }
        if (this.form.DateOfBirth) {
            this.form.DateOfBirth.change(e => this.checkForDuplicatePatient());
        }
    }

    protected afterLoadEntity() {
        super.afterLoadEntity();

        this.form.DoctorId.filterField = "Type"
        this.form.DoctorId.filterValue = 1

        this.form.TotalDiscount.value = this.form.Cost.value * this.form.TotalDiscount.value * 0.05;

        if (this.isNew()) {
            this.toolbar.findButton('multiply-button').hide();
        }

        // Store original values for duplicate checking
        if (this.form.PatientName) {
            this.originalFullName = this.form.PatientName.value;
        }
        if (this.form.DateOfBirth) {
            this.originalDateOfBirth = this.form.DateOfBirth.value;
        }

        this.checkGenderValidation();
    }

    private calculateTotalDiscount() {
        let loyaltyYears = this.form.LoyaltyYears.value || 0;
        let cost = this.form.Cost.value || 0;
        this.form.TotalDiscount.value = loyaltyYears * cost * 0.05;
        this.form.TotalDiscount.element.trigger("change");
    }

    private updateTaskValueInDatabase(newValue: number) {
        PatientsService.Update({
            EntityId: this.entityId,
            Entity: {
                TaskValue: newValue
            }
        }, response => {
            if (response.Error) {
                Q.notifyError(response.Error.Message || "An error occurred while updating the Task");
                return;
            }
            Q.notifySuccess("Task updated successfully");
            this.reloadById();
        });
    }

    // Add method to check for duplicate patients
    private checkForDuplicatePatient() {
        {
            // Skip check if this is an existing record and values haven't changed
            if (!this.isNew() &&
                this.form.PatientName.value === this.originalPatientName &&
                this.form.DateOfBirth.value === this.originalDateOfBirth) {
                return;
            }

            // Call service to check for duplicates
            PatientsService.List({
                EqualityFilter: {
                    PatientName: this.form.PatientName.value,
                    DateOfBirth: this.form.DateOfBirth.value
                }
            }, response => {
                if (response.Entities && response.Entities.length > 0) {
                    // Check if the found entity is not the current one
                    const isDuplicate = this.isNew() ||
                        (response.Entities.some(e => e.PatientId !== this.entityId));

                    if (isDuplicate) {
                        Q.notifyError("A patient with the same name and date of birth already exists.");
                    }
                }
            });
        }
    }

    protected validateBeforeSave() {
        if (!super.validateBeforeSave()) {
            return false;
        }
        if (this.form.Age.value < 1 || this.form.Age.value > 120) {
            Q.notifyError(SiteValidationTexts.AgeMessage);
            return false;
        }

        // We'll do a final duplicate check before saving
        if (this.form.PatientName && this.form.DateOfBirth) {
            const fullName = this.form.PatientName.value;
            const dateOfBirth = this.form.DateOfBirth.value;

            // If this is an update and neither field changed, we can skip the check
            if (!this.isNew() &&
                fullName === this.originalFullName &&
                dateOfBirth === this.originalDateOfBirth) {
                return true;
            }

            // Check for duplicates synchronously before saving
            let isDuplicate = false;

            // Use a synchronous AJAX call
            jQuery.ajax({
                async: false,
                url: PatientsService.baseUrl + '/List',
                type: 'POST',
                data: JSON.stringify({
                    Criteria: [
                        ['FullName', '=', fullName],
                        ['DateOfBirth', '=', dateOfBirth]
                    ]
                }),
                contentType: 'application/json',
                success: function (response) {
                    if (response.Entities && response.Entities.length > 0) {
                        // For existing records, make sure we're not just finding ourselves
                        isDuplicate = !this.entityId ||
                            response.Entities.some(e => e.Id !== this.entityId);
                    }
                }.bind(this)
            });

            if (isDuplicate) {
                Q.notifyError("A patient with the same name and date of birth already exists.");
                return false;
            }
        }

        return true;
    }

    protected getToolbarButtons() {
        let buttons = super.getToolbarButtons();
        buttons.push({
            title: "Multiply TaskValue by 2",
            icon: "fa-calculator",
            cssClass: 'multiply-button',
            onClick: () => {
                if (!this.entityId) {
                    Q.notifyError("No record selected!");
                    return;
                }

                let value = this.form.TaskValue.value;
                let newValue = value * 2;
                this.updateTaskValueInDatabase(newValue);
            }
        });

        if (Q.Authorization.hasPermission(hospitalPermissionKeys.Patients.Readonly)) {
            let readOnly = false;
            buttons.push({
                title: "Read-only Mode",
                icon: "fa-eye",
                cssClass: 'readonly-button',
                onClick: () => {
                    readOnly = !readOnly
                    this.setReadOnlyMode(readOnly);
                    this.updateButtonIcon(readOnly)
                }
            });
        }
        return buttons;
    }

    private setReadOnlyMode(value: boolean): void {
        Q.setElementReadOnly(this.element.findAll('.editor'), value);
        this.form.TotalDiscount.element.attr('readonly', true).addClass('readonly');
    }

    private checkGenderValidation() {
        if (this.form.Gender.value == "1") {
            this.form.Address.element.attr("required", true);
        } else {
            this.form.Address.element.removeAttr("required");
        }
    }

    protected updateButtonIcon(readOnly: boolean) {
        readOnly ? this.element.findFirst('.fa-eye').removeClass('fa-eye').addClass('fa-eye-slash') :
            this.element.findFirst('.fa-eye-slash').removeClass('fa-eye-slash').addClass('fa-eye')
    }
}