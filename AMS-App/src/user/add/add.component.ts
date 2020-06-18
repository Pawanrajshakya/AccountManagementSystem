import { Component, OnInit, AfterViewInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService } from 'src/_services/user.service';
import { IUser } from 'src/_models/user-data';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertService } from 'src/_services/alert.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})

export class AddUserComponent implements OnInit, AfterViewInit {

  signUpForm: FormGroup;

  roles = [{ id: 1, description: 'Admin' }, { id: 2, description: 'User' }];
  user: IUser;
  id = 0;

  constructor(
    private userService: UserService,
    private router: Router,
    private route: ActivatedRoute,
    private alertService: AlertService) { }

  ngAfterViewInit(): void {

  }

  ngOnInit() {

    this.signUpForm = new FormGroup({
      id: new FormControl(0),
      name: new FormControl('',
        [Validators.required, Validators.minLength(6), Validators.maxLength(70)]),
      username: new FormControl('',
        [Validators.required, Validators.minLength(6), Validators.maxLength(50)]),
      email: new FormControl('',
        [Validators.email, , Validators.maxLength(70), Validators.required]),
      phone: new FormControl('', [Validators.maxLength(20)]),
      isActive: new FormControl(true),
      selectedUserRole: new FormControl([], [Validators.required])
    });

    this.id = this.route.snapshot.params.id;

    if (this.id === undefined) {
      this.id = 0;
    }

    this.userService.getById(this.id).subscribe(
      (data) => {
        this.user = data;
      },
      (error) => {
        this.alertService.showAlert(error);
      },
      () => {
        console.log(1, this.user);
        this.signUpForm.get('id').setValue(this.user.id);
        this.signUpForm.get('username').setValue(this.user.username);
        this.signUpForm.get('name').setValue(this.user.name);
        this.signUpForm.get('email').setValue(this.user.email);
        this.signUpForm.get('phone').setValue(this.user.phone);
        this.signUpForm.get('isActive').setValue(this.user.isActive);
        const roles = [];
        this.user.userRole.forEach(element => {
          roles.push(element.id);
        });

        this.signUpForm.get('selectedUserRole').setValue(roles);
      });

  }

  onSubmit() {
    this.user = {
      id: this.signUpForm.get('id').value,
      username: this.signUpForm.get('username').value,
      name: this.signUpForm.get('name').value,
      email: this.signUpForm.get('email').value,
      phone: this.signUpForm.get('phone').value,
      isActive: this.signUpForm.get('isActive').value,
      userRole: this.signUpForm.get('selectedUserRole').value
    };
    console.log('???', this.user);
    if (this.id === 0) {
      this.userService.add(this.user).subscribe((response) => {
        this.router.navigate(['/listUser']);
      }, (error) => {
        this.alertService.showAlert(error);
      });
    } else {
      this.userService.update(this.id, this.user).subscribe((response) => {
        this.router.navigate(['/listUser']);
      }, (error) => {
        this.alertService.showAlert(error);
      });
    }
  }

  onCancel() {
    this.router.navigate(['/listUser']);
  }
}
