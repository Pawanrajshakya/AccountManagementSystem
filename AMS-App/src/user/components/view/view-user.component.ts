import { Component, OnInit, Inject } from '@angular/core';
import { UserService } from 'src/_services/user.service';
import { RouterLink, ActivatedRoute } from '@angular/router';
import { IUser } from 'src/_models/user-data';
import { AlertService } from 'src/_services/alert.service';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-view-user',
  templateUrl: './view-user.component.html',
  styleUrls: ['./view-user.component.css']
})
export class ViewUserComponent implements OnInit {

  id = 0;
  user: IUser;

  constructor(
    private userService: UserService,
    private route: ActivatedRoute,
    private alertService: AlertService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.id = data.id;
   }

  ngOnInit() {
    console.log(this.id);

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
        console.log(this.user);
      });
  }

}
