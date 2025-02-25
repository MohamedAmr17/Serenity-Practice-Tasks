import { StringEditor, PrefixedContext, initFormType } from "@serenity-is/corelib";

export interface GovernateForm {
    GovernateName: StringEditor;
}

export class GovernateForm extends PrefixedContext {
    static readonly formKey = 'Default.Governate';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!GovernateForm.init)  {
            GovernateForm.init = true;

            var w0 = StringEditor;

            initFormType(GovernateForm, [
                'GovernateName', w0
            ]);
        }
    }
}