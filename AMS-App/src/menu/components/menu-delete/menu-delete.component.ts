import { Component, OnInit, Inject } from '@angular/core';
import { MenuService } from 'src/menu/services/menu.service';
import { AlertService } from 'src/_services/alert.service';
import { MenuListComponent } from '../menu-list/menu-list.component';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-menu-delete',
  templateUrl: './menu-delete.component.html',
  styleUrls: ['./menu-delete.component.css']
})
export class MenuDeleteComponent implements OnInit {

  constructor(
    private menuService: MenuService,
    private alertService: AlertService,
    public dialogRef: MatDialogRef<MenuListComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }
  
  ngOnInit(): void {
  }

  onDelete(id: number) {
    this.menuService.delete(id).subscribe(
      (data) => {
        this.alertService.showAlert('deleted successfully.');
        this.dialogRef.close(true);
      },
      (error) => {
        this.alertService.showAlert(error);
      });
  }
}
