import { SaveRequest, SaveResponse, ServiceOptions, DeleteRequest, DeleteResponse, RetrieveRequest, RetrieveResponse, ListRequest, ListResponse, serviceRequest } from "@serenity-is/corelib";
import { GovernateRow } from "./GovernateRow";

export namespace GovernateService {
    export const baseUrl = 'Default/Governate';

    export declare function Create(request: SaveRequest<GovernateRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<GovernateRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<GovernateRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<GovernateRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<GovernateRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<GovernateRow>>;

    export const Methods = {
        Create: "Default/Governate/Create",
        Update: "Default/Governate/Update",
        Delete: "Default/Governate/Delete",
        Retrieve: "Default/Governate/Retrieve",
        List: "Default/Governate/List"
    } as const;

    [
        'Create', 
        'Update', 
        'Delete', 
        'Retrieve', 
        'List'
    ].forEach(x => {
        (<any>GovernateService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}