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
import { AddUserComponent } from 'src/user/add-user/add-user.component';
import { LoginComponent } from 'src/User/login/login.component';
import { AuthService } from 'src/_services/auth.service';
import { ListComponent } from 'src/user/list/list.component';
import { AlertService } from 'src/_services/alert.service';



@NgModule({
   declarations: [
      AppComponent,
      HomeComponent,
      HeaderComponent,
      AddUserComponent,
      LoginComponent,
      ListComponent
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
         config:{
            tokenGetter: getToken,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: []
         }
      })
   ],
   providers: [
      AuthService, AlertService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }

export function getToken() {
   return localStorage.getItem('token');
}