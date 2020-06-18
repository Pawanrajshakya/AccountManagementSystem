import { Component, OnInit, Inject } from '@angular/core';
import { UserService } from 'src/_services/user.service';
import { AuthService } from 'src/_services/auth.service';
import { AlertService } from 'src/_services/alert.service';
import { MatDialogRef , MAT_DIALOG_DATA} from '@angular/material/dialog';
import { ListUserComponent } from '../list/list.component';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteUserComponent implements OnInit {

  constructor(
    private userService: UserService,
    private authService: AuthService,
    private alertService: AlertService,
    public dialogRef: MatDialogRef<ListUserComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
  }

  onDelete(id: number) {
    this.userService.delete(id).subscribe(
      (data) => {
        this.alertService.showAlert('deleted successfully.');
        this.dialogRef.close(true);
      },
      (error) => {
        this.alertService.showAlert(error);
      });
  }

}
