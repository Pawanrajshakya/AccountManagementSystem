import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MaterialModule } from 'src/app/material.module';
import { ListRoleComponent } from './components/list/list-role.component';

@NgModule({
    declarations: [
        ListRoleComponent
    ],
    imports: [
        CommonModule,
        RouterModule,
        ReactiveFormsModule,
        MaterialModule,
        FlexLayoutModule
    ],
    entryComponents: [],
    exports: [
        ListRoleComponent
    ]
})

export class RoleModule {
}
