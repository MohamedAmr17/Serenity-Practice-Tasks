import { getLookup, getLookupAsync, fieldsProxy } from "@serenity-is/corelib";

export interface SpecialityRow {
    SpecialityId?: number;
    DoctorId?: number;
    SpecialityName?: string;
    DoctorName?: string;
}

export abstract class SpecialityRow {
    static readonly idProperty = 'SpecialityId';
    static readonly nameProperty = 'SpecialityName';
    static readonly localTextPrefix = 'hospital.Speciality';
    static readonly lookupKey = 'hospital.Speciality';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<SpecialityRow>('hospital.Speciality') }
    static async getLookupAsync() { return getLookupAsync<SpecialityRow>('hospital.Speciality') }

    static readonly deletePermission = '?';
    static readonly insertPermission = '?';
    static readonly readPermission = '?';
    static readonly updatePermission = '?';

    static readonly Fields = fieldsProxy<SpecialityRow>();
}