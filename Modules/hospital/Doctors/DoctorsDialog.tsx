import { Decorators, EntityDialog } from '@serenity-is/corelib';
import { DoctorsForm, DoctorsRow, DoctorsService } from '../../ServerTypes/hospital';

@Decorators.registerClass('Serene2.hospital.DoctorsDialog')
export class DoctorsDialog extends EntityDialog<DoctorsRow, any> {
    protected getFormKey() { return DoctorsForm.formKey; }
    protected getRowDefinition() { return DoctorsRow; }
    protected getService() { return DoctorsService.baseUrl; }

    protected form = new DoctorsForm(this.idPrefix);
    protected onDialogOpen() {
        super.onDialogOpen();
        console.log("📂 onDialogOpen executed (Before entity data is loaded)");
    }
    constructor() {
        super();
        console.log("✅ Constructor executed");
    }
    protected afterLoadEntity() {
        super.afterLoadEntity();
        console.log("📦 afterLoadEntity executed (Entity data is now available)");
    }
    protected updateInterface() {
        super.updateInterface();
        console.log("🎨 updateInterface executed (Update UI elements)");
    }

}