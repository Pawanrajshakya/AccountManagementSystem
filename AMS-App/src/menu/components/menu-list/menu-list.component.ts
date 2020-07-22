import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort, Sort } from '@angular/material/sort';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { IParam } from 'src/_models/param';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { AlertService } from 'src/_services/alert.service';
import { IMenu } from 'src/_models/menu-data';
import { MenuService } from 'src/menu/services/menu.service';
import { MenuDeleteComponent } from '../menu-delete/menu-delete.component';

@Component({
  selector: 'app-menu-list',
  templateUrl: './menu-list.component.html',
  styleUrls: ['./menu-list.component.css']
})

export class MenuListComponent implements AfterViewInit, OnInit {

  columnsToDisplay = ['title', 'edit', 'delete'];

  data: IMenu[];

  dataSource = new MatTableDataSource<IMenu>();

  params: IParam = {
    pageNumber: 1,
    pageSize: 5
  };

  length = 1;
  pageSizeOptions: number[] = [5, 10, 25];
  searchList = [{ key: 1, value: 'Title' }];
  selected = 'Title';

  isLoading = true;

  @ViewChild(MatSort) matSort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild('selectedSearchBy', { static: false }) selectedSearchBy;

  constructor(
    private matDialog: MatDialog,
    private menuService: MenuService,
    private alertService: AlertService,
    private route: Router) { }

  private getMenus(param: IParam) {
    this.menuService.get(this.params).subscribe((data) => {
      console.log('???;', data);
      this.dataSource.data = data.menus;
      this.length = data.totalCount;
      this.isLoading = false;
    }, (error) => {
      this.alertService.showAlert(error, 'Okay', 20000);
    });
  }

  ngOnInit(): void {
    this.getMenus(this.params);
  }

  ngAfterViewInit() {
    this.matSort.sortChange.subscribe((sort: Sort) => {
      this.params.sortBy = sort.active;
      this.params.sortDirection = sort.direction;
      this.getMenus(this.params);
    });
  }

  applyFilter(filteredValue: string) {
    this.isLoading = true;

    console.log(filteredValue, this.selectedSearchBy.value);
    this.paginator.pageIndex = 0;

    this.params.searchBy = this.selectedSearchBy.value;
    this.params.searchText = filteredValue;
    this.params.pageNumber = 1;
    this.getMenus(this.params);
  }

  change(event: PageEvent) {
    this.isLoading = true;
    setTimeout(() => {
      this.params.pageNumber = event.pageIndex + 1;
      this.params.pageSize = event.pageSize;
      this.getMenus(this.params);
    }, 500);
  }

  onAddNew() {
    this.route.navigate(['/addMenu']);
  }

  onDelete(title: string, id: number) {
    const dialogRef = this.matDialog.open(MenuDeleteComponent, { data: { title, id } });

    dialogRef.afterClosed().subscribe(result => {
      if (result === true) {
        this.getMenus(this.params);
      }
    });
  }

  onView(id: number) {
    // const dialogRef = this.matDialog.open(ViewUserComponent, { data: { id } });
  }
}
