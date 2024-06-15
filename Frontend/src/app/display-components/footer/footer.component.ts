import {Component} from '@angular/core';
import {AuthService} from "../../auth/auth.service";
import {MatSnackBar} from "@angular/material/snack-bar";
import {Router} from "@angular/router";

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent {
  snackBar: MatSnackBar

  constructor(public authService: AuthService, snackBar: MatSnackBar, public router: Router) {
    this.snackBar = snackBar
  }


  deleteMyself() {
    this.authService.deleteMyself()
      .subscribe((success) => {
        this.snackBar.open("Registration deleted", "OK", {duration: 5000})
        this.authService.doLogout();
      }, (error) => {
        this.snackBar.open("Registration delete failed.", "OK")
      })
  }

  clickMethod() {
    if (confirm("Your registration and ALL your posts and your comments will be deleted forever. They will not be recoverable. Are you sure?")) {
      this.deleteMyself();
    }
  }
}
