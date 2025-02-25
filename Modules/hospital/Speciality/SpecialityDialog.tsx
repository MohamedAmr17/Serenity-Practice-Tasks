import { Decorators, EntityDialog } from '@serenity-is/corelib';
import { SpecialityForm, SpecialityRow, SpecialityService } from '../../ServerTypes/hospital';

@Decorators.registerClass('Serene2.hospital.SpecialityDialog')
export class SpecialityDialog extends EntityDialog<SpecialityRow, any> {
    protected getFormKey() { return SpecialityForm.formKey; }
    protected getRowDefinition() { return SpecialityRow; }
    protected getService() { return SpecialityService.baseUrl; }

    protected form = new SpecialityForm(this.idPrefix);
}