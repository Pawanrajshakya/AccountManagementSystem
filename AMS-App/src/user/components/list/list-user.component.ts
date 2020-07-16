import { Component, OnInit, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort, Sort } from '@angular/material/sort';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { IUser } from 'src/_models/user-data';
import { UserService } from 'src/user/services/user.service';
import { IParam } from 'src/_models/param';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { DeleteUserComponent } from '../delete/delete-user.component';
import { AlertService } from 'src/_services/alert.service';
import { ViewUserComponent } from '../view/view-user.component';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})

export class ListUserComponent implements AfterViewInit, OnInit {

  columnsToDisplay = ['name', 'username', 'userRole', 'edit', 'delete'];

  users: IUser[];

  userDataSource = new MatTableDataSource<IUser>();

  params: IParam = {
    pageNumber: 1,
    pageSize: 5
  };

  length = 1;
  pageSizeOptions: number[] = [5, 10, 25];
  searchList = [{ key: 1, value: 'Username' }, { key: 2, value: 'Name' }];
  selected = 'Username';

  isLoading = true;

  @ViewChild(MatSort) matSort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild('selectedSearchBy', { static: false }) selectedSearchBy;

  constructor(
    private matDialog: MatDialog,
    private userService: UserService,
    private alertService: AlertService,
    private route: Router) { }

  private getUsers(param: IParam) {
    this.userService.get(this.params).subscribe((data) => {
      this.userDataSource.data = data.users;
      this.length = data.totalCount;
      this.isLoading = false;
    }, (error) => {
      this.alertService.showAlert(error, 'Okay', 20000);
    });
  }

  ngOnInit(): void {
    this.getUsers(this.params);
  }

  ngAfterViewInit() {
    this.matSort.sortChange.subscribe((sort: Sort) => {
      this.params.sortBy = sort.active;
      this.params.sortDirection = sort.direction;
      this.getUsers(this.params);
    });
  }

  applyFilter(filteredValue: string) {
    this.isLoading = true;

    console.log(filteredValue, this.selectedSearchBy.value);
    this.paginator.pageIndex = 0;

    this.params.searchBy = this.selectedSearchBy.value;
    this.params.searchText = filteredValue;
    this.params.pageNumber = 1;
    this.getUsers(this.params);
  }

  change(event: PageEvent) {
    this.isLoading = true;
    setTimeout(() => {
      this.params.pageNumber = event.pageIndex + 1;
      this.params.pageSize = event.pageSize;
      this.getUsers(this.params);
    }, 500);
  }

  onAddNew() {
    this.route.navigate(['/addUser']);
  }

  onDelete(username: string, id: number) {
    const dialogRef = this.matDialog.open(DeleteUserComponent, { data: { username, id } });

    dialogRef.afterClosed().subscribe(result => {
      if (result === true) {
        this.getUsers(this.params);
      }
    });
  }

  onView(id: number) {
    const dialogRef = this.matDialog.open(ViewUserComponent, { data: { id } });
  }
}
