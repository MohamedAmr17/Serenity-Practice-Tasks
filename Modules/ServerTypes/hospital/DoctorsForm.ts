import { StringEditor, LookupEditor, EnumEditor, PrefixedContext, initFormType } from "@serenity-is/corelib";
import { TypeEnum } from "../Modules/hospital.Patients.Enum.TypeEnum";

export interface DoctorsForm {
    DoctorName: StringEditor;
    SpecialityList: LookupEditor;
    Type: EnumEditor;
}

export class DoctorsForm extends PrefixedContext {
    static readonly formKey = 'hospital.Doctors';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!DoctorsForm.init)  {
            DoctorsForm.init = true;

            var w0 = StringEditor;
            var w1 = LookupEditor;
            var w2 = EnumEditor;

            initFormType(DoctorsForm, [
                'DoctorName', w0,
                'SpecialityList', w1,
                'Type', w2
            ]);
        }
    }
}

[TypeEnum]; // referenced types