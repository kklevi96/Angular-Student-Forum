import {Component} from '@angular/core';
import {AuthService} from "../../auth/auth.service";
import {MatSnackBar} from "@angular/material/snack-bar";
import {ThemePalette} from "@angular/material/core";

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent {
  auth: AuthService
  snackBar: MatSnackBar

  constructor(auth: AuthService, snackBar: MatSnackBar) {
    this.snackBar = snackBar;
    this.auth = auth
  }

  public delegateAdmin() {
    this.auth.delegateAdmin()
      .subscribe((success) => {
          this.snackBar.open("You are now admin! Log in again to take effects.", "Close", {duration: 5000});
          this.auth.doLogout()
        },
        (error) => {
          this.snackBar.open("Delegating yourself admin failed.")
        })
  }

  public removeAdmin() {
    this.auth.removeAdmin()
      .subscribe((success) => {
          this.snackBar.open("You are no longer an admin! Log in again to take effects.", "Close", {duration: 5000});
          this.auth.doLogout()
        },
        (error) => {
          this.snackBar.open("Removing yourself as admin failed.")
        })
  }

  public counter() {
    if (this.auth.currentUser) {
      this.auth.clickCount++;
      if (this.auth.requiredClicks - this.auth.clickCount > 1 && this.auth.requiredClicks - this.auth.clickCount < 4)
        this.snackBar.open(this.auth.requiredClicks - this.auth.clickCount + " clicks away...", "", {duration: 200});
      if (this.auth.requiredClicks - this.auth.clickCount === 1)
        this.snackBar.open(this.auth.requiredClicks - this.auth.clickCount + " click away...", "", {duration: 200});
      if (this.auth.requiredClicks - this.auth.clickCount === 0)
        this.snackBar.open("You can promote yourself to be an admin! ;)", "", {duration: 1500});
    }
  }

  public buttonColor(): ThemePalette {
    if (this.auth.requiredClicks - this.auth.clickCount === 1)
      return 'warn';
    if (this.auth.requiredClicks - this.auth.clickCount < 4)
      return 'accent';
    return 'primary';
  }
}
