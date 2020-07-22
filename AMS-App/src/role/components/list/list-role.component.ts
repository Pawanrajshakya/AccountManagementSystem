import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort, Sort } from '@angular/material/sort';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { IParam } from 'src/_models/param';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { AlertService } from 'src/_services/alert.service';
import { IRole } from 'src/_models/role-data';
import { RoleService } from 'src/role/services/role.service';

@Component({
  selector: 'app-list-role',
  templateUrl: './list-role.component.html',
  styleUrls: ['./list-role.component.css']
})
export class ListRoleComponent implements AfterViewInit, OnInit {

  columnsToDisplay = ['description', 'edit', 'delete'];

  data: IRole[];

  dataSource = new MatTableDataSource<IRole>();

  params: IParam = {
    pageNumber: 1,
    pageSize: 5
  };

  length = 1;
  pageSizeOptions: number[] = [5, 10, 25];
  searchList = [{ key: 1, value: 'Description' }];
  selected = 'Description';

  isLoading = true;

  @ViewChild(MatSort) matSort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild('selectedSearchBy', { static: false }) selectedSearchBy;

  constructor(
    private matDialog: MatDialog,
    private roleService: RoleService,
    private alertService: AlertService,
    private route: Router) { }

  private getRoles(param: IParam) {
    this.roleService.get(this.params).subscribe((data) => {
      this.dataSource.data = data.roles;
      this.length = data.totalCount;
      this.isLoading = false;
    }, (error) => {
      this.alertService.showAlert(error, 'Okay', 20000);
    });
  }

  ngOnInit(): void {
    this.getRoles(this.params);
  }

  ngAfterViewInit() {
    this.matSort.sortChange.subscribe((sort: Sort) => {
      this.params.sortBy = sort.active;
      this.params.sortDirection = sort.direction;
      this.getRoles(this.params);
    });
  }

  applyFilter(filteredValue: string) {
    this.isLoading = true;

    console.log(filteredValue, this.selectedSearchBy.value);
    this.paginator.pageIndex = 0;

    this.params.searchBy = this.selectedSearchBy.value;
    this.params.searchText = filteredValue;
    this.params.pageNumber = 1;
    this.getRoles(this.params);
  }

  change(event: PageEvent) {
    this.isLoading = true;
    setTimeout(() => {
      this.params.pageNumber = event.pageIndex + 1;
      this.params.pageSize = event.pageSize;
      this.getRoles(this.params);
    }, 500);
  }

  onAddNew() {
    this.route.navigate(['/addRole']);
  }

  onDelete(username: string, id: number) {
    // const dialogRef = this.matDialog.open(DeleteUserComponent, { data: { username, id } });

    // dialogRef.afterClosed().subscribe(result => {
    //   if (result === true) {
    //     this.getUsers(this.params);
    //   }
    // });
  }

  onView(id: number) {
    // const dialogRef = this.matDialog.open(ViewUserComponent, { data: { id } });
  }
}
