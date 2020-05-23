import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MaterialModule } from 'src/app/material.module';
import { AppRoutingModule } from 'src/app/app-routing.module';
import {FlexLayoutModule} from '@angular/flex-layout';

import { AppComponent } from 'src/app/app.component';
import { HomeComponent } from 'src/home/home.component';
import { HeaderComponent } from 'src/header/header.component';
import { AddUserComponent } from 'src/user/add-user/add-user.component';
import { LoginComponent } from 'src/User/login/login.component';


@NgModule({
   declarations: [
      AppComponent,
      HomeComponent,
      HeaderComponent,
      AddUserComponent,
      LoginComponent
   ],
   imports: [
      BrowserModule,
      ReactiveFormsModule,
      BrowserAnimationsModule,
      MaterialModule,
      AppRoutingModule,
      FlexLayoutModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
