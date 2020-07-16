import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { IRole, IRoles, IRoleToSave } from 'src/_models/role-data';
import { IParam } from 'src/_models/param';
import { Base } from 'src/_services/base';

@Injectable({
  providedIn: 'root'
})
export class RoleService extends Base {

  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient, private router: Router) {
    super();
  }

  getById(id: number): Observable<IRole> {
    if (id === 0) {
      return new Observable((observe) => {
        observe.next({
          id: 0,
          description: '',
          isActive: true
        });
      });
    } else {
      return this.http.get<IRole>(this.baseUrl + 'role\\' + id);
    }
  }

  get(parameters: IParam): Observable<IRoles> {
    const httpParams = this.getHttpParams(parameters);

    console.log(parameters.sortDirection);

    return this.http.get<IRoles>(this.baseUrl + 'role', { params: httpParams });

  }

  add(newRole: IRoleToSave) {
    console.log(newRole);
    return this.http.post(this.baseUrl + 'role', newRole);
  }

  update(id: number, newRole: IRoleToSave) {
    return this.http.patch(this.baseUrl + 'role/' + id, newRole);
  }

  delete(id: number) {
    return this.http.delete(this.baseUrl + 'role/' + id);
  }

}
