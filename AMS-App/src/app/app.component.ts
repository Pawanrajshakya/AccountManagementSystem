import { Component, ViewChild, OnInit, OnDestroy, AfterContentInit } from '@angular/core';
import { MatAccordion } from '@angular/material/expansion/accordion';
import { AuthService } from 'src/_services/auth.service';
import { Subscription } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { ChangePasswordComponent } from 'src/auth/changePassword/changePassword.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy, AfterContentInit {

  isLoggedIn = false;

  authSubscription: Subscription;

  usernameToDisplay: string;

  hideTitle = false;

  @ViewChild('accordion', { static: true }) Accordion: MatAccordion;

  myMenu = [
    {
      id: 'Home',
      title: 'Home',
      link: 'home',
      isDisabled: false,
      isExpanded: false,
      hasSubMenu: false,
      icon: 'fa fa-home'
    }, {
      id: 'Account',
      title: 'Account',
      link: 'listUser',
      isDisabled: false,
      isExpanded: false,
      hasSubMenu: false,
      icon: 'fa fa-user-circle'
    }, {
      id: 'Transaction',
      title: 'Transaction',
      link: 'listUser',
      isDisabled: false,
      isExpanded: false,
      hasSubMenu: false,
      icon: 'fa fa-money'
    }, {
      id: 'Reports',
      title: 'Reports',
      link: 'listUser',
      isDisabled: false,
      isExpanded: false,
      hasSubMenu: false,
      icon: 'fa fa-list'
    }, {
      id: 'Codes',
      title: 'Code Setup',
      link: 'listUser',
      isDisabled: false,
      isExpanded: false,
      hasSubMenu: false,
      icon: 'fa fa-linode'
    }, {
      id: 'Settings',
      title: 'Settings',
      link: 'listUser',
      isDisabled: false,
      isExpanded: false,
      hasSubMenu: false,
      icon: 'fa fa-cogs'
    }, {
      id: 'User',
      title: 'User',
      link: 'listUser',
      isDisabled: false,
      isExpanded: false,
      hasSubMenu: false,
      icon: 'fa fa-user'
    }
  ];

  constructor(private authService: AuthService, private matDialog: MatDialog) { }

  ngAfterContentInit(): void {
    this.authService.loggedIn();
  }

  // closeAllPanels() {
  //   this.Accordion.closeAll();
  // }
  // openAllPanels() {
  //   this.Accordion.openAll();
  // }

  ngOnInit(): void {
    this.authSubscription = this.authService.authChange.subscribe((loggedIn) => {
      console.log(loggedIn);
      this.isLoggedIn = loggedIn;
      this.usernameToDisplay = this.authService.decodedToken.unique_name;
    });
  }

  onSignOut() {
    this.authService.logout();
  }

  ngOnDestroy(): void {
    this.authSubscription.unsubscribe();
  }

  onChangePassword(): void {
    const dialogRef = this.matDialog.open(ChangePasswordComponent, { width: '300px' });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
    });
  }
}
