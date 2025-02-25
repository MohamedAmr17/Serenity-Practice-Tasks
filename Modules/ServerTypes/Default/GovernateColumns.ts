import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { GovernateRow } from "./GovernateRow";

export interface GovernateColumns {
    GovernateId: Column<GovernateRow>;
    GovernateName: Column<GovernateRow>;
}

export class GovernateColumns extends ColumnsBase<GovernateRow> {
    static readonly columnsKey = 'Default.Governate';
    static readonly Fields = fieldsProxy<GovernateColumns>();
}