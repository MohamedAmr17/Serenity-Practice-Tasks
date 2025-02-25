import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { DocSpecialityListFormatter } from "../../hospital/Doctors/DocSpecialityListFormatter";
import { DoctorsRow } from "./DoctorsRow";

export interface DoctorsColumns {
    DoctorId: Column<DoctorsRow>;
    DoctorName: Column<DoctorsRow>;
    SpecialityList: Column<DoctorsRow>;
}

export class DoctorsColumns extends ColumnsBase<DoctorsRow> {
    static readonly columnsKey = 'hospital.Doctors';
    static readonly Fields = fieldsProxy<DoctorsColumns>();
}

[DocSpecialityListFormatter]; // referenced types