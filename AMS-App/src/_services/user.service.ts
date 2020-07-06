import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { IUsers, IUserToSave, IUser, IChangePassword } from 'src/_models/user-data';
import { IParam } from 'src/_models/param';
import { Base } from './base';

@Injectable({
  providedIn: 'root'
})
export class UserService extends Base{

  private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient, private router: Router) {
    super();
  }

  getById(id: number): Observable<IUser> {
    if (id === 0) {
      const user: IUser = {
        id: 0,
        name: '',
        username: '',
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
    const httpParams = this.getHttpParams(parameters);
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
