import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Store } from '@ngrx/store';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

import { IAuthData } from 'src/_models/auth-data';
import { environment } from 'src/environments/environment';
import { IUser } from 'src/_models/user-data';
import { UserService } from '../../_services/user.service';

import { AlertService } from '../../_services/alert.service';
import { LoginState } from 'src/auth/store';

import * as fromAction from '../store/auth.actions';

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  private jwtHelper = new JwtHelperService();

  decodedToken: any;

  // authChange = new Subject<boolean>();

  private baseUrl = environment.apiUrl;

  currentUser: IUser;

  constructor(
    private http: HttpClient,
    private router: Router,
    private userService: UserService,
    private alertService: AlertService,
    private store: Store<LoginState>) {
  }

  login(model: IAuthData) {

    this.store.dispatch(fromAction.loadAuths());

    return this.http.post(this.baseUrl + 'auth/login', model).pipe(
      map((response: any) => {
        console.log(response);
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
          this.getCurrentUser(this.decodedToken.nameid);
          // this.authChange.next(true);
          this.router.navigate(['/home']);
          console.log(this.decodedToken);
        }
      })
    ).subscribe(next => {
      this.alertService.showAlert('logged in successfully.', 'Close');
      this.store.dispatch(fromAction.loadAuthsSuccess({ data: model }));
    }, error => {
      this.alertService.showAlert(error, 'Close', 6000, true);
      this.store.dispatch(fromAction.loadAuthsFailure({ error }));
    });
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    if (!this.jwtHelper.isTokenExpired(token)) {
      this.decodedToken = this.jwtHelper.decodeToken(token);
      this.getCurrentUser(this.decodedToken.nameid);
      // this.authChange.next(true);
      return true;
    }
    return false;
  }

  logout() {
    this.store.dispatch(fromAction.loadAuthsFailure({ error: 'Logged Out.' }));
    localStorage.removeItem('token');
    // this.authChange.next(false);
    this.router.navigate(['/login']);
  }

  // isAuth() {
  //   if (this.loggedIn()) {
  //   this.decodedToken = this.jwtHelper.decodeToken(user.token);

  //         this.getCurrentUser(this.decodedToken.nameid);
  //       }
  // }

  getCurrentUser(id: number) {
    this.userService.getById(id).subscribe((data) => {
      this.currentUser = data;
      console.log(this.currentUser);
    });
  }

}
