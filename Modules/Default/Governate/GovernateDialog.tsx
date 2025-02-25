import { Decorators, EntityDialog } from '@serenity-is/corelib';
import { GovernateForm, GovernateRow, GovernateService } from '../../ServerTypes/Default';

@Decorators.registerClass('Serene2.Default.GovernateDialog')
export class GovernateDialog extends EntityDialog<GovernateRow, any> {
    protected getFormKey() { return GovernateForm.formKey; }
    protected getRowDefinition() { return GovernateRow; }
    protected getService() { return GovernateService.baseUrl; }

    protected form = new GovernateForm(this.idPrefix);
}