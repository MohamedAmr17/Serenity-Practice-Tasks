import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { DocSpecRow } from "./DocSpecRow";

export interface DocSpecColumns {
    DocSpecId: Column<DocSpecRow>;
    SpecialityId: Column<DocSpecRow>;
    DoctorId: Column<DocSpecRow>;
}

export class DocSpecColumns extends ColumnsBase<DocSpecRow> {
    static readonly columnsKey = 'hospital.DocSpec';
    static readonly Fields = fieldsProxy<DocSpecColumns>();
}