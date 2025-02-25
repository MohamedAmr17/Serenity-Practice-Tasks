import { getLookup, getLookupAsync, fieldsProxy } from "@serenity-is/corelib";

export interface DocSpecRow {
    DocSpecId?: number;
    SpecialityId?: number;
    DoctorId?: number;
}

export abstract class DocSpecRow {
    static readonly idProperty = 'DocSpecId';
    static readonly localTextPrefix = 'hospital.DocSpec';
    static readonly lookupKey = 'hospital.DocSpec';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<DocSpecRow>('hospital.DocSpec') }
    static async getLookupAsync() { return getLookupAsync<DocSpecRow>('hospital.DocSpec') }

    static readonly deletePermission = '?';
    static readonly insertPermission = '?';
    static readonly readPermission = '?';
    static readonly updatePermission = '?';

    static readonly Fields = fieldsProxy<DocSpecRow>();
}