import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

  signUpForm: FormGroup;
  minDate: any;
  roles: any;
  constructor() { }

  ngOnInit() {
    this.signUpForm = new FormGroup({
      name: new FormControl('pawan raj shakya', [Validators.required, Validators.minLength(6), Validators.maxLength(70)]),
      username: new FormControl('pawanrajshakya', [Validators.required, Validators.minLength(6), Validators.maxLength(50)]),
      password: new FormControl('password', [Validators.required, Validators.minLength(8), Validators.maxLength(50)]),
      email: new FormControl('password@gmail.com', [Validators.email, , Validators.maxLength(70), Validators.required]),
      isActive: new FormControl(true),
      selectedUserRole: new FormControl(null, [Validators.required])
    });
    this.minDate = new Date();
    this.roles = [{id: 1, description: 'Admin'}, {id: 2, description: 'User'}];
  }

  onSubmit() {
    console.log(this.signUpForm);
  }

}
