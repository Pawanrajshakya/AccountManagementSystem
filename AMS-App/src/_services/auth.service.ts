import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { AuthData } from 'src/_models/auth-data';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Subject } from 'rxjs';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { IUser } from 'src/_models/user-data';

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  private jwtHelper = new JwtHelperService();

  decodedToken: any;

  authChange = new Subject<boolean>();

  private baseUrl = environment.apiUrl;

  private userData: IUser;

  constructor(private http: HttpClient, private router: Router) {
  }

  login(model: AuthData) {
    return this.http.post(this.baseUrl + 'auth/login', model).pipe(
      map((response: any) => {
        console.log(response);
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
          this.authChange.next(true);
          this.router.navigate(['/home']);
          console.log(this.decodedToken);
        }
      })
    );
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

  logout() {
    localStorage.removeItem('token');
    this.authChange.next(false);
    this.router.navigate(['/login']);
  }

  isAuth() {

  }

}
