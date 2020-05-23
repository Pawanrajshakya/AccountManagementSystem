import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  imports: [MatButtonModule, MatInputModule,
    MatFormFieldModule, MatDatepickerModule,
    MatNativeDateModule, MatCheckboxModule,
    MatSelectModule],
  exports: [MatButtonModule, MatInputModule,
    MatFormFieldModule, MatDatepickerModule,
    MatNativeDateModule, MatCheckboxModule,
    MatSelectModule]
})
export class MaterialModule { }
