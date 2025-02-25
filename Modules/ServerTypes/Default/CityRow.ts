import { getLookup, getLookupAsync, fieldsProxy } from "@serenity-is/corelib";

export interface CityRow {
    CityId?: number;
    CityName?: string;
    GovernateId?: number;
    GovernateName?: string;
}

export abstract class CityRow {
    static readonly idProperty = 'CityId';
    static readonly nameProperty = 'CityName';
    static readonly localTextPrefix = 'Default.City';
    static readonly lookupKey = 'Default.City';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<CityRow>('Default.City') }
    static async getLookupAsync() { return getLookupAsync<CityRow>('Default.City') }

    static readonly deletePermission = '"Administration:General"';
    static readonly insertPermission = '"Administration:General"';
    static readonly readPermission = '"Administration:General"';
    static readonly updatePermission = '"Administration:General"';

    static readonly Fields = fieldsProxy<CityRow>();
}