import { StringEditor, LookupEditor, PrefixedContext, initFormType } from "@serenity-is/corelib";

export interface CityForm {
    CityName: StringEditor;
    GovernateId: LookupEditor;
}

export class CityForm extends PrefixedContext {
    static readonly formKey = 'Default.City';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!CityForm.init)  {
            CityForm.init = true;

            var w0 = StringEditor;
            var w1 = LookupEditor;

            initFormType(CityForm, [
                'CityName', w0,
                'GovernateId', w1
            ]);
        }
    }
}