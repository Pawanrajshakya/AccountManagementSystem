import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { JwtModule } from '@auth0/angular-jwt';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HttpClientModule } from '@angular/common/http';

import { MaterialModule } from 'src/app/material.module';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { AppComponent } from 'src/app/app.component';
import { HomeComponent } from 'src/home/home.component';
import { HeaderComponent } from 'src/header/header.component';
import { LoginComponent } from 'src/auth/login/login.component';
import { AuthService } from 'src/_services/auth.service';
import { AlertService } from 'src/_services/alert.service';
import { ChangePasswordComponent } from 'src/auth/changePassword/changePassword.component';
import { ErrorInterceptorProvider } from 'src/_services/error.interceptor';
import { AddUserComponent } from 'src/user/add/add-user.component';
import { ListUserComponent } from 'src/user/list/list-user.component';
import { DeleteUserComponent } from 'src/user/delete/delete-user.component';
import { ViewUserComponent } from 'src/user/view/view-user.component';



@NgModule({
   declarations: [
      AppComponent,
      HomeComponent,
      HeaderComponent,
      AddUserComponent,
      LoginComponent,
      ListUserComponent,
      ChangePasswordComponent,
      DeleteUserComponent,
      ViewUserComponent
   ],
   imports: [
      BrowserModule,
      ReactiveFormsModule,
      BrowserAnimationsModule,
      MaterialModule,
      AppRoutingModule,
      FlexLayoutModule,
      HttpClientModule,
      JwtModule.forRoot({
         config: {
            tokenGetter: getToken,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: []
         }
      })
   ],
   providers: [
      AuthService, AlertService, ErrorInterceptorProvider
   ],
   bootstrap: [
      AppComponent
   ],
   entryComponents: [
      ChangePasswordComponent,
      DeleteUserComponent]
})
export class AppModule { }

export function getToken() {
   return localStorage.getItem('token');
}
