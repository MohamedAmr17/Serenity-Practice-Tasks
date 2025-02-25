import { Decorators, EntityGrid, QuickSearchField } from '@serenity-is/corelib';
import { MedicalRecordsColumns, MedicalRecordsRow, MedicalRecordsService } from '../../ServerTypes/hospital';
import { MedicalRecordsDialog } from './MedicalRecordsDialog';

@Decorators.registerClass('Serene2.hospital.MedicalRecordsGrid')
export class MedicalRecordsGrid extends EntityGrid<MedicalRecordsRow> {
    protected getColumnsKey() { return MedicalRecordsColumns.columnsKey; }
    protected getDialogType() { return MedicalRecordsDialog; }
    protected getRowDefinition() { return MedicalRecordsRow; }
    protected getService() { return MedicalRecordsService.baseUrl; }

    protected getQuickSearchFields(): QuickSearchField[] {
        return [
            { name: "", title: "all" },
            { name: "DoctorName", title: "doctor" },
            { name: "PatientName", title: "patient" }
        ];
    }
}