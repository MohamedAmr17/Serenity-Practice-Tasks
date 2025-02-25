import { SaveRequest, SaveResponse, ServiceOptions, DeleteRequest, DeleteResponse, RetrieveRequest, RetrieveResponse, ListRequest, ListResponse, serviceRequest } from "@serenity-is/corelib";
import { DoctorsRow } from "./DoctorsRow";

export namespace DoctorsService {
    export const baseUrl = 'hospital/Doctors';

    export declare function Create(request: SaveRequest<DoctorsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Update(request: SaveRequest<DoctorsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): PromiseLike<SaveResponse>;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): PromiseLike<DeleteResponse>;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<DoctorsRow>) => void, opt?: ServiceOptions<any>): PromiseLike<RetrieveResponse<DoctorsRow>>;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<DoctorsRow>) => void, opt?: ServiceOptions<any>): PromiseLike<ListResponse<DoctorsRow>>;

    export const Methods = {
        Create: "hospital/Doctors/Create",
        Update: "hospital/Doctors/Update",
        Delete: "hospital/Doctors/Delete",
        Retrieve: "hospital/Doctors/Retrieve",
        List: "hospital/Doctors/List"
    } as const;

    [
        'Create', 
        'Update', 
        'Delete', 
        'Retrieve', 
        'List'
    ].forEach(x => {
        (<any>DoctorsService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}