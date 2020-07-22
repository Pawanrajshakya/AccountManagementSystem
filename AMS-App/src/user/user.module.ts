import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { ListUserComponent } from './components/list/list-user.component';
import { AddUserComponent } from './components/add/add-user.component';
import { ViewUserComponent } from './components/view/view-user.component';
import { DeleteUserComponent } from './components/delete/delete-user.component';
import { MaterialModule } from 'src/app/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';

@NgModule({
    declarations: [
        ListUserComponent,
        AddUserComponent,
        DeleteUserComponent,
        ViewUserComponent
    ],
    imports: [CommonModule,
        ReactiveFormsModule,
        RouterModule,
        MaterialModule,
        FlexLayoutModule],
    entryComponents: [DeleteUserComponent],
    exports: [
        ListUserComponent,
        AddUserComponent,
        DeleteUserComponent,
        ViewUserComponent
    ]
})
export class UserModule { }
