import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MenuListComponent } from './components/menu-list/menu-list.component';
import { MenuAddComponent } from './components/menu-add/menu-add.component';
import { MenuDeleteComponent } from './components/menu-delete/menu-delete.component';

@NgModule({
    declarations: [
        MenuListComponent,
        MenuAddComponent,
        MenuDeleteComponent
    ],
    imports: [
        CommonModule,
        RouterModule,
        ReactiveFormsModule,
        MaterialModule,
        FlexLayoutModule
    ],
    entryComponents: [
        MenuDeleteComponent
    ],
    exports: [
        MenuListComponent,
        MenuAddComponent,
        MenuDeleteComponent
    ]
})
export class MenuModule {
}
