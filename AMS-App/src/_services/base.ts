import { HttpParams } from '@angular/common/http';
import { IParam } from 'src/_models/param';

export class Base {

    getHttpParams(parameters: IParam): HttpParams {
        let httpParams = new HttpParams();

        if (parameters.pageNumber) {
            if (parameters.pageNumber === 0) {
                parameters.pageNumber = 1;
            }
            httpParams = httpParams.set('pageNumber', parameters.pageNumber.toString());
        }
        if (parameters.pageSize) {
            if (parameters.pageSize === 0) {
                parameters.pageSize = 50;
            }
            httpParams = httpParams.set('pageSize', parameters.pageSize.toString());
        }
        if (parameters.searchBy) {
            httpParams = httpParams.set('searchBy', parameters.searchBy || '');
        }
        if (parameters.searchText) {
            httpParams = httpParams.set('searchText', parameters.searchText);
        }
        if (parameters.sortBy) {
            httpParams = httpParams.set('sortBy', parameters.sortBy);
        }
        if (parameters.sortDirection) {
            httpParams = httpParams.set('sortDirection', parameters.sortDirection);
        }

        return httpParams;
    }
}
