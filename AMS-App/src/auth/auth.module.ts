import { NgModule } from '@angular/core';
import { LoginComponent } from './components/login/login.component';
import { ChangePasswordComponent } from './components/changePassword/changePassword.component';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { StoreModule } from '@ngrx/store';
import * as fromLoginState from './store';

@NgModule({
    declarations: [
        LoginComponent,
        ChangePasswordComponent
    ],
    imports: [CommonModule,
        RouterModule,
        ReactiveFormsModule,
        MaterialModule,
        FlexLayoutModule,
        StoreModule.forFeature(
            fromLoginState.loginStateFeatureKey,
            fromLoginState.reducers, {
            metaReducers: fromLoginState.metaReducers
        })],
    entryComponents: [
        ChangePasswordComponent],
    exports: [
        LoginComponent,
        ChangePasswordComponent
    ]
})

export class AuthModule {
}
