import { Component, ViewChild, OnInit, OnDestroy, AfterContentInit } from '@angular/core';
import { MatAccordion } from '@angular/material/expansion/accordion';
import { AuthService } from 'src/auth/services/auth.service';
import { Observable } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { ChangePasswordComponent } from 'src/auth/components/changePassword/changePassword.component';
import { LoginState, selectIsAuthenticated, selectAuthenticatedUser } from 'src/auth/store';
import { Store, select } from '@ngrx/store';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterContentInit {

  private hideTitle = false;

  @ViewChild('accordion', { static: true }) Accordion: MatAccordion;

  myMenu = [
    {
      id: 1,
      title: 'Home',
      link: 'home',
      isDisabled: false,
      isExpanded: false,
      hasSubMenu: false,
      icon: 'fa fa-home'
    }, {
      id: 2,
      title: 'Account',
      link: 'listUser',
      isDisabled: false,
      isExpanded: false,
      hasSubMenu: false,
      icon: 'fa fa-user-circle'
    }, {
      id: 3,
      title: 'Transaction',
      link: 'listUser',
      isDisabled: false,
      isExpanded: false,
      hasSubMenu: false,
      icon: 'fa fa-money'
    }, {
      id: 4,
      title: 'Reports',
      link: 'listUser',
      isDisabled: false,
      isExpanded: true,
      hasSubMenu: true,
      icon: 'fa fa-list',
      subMenus: [{
        id: 5,
        title: 'Menu Setup',
        link: 'menu',
        isDisabled: false,
        icon: 'fa fa-linode'
      }]
    }, {
      id: 6,
      title: 'Code Setup',
      link: 'code',
      isDisabled: false,
      isExpanded: true,
      hasSubMenu: true,
      icon: 'fa fa-linode',
      subMenus: [{
        id: 7,
        title: 'Role',
        link: 'role',
        isDisabled: false,
        icon: 'fa fa-user'
      },
      {
        id: 8,
        title: 'Menu',
        link: 'menu',
        isDisabled: false,
        icon: 'fa fa-linode'
      }]
    }, {
      id: 9,
      title: 'Settings',
      link: 'listUser',
      isDisabled: false,
      isExpanded: false,
      hasSubMenu: false,
      icon: 'fa fa-cogs'
    }, {
      id: 10,
      title: 'User',
      link: 'user',
      isDisabled: false,
      isExpanded: false,
      hasSubMenu: false,
      icon: 'fa fa-users'
    }
  ];

  isLoading$: Observable<boolean>;
  usernameToDisplay$: Observable<string>;

  constructor(
    private authService: AuthService,
    private matDialog: MatDialog,
    private store: Store<LoginState>) { }

  ngAfterContentInit(): void {
    this.isLoading$ = this.store.pipe(select(selectIsAuthenticated));
    this.usernameToDisplay$ = this.store.pipe(select(selectAuthenticatedUser));
  }

  onSignOut() {
    this.authService.logout();
  }

  onChangePassword(): void {
    const dialogRef = this.matDialog.open(ChangePasswordComponent, { width: '300px' });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
    });
  }
}
