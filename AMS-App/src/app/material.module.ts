import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatMenuModule } from '@angular/material/menu';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  imports: [MatButtonModule, MatInputModule,
    MatFormFieldModule, MatDatepickerModule,
    MatNativeDateModule, MatCheckboxModule,
    MatSelectModule, MatSidenavModule,
    MatToolbarModule, MatListModule,
    MatExpansionModule, MatMenuModule,
    MatTableModule, MatPaginatorModule,
    MatSortModule, MatSnackBarModule,
    MatProgressBarModule, MatTooltipModule,
    MatDialogModule],
  exports: [MatButtonModule, MatInputModule,
    MatFormFieldModule, MatDatepickerModule,
    MatNativeDateModule, MatCheckboxModule,
    MatSelectModule, MatSidenavModule,
    MatToolbarModule, MatListModule,
    MatExpansionModule, MatMenuModule,
    MatTableModule, MatPaginatorModule,
    MatSortModule, MatSnackBarModule,
    MatProgressBarModule, MatTooltipModule,
    MatDialogModule]
})
export class MaterialModule { }
