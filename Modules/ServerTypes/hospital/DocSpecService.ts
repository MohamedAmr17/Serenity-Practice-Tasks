import { SaveRequest, SaveResponse, ServiceOptions, DeleteRequest, DeleteResponse, RetrieveRequest, RetrieveResponse, ListRequest, ListResponse, serviceRequest } from "@serenity-is/corelib";
import { DocSpecRow } from "./DocSpecRow";

export namespace DocSpecService {
    export const baseUrl = 'hospital/DocSpec';

    export declare function Create(request: SaveRequest<DocSpecRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<DocSpecRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<DocSpecRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<DocSpecRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<DocSpecRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<DocSpecRow>>;

    export const Methods = {
        Create: "hospital/DocSpec/Create",
        Update: "hospital/DocSpec/Update",
        Delete: "hospital/DocSpec/Delete",
        Retrieve: "hospital/DocSpec/Retrieve",
        List: "hospital/DocSpec/List"
    } as const;

    [
        'Create', 
        'Update', 
        'Delete', 
        'Retrieve', 
        'List'
    ].forEach(x => {
        (<any>DocSpecService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}