import { Decorators, EntityGrid } from '@serenity-is/corelib';
import { DocSpecColumns, DocSpecRow, DocSpecService } from '../../ServerTypes/hospital';
import { DocSpecDialog } from './DocSpecDialog';

@Decorators.registerClass('Serene2.hospital.DocSpecGrid')
export class DocSpecGrid extends EntityGrid<DocSpecRow> {
    protected getColumnsKey() { return DocSpecColumns.columnsKey; }
    protected getDialogType() { return DocSpecDialog; }
    protected getRowDefinition() { return DocSpecRow; }
    protected getService() { return DocSpecService.baseUrl; }
}