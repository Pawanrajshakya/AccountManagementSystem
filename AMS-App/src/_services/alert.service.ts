import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarVerticalPosition, MatSnackBarHorizontalPosition } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor(private snackBar: MatSnackBar) { }

  horizontalPosition: MatSnackBarHorizontalPosition = 'center';
  verticalPosition: MatSnackBarVerticalPosition = 'top';

  showAlert(message: string, action: string = '', displayDuration: number = 1000) {
    this.snackBar.open(message, action, {
      duration: displayDuration,
      horizontalPosition: this.horizontalPosition,
      verticalPosition: this.verticalPosition,
    });
  }

}
