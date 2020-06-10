import { Component, ViewChild, OnInit, OnDestroy } from '@angular/core';
import { MatAccordion } from '@angular/material/expansion/accordion';
import { AuthService } from 'src/_services/auth.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy {

  isLoggedIn = false;

  authSubscription: Subscription;

  usernameToDisplay: string;

  constructor(private authService: AuthService) { }

  @ViewChild('accordion', { static: true }) Accordion: MatAccordion;

  myMenu = [
    {
      id: 'Home',
      title: 'Home',
      link: 'home',
      isDisabled: false,
      isExpanded: false,
      hasSubMenu: false,
      icon: ''
    }, {
      id: 'User',
      title: 'User',
      link: 'user',
      isDisabled: false,
      isExpanded: false,
      hasSubMenu: true,
      subMenu: [{
        id: 'List',
        title: 'List',
        link: 'listUser',
        isDisabled: false,
        icon: 'fa fa-user-plus'
      },
      {
        id: 'Add',
        title: 'Add',
        link: 'addUser',
        isDisabled: false,
        icon: 'fa fa-user-plus'
      }]
    }
  ];

  closeAllPanels() {
    this.Accordion.closeAll();
  }
  openAllPanels() {
    this.Accordion.openAll();
  }

  ngOnInit(): void {
    this.authSubscription = this.authService.authChange.subscribe((loggedIn) => {
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

}
