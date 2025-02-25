import { Decorators, EntityGrid } from '@serenity-is/corelib';
import { SpecialityColumns, SpecialityRow, SpecialityService } from '../../ServerTypes/hospital';
import { SpecialityDialog } from './SpecialityDialog';

@Decorators.registerClass('Serene2.hospital.SpecialityGrid')
export class SpecialityGrid extends EntityGrid<SpecialityRow> {
    protected getColumnsKey() { return SpecialityColumns.columnsKey; }
    protected getDialogType() { return SpecialityDialog; }
    protected getRowDefinition() { return SpecialityRow; }
    protected getService() { return SpecialityService.baseUrl; }
}