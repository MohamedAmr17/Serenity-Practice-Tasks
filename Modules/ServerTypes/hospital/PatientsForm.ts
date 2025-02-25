import { StringEditor, IntegerEditor, DateEditor, EnumEditor, LookupEditor, TextAreaEditor, PrefixedContext, initFormType } from "@serenity-is/corelib";
import { GenderEnum } from "../Modules/hospital.Patients.Enum.GenderEnum";

export interface PatientsForm {
    PatientName: StringEditor;
    Age: IntegerEditor;
    DateOfBirth: DateEditor;
    Gender: EnumEditor;
    GovernateId: LookupEditor;
    CityId: LookupEditor;
    Address: TextAreaEditor;
    DoctorId: LookupEditor;
    Cost: IntegerEditor;
    LoyaltyYears: IntegerEditor;
    TotalDiscount: IntegerEditor;
    TaskValue: IntegerEditor;
}

export class PatientsForm extends PrefixedContext {
    static readonly formKey = 'hospital.Patients';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!PatientsForm.init)  {
            PatientsForm.init = true;

            var w0 = StringEditor;
            var w1 = IntegerEditor;
            var w2 = DateEditor;
            var w3 = EnumEditor;
            var w4 = LookupEditor;
            var w5 = TextAreaEditor;

            initFormType(PatientsForm, [
                'PatientName', w0,
                'Age', w1,
                'DateOfBirth', w2,
                'Gender', w3,
                'GovernateId', w4,
                'CityId', w4,
                'Address', w5,
                'DoctorId', w4,
                'Cost', w1,
                'LoyaltyYears', w1,
                'TotalDiscount', w1,
                'TaskValue', w1
            ]);
        }
    }
}

[GenderEnum]; // referenced types