import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { Observable, observable } from 'rxjs';
import { IUsers, IUserToSave, IUser, IChangePassword } from 'src/_models/user-data';
import { IParam } from 'src/_models/param';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient, private router: Router) { }

  getById(id: number): Observable<IUser> {
    if (id === 0) {
      const user: IUser = {
        id: 0,
        name: '',
        username: '',
        // password: '',
        email: '',
        userRole: [],
        isActive: true
      };
      return new Observable((observe) => {
        observe.next(user);
      });
    } else {
      return this.http.get<IUser>(this.baseUrl + 'user\\' + id);
    }
  }

  get(parameters: IParam): Observable<IUsers> {
    let httpParams = new HttpParams()
      .set('pageNumber', parameters.pageNumber.toString())
      .set('pageSize', parameters.pageSize.toString());

    console.log(parameters.sortDirection);

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

    return this.http.get<IUsers>(this.baseUrl + 'user', { params: httpParams });

  }

  add(newUser: IUserToSave) {
    console.log(newUser);
    return this.http.post(this.baseUrl + 'user', newUser);
  }

  update(id: number, newUser: IUserToSave) {
    return this.http.patch(this.baseUrl + 'user/' + id, newUser);
  }

  delete(id: number) {
    return this.http.delete(this.baseUrl + 'user/' + id);
  }

  changePassword(changePassword: IChangePassword) {
    console.log(changePassword);
    return this.http.post(this.baseUrl + 'user/changepassword', changePassword);
  }
}
