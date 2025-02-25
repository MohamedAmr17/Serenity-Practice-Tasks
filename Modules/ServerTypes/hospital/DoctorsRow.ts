import { getLookup, getLookupAsync, fieldsProxy } from "@serenity-is/corelib";
import { TypeEnum } from "../Modules/hospital.Patients.Enum.TypeEnum";

export interface DoctorsRow {
    DoctorId?: number;
    DoctorName?: string;
    Type?: TypeEnum;
    SpecialityList?: number[];
}

export abstract class DoctorsRow {
    static readonly idProperty = 'DoctorId';
    static readonly nameProperty = 'DoctorName';
    static readonly localTextPrefix = 'hospital.Doctors';
    static readonly lookupKey = 'hospital.Doctors';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<DoctorsRow>('hospital.Doctors') }
    static async getLookupAsync() { return getLookupAsync<DoctorsRow>('hospital.Doctors') }

    static readonly deletePermission = 'hospital:Doctors:Modify';
    static readonly insertPermission = 'hospital:Doctors:Modify';
    static readonly readPermission = 'hospital:Doctors:View';
    static readonly updatePermission = 'hospital:Doctors:Modify';

    static readonly Fields = fieldsProxy<DoctorsRow>();
}