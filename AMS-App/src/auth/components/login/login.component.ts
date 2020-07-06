import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { AuthService } from 'src/_services/auth.service';
// import * as fromApp from '../../_shared/auth.reducer';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  isLoading$: Observable<boolean>;

  constructor(
    private authService: AuthService) { }
    //private store: Store<{ auth: fromApp.IState }>) { }

  ngOnInit(): void {
    // this.isLoading$ = this.store.select(state => state.auth.isLoading);

    this.loginForm = new FormGroup({
      username: new FormControl('sysadmin', [Validators.required]),
      password: new FormControl('password', [Validators.required])
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      this.authService
        .login({
          username: this.loginForm.value.username,
          password: this.loginForm.value.password
        });
    }
  }
}

// forbiddenNameValidator(control: FormControl): { [s: string]: boolean } {
  //   if (this.forbiddenNames.indexOf(control.value) !== -1) {
  //     return { nameIsForbidden: true };
  //   }
  //   return null;
  // }

  // forbiddenEmailValidatorAsync(control: FormControl): Promise<any> | Observable<any> {
  //   const prmoise = new Promise((resolve, reject) => {
  //     setTimeout(() => {
  //       if (control.value === 'test@test.test') {
  //         resolve({ emailIsForbidden: true });
  //       } else {
  //         resolve(null);
  //       }
  //     }, 1500);
  //   });
  //   return prmoise;
  // }
  //forbiddenNames = ['sa', 'user', 'password', 'username', ' ', '1', 'test'];

  // genders = ['Male', 'Female', 'Unknown'];

  // ngOnInit() {

  //   this.login();

  //   this.loginForm = new FormGroup({
  //     userData: new FormGroup({
  //       username: new FormControl(null, [Validators.required, this.forbiddenNameValidator.bind(this)]),
  //       email: new FormControl('@gmail.com', [Validators.required, Validators.email], this.forbiddenEmailValidatorAsync),
  //     }),
  //     gender: new FormControl('Male')
  //   });
  // }

  // onSubmit() {
  //   console.log(this.loginForm);
  // }



  // forbiddenEmailValidatorAsync(control: FormControl): Promise<any> | Observable<any> {
  //   const prmoise = new Promise((resolve, reject) => {
  //     setTimeout(() => {
  //       if (control.value === 'test@test.test') {
  //         resolve({ emailIsForbidden: true });
  //       } else {
  //         resolve(null);
  //       }
  //     }, 1500);
  //   });
  //   return prmoise;
  // }

  // login() {
  //   this.authService
  //     .login({ username: "pawanrajshakya", password: "password" })
  //     .subscribe(next => {
  //       console.log('logged in successfully.')
  //     }, error => {
  //       console.error('logged in failed.')
  //     })
  // }
