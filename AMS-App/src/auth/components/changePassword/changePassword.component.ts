import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { AuthService } from 'src/_services/auth.service';
import { FormGroup, FormControl, Validators, ValidatorFn, ValidationErrors } from '@angular/forms';
import { AppComponent } from 'src/app/app.component';
import { MatDialogRef } from '@angular/material/dialog';
import { UserService } from 'src/_services/user.service';
import { AlertService } from 'src/_services/alert.service';


@Component({
  selector: 'app-change-password',
  templateUrl: './changePassword.component.html',
  styleUrls: ['./changePassword.component.css']
})
export class ChangePasswordComponent implements OnInit {


  changePasswordForm: FormGroup;

  constructor(
    private userService: UserService,
    private authService: AuthService,
    private alertService: AlertService,
    public dialogRef: MatDialogRef<AppComponent>) { }

  ngOnInit() {
    this.changePasswordForm = new FormGroup({
      oldPassword: new FormControl('', [Validators.required]),
      newPassword: new FormControl('', [Validators.required]),
      confirmedNewPassword: new FormControl('', [Validators.required])
    }, { validators: passwordCompareValidator });
  }

  onSubmit() {
    this.userService.changePassword({
      oldPassword: this.changePasswordForm.get('oldPassword').value,
      newPassword: this.changePasswordForm.get('newPassword').value,
      username: this.authService.currentUser.username
    }).subscribe(
      (data) => {
        this.alertService.showAlert('Password changed successfully.');
        this.dialogRef.close({ changed: true });
      },
      (error) => {
        this.alertService.showAlert(error);
      });
  }
}

export const passwordCompareValidator: ValidatorFn =
  (control: FormGroup): ValidationErrors | null => {
    const newPassword = control.get('newPassword');
    const confirmedNewPassword = control.get('confirmedNewPassword');
    if (newPassword.value !== confirmedNewPassword.value) {
      return { passwordCompare: true };
    }
    return null;
  }