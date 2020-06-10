import { Component, OnInit, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort, Sort } from '@angular/material/sort';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { IUser } from 'src/_models/user-data';
import { UserService } from 'src/_services/user.service';
import { IParam } from 'src/_models/param';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})

export class ListComponent implements AfterViewInit, OnInit {

  columnsToDisplay = ['name', 'username', 'isActive', 'userRole', 'options'];

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

  constructor(private userService: UserService, private route: Router) { }

  private getUsers(param: IParam) {
    this.userService.get(this.params).subscribe((data) => {
      this.userDataSource.data = data.users;
      this.length = data.totalCount;
      this.isLoading = false;
      console.log(data);
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
      console.log(sort, 'sort');
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
      console.log(event);
    }, 500);
  }
  onAddNew() {
    this.route.navigate(['/addUser']);
  }
}
