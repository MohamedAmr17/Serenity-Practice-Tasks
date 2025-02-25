import { Decorators, EntityDialog } from '@serenity-is/corelib';
import { DocSpecForm, DocSpecRow, DocSpecService } from '../../ServerTypes/hospital';

@Decorators.registerClass('Serene2.hospital.DocSpecDialog')
export class DocSpecDialog extends EntityDialog<DocSpecRow, any> {
    protected getFormKey() { return DocSpecForm.formKey; }
    protected getRowDefinition() { return DocSpecRow; }
    protected getService() { return DocSpecService.baseUrl; }

    protected form = new DocSpecForm(this.idPrefix);
}