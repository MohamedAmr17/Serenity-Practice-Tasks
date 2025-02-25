import { getLookup, getLookupAsync, fieldsProxy } from "@serenity-is/corelib";

export interface GovernateRow {
    GovernateId?: number;
    GovernateName?: string;
}

export abstract class GovernateRow {
    static readonly idProperty = 'GovernateId';
    static readonly nameProperty = 'GovernateName';
    static readonly localTextPrefix = 'Default.Governate';
    static readonly lookupKey = 'Default.Governate';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<GovernateRow>('Default.Governate') }
    static async getLookupAsync() { return getLookupAsync<GovernateRow>('Default.Governate') }

    static readonly deletePermission = 'Administration:General';
    static readonly insertPermission = 'Administration:General';
    static readonly readPermission = 'Administration:General';
    static readonly updatePermission = 'Administration:General';

    static readonly Fields = fieldsProxy<GovernateRow>();
}