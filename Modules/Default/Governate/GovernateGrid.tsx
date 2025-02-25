import { Decorators, EntityGrid } from '@serenity-is/corelib';
import { GovernateColumns, GovernateRow, GovernateService } from '../../ServerTypes/Default';
import { GovernateDialog } from './GovernateDialog';

@Decorators.registerClass('Serene2.Default.GovernateGrid')
export class GovernateGrid extends EntityGrid<GovernateRow> {
    protected getColumnsKey() { return GovernateColumns.columnsKey; }
    protected getDialogType() { return GovernateDialog; }
    protected getRowDefinition() { return GovernateRow; }
    protected getService() { return GovernateService.baseUrl; }
}