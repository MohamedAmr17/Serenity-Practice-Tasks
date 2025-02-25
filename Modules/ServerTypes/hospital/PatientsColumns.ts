import { ColumnsBase, fieldsProxy } from "@serenity-is/corelib";
import { Column } from "@serenity-is/sleekgrid";
import { GenderEnum } from "../Modules/hospital.Patients.Enum.GenderEnum";
import { PatientsRow } from "./PatientsRow";

export interface PatientsColumns {
    PatientId: Column<PatientsRow>;
    PatientName: Column<PatientsRow>;
    Age: Column<PatientsRow>;
    Cost: Column<PatientsRow>;
    TotalDiscount: Column<PatientsRow>;
    DateOfBirth: Column<PatientsRow>;
    Gender: Column<PatientsRow>;
    Address: Column<PatientsRow>;
    GovName: Column<PatientsRow>;
    CityName: Column<PatientsRow>;
    DoctorName: Column<PatientsRow>;
}

export class PatientsColumns extends ColumnsBase<PatientsRow> {
    static readonly columnsKey = 'hospital.Patients';
    static readonly Fields = fieldsProxy<PatientsColumns>();
}

[GenderEnum]; // referenced types