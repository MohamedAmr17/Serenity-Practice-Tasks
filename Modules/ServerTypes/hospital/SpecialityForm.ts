import { StringEditor, LookupEditor, PrefixedContext, initFormType } from "@serenity-is/corelib";

export interface SpecialityForm {
    SpecialityName: StringEditor;
    DoctorId: LookupEditor;
}

export class SpecialityForm extends PrefixedContext {
    static readonly formKey = 'hospital.Speciality';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!SpecialityForm.init)  {
            SpecialityForm.init = true;

            var w0 = StringEditor;
            var w1 = LookupEditor;

            initFormType(SpecialityForm, [
                'SpecialityName', w0,
                'DoctorId', w1
            ]);
        }
    }
}