import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { JwtModule } from '@auth0/angular-jwt';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HttpClientModule } from '@angular/common/http';
import { StoreModule } from '@ngrx/store';


import { MaterialModule } from 'src/app/material.module';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { AppComponent } from 'src/app/app.component';
import { HomeComponent } from 'src/home/home.component';
import { HeaderComponent } from 'src/header/header.component';
import { AuthService } from 'src/_services/auth.service';
import { AlertService } from 'src/_services/alert.service';
import { ErrorInterceptorProvider } from 'src/_services/error.interceptor';
import { reducers, metaReducers } from './reducers';
// import { StoreDevtoolsModule } from '@ngrx/store-devtools';
// import { environment } from '../environments/environment';
import { UserModule } from 'src/user/user.module';
import { AuthModule } from 'src/auth/auth.module';

@NgModule({
   declarations: [
      AppComponent,
      HomeComponent,
      HeaderComponent,
   ],
   imports: [
      BrowserModule,
      ReactiveFormsModule,
      BrowserAnimationsModule,
      MaterialModule,
      AppRoutingModule,
      FlexLayoutModule,
      HttpClientModule,
      AuthModule,
      UserModule,
      JwtModule.forRoot({
         config: {
            tokenGetter: getToken,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: []
         }
      }),
      StoreModule.forRoot(reducers, {
         metaReducers,
         runtimeChecks: {
            strictStateImmutability: true,
            strictActionImmutability: true,
         },
      })//,
      //!environment.production ? StoreDevtoolsModule.instrument() : []
   ],
   providers: [
      AuthService, AlertService, ErrorInterceptorProvider
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }

export function getToken() {
   return localStorage.getItem('token');
}
