import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { SpecialityRow } from "./SpecialityRow";

export interface SpecialityColumns {
    SpecialityId: Column<SpecialityRow>;
    SpecialityName: Column<SpecialityRow>;
    DoctorName: Column<SpecialityRow>;
}

export class SpecialityColumns extends ColumnsBase<SpecialityRow> {
    static readonly columnsKey = 'hospital.Speciality';
    static readonly Fields = fieldsProxy<SpecialityColumns>();
}