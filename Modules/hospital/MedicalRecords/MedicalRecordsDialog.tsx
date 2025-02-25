import { Decorators, EntityDialog } from '@serenity-is/corelib';
import { MedicalRecordsForm, MedicalRecordsRow, MedicalRecordsService } from '../../ServerTypes/hospital';

@Decorators.registerClass('Serene2.hospital.MedicalRecordsDialog')
export class MedicalRecordsDialog extends EntityDialog<MedicalRecordsRow, any> {
    protected getFormKey() { return MedicalRecordsForm.formKey; }
    protected getRowDefinition() { return MedicalRecordsRow; }
    protected getService() { return MedicalRecordsService.baseUrl; }

    protected form = new MedicalRecordsForm(this.idPrefix);
}