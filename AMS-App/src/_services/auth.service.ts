import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Store } from '@ngrx/store';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';

import { AuthData } from 'src/_models/auth-data';
import { environment } from 'src/environments/environment';
import { IUser } from 'src/_models/user-data';
import { UserService } from './user.service';


import { AlertService } from './alert.service';

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  private jwtHelper = new JwtHelperService();

  decodedToken: any;

  authChange = new Subject<boolean>();

  private baseUrl = environment.apiUrl;

  currentUser: IUser;

  constructor(
    private http: HttpClient,
    private router: Router,
    private userService: UserService,
    private alertService: AlertService) {
  }

  login(model: AuthData) {

    //this.store.dispatch({ type: START_LOADING });

    return this.http.post(this.baseUrl + 'auth/login', model).pipe(
      map((response: any) => {
        console.log(response);
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
          this.getCurrentUser(this.decodedToken.nameid);
          this.authChange.next(true);
          this.router.navigate(['/home']);
          console.log(this.decodedToken);
        }
      })
    ).subscribe(next => {
      this.alertService.showAlert('logged in successfully.', 'Close');
      //this.store.dispatch({ type: STOP_LOADING });
    }, error => {
      this.alertService.showAlert(error, 'Close', 6000, true);
      //this.store.dispatch({ type: STOP_LOADING });
    });
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    if (!this.jwtHelper.isTokenExpired(token)) {
      this.decodedToken = this.jwtHelper.decodeToken(token);
      this.getCurrentUser(this.decodedToken.nameid);
      this.authChange.next(true);
      return true;
    }
    return false;
  }

  logout() {
    localStorage.removeItem('token');
    this.authChange.next(false);
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
