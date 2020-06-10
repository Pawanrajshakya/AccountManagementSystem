export interface IParam {
    pageNumber: number;
    pageSize: number;
    sortBy?: string;
    sortDirection?: string; /*asc/desc*/
    searchBy?: string;
    searchText?: string;
}
