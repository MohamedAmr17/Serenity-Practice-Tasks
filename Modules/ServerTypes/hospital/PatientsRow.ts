import { getLookup, getLookupAsync, fieldsProxy } from "@serenity-is/corelib";
import { GenderEnum } from "../Modules/hospital.Patients.Enum.GenderEnum";

export interface PatientsRow {
    PatientId?: number;
    DoctorId?: number;
    PatientName?: string;
    DoctorName?: string;
    GovName?: string;
    CityName?: string;
    GovernateId?: number;
    CityId?: number;
    DateOfBirth?: string;
    Gender?: GenderEnum;
    Address?: string;
    Age?: number;
    LoyaltyYears?: number;
    TaskValue?: number;
    Cost?: number;
    TotalDiscount?: number;
}

export abstract class PatientsRow {
    static readonly idProperty = 'PatientId';
    static readonly nameProperty = 'PatientName';
    static readonly localTextPrefix = 'hospital.Patients';
    static readonly lookupKey = 'hospital.Patients';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<PatientsRow>('hospital.Patients') }
    static async getLookupAsync() { return getLookupAsync<PatientsRow>('hospital.Patients') }

    static readonly deletePermission = 'hospital:Patients:Modify';
    static readonly insertPermission = 'hospital:Patients:Modify';
    static readonly readPermission = 'hospital:Patients:View';
    static readonly updatePermission = 'hospital:Patients:Modify';

    static readonly Fields = fieldsProxy<PatientsRow>();
}