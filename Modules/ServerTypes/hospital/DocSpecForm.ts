import { IntegerEditor, PrefixedContext, initFormType } from "@serenity-is/corelib";

export interface DocSpecForm {
    SpecialityId: IntegerEditor;
    DoctorId: IntegerEditor;
}

export class DocSpecForm extends PrefixedContext {
    static readonly formKey = 'hospital.DocSpec';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!DocSpecForm.init)  {
            DocSpecForm.init = true;

            var w0 = IntegerEditor;

            initFormType(DocSpecForm, [
                'SpecialityId', w0,
                'DoctorId', w0
            ]);
        }
    }
}