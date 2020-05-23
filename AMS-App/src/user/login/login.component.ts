import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  genders = ['Male', 'Female', 'Unknown'];
  loginForm: FormGroup;
  forbiddenNames = ['sa', 'user', 'password', 'username', ' ', '1'];

  constructor() { }

  ngOnInit() {
    this.loginForm = new FormGroup({
      userData: new FormGroup({
        username: new FormControl(null, [Validators.required, this.forbiddenNameValidator.bind(this)]),
        email: new FormControl('@gmail.com', [Validators.required, Validators.email], this.forbiddenEmailValidatorAsync),
      }),
      gender: new FormControl('Male')
    });
  }

  onSubmit() {
    console.log(this.loginForm);
  }

  forbiddenNameValidator(control: FormControl): { [s: string]: boolean } {
    if (this.forbiddenNames.indexOf(control.value) !== -1) {
      return { nameIsForbidden: true };
    }
    return null;
  }

  forbiddenEmailValidatorAsync(control: FormControl): Promise<any> | Observable<any> {
    const prmoise = new Promise((resolve, reject) => {
      setTimeout(() => {
        if (control.value === 'test@test.test') {
          resolve({ emailIsForbidden: true });
        } else {
          resolve(null);
        }
      }, 1500);
    });
    return prmoise;
  }
}
