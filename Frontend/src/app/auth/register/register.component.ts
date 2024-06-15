import {HttpClient} from '@angular/common/http';
import {Component, OnInit} from '@angular/core';
import {FormControl, Validators} from '@angular/forms';
import {MatSnackBar} from '@angular/material/snack-bar';
import {Router} from '@angular/router';
import {RegisterModel} from '../../_models/registermodel';
import {AuthService} from "../auth.service";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  router: Router
  http: HttpClient
  email: FormControl
  snackBar: MatSnackBar
  registerModel: RegisterModel
  acceptTermsAndConditions: boolean

  constructor(http: HttpClient, snackBar: MatSnackBar, router: Router, private authService: AuthService) {
    this.snackBar = snackBar
    this.http = http
    this.router = router
    this.acceptTermsAndConditions = false
    this.registerModel = new RegisterModel()
    this.email = new FormControl('', [Validators.required, Validators.email])
  }

  public getEmailErrorMessage(): string {
    if (this.email.hasError('required')) {
      return 'You must enter a value!';
    }

    return this.email.hasError('email') ? 'Not a valid email!' : '';
  }

  public sendRegisterCredentials(): void {
    console.log(this.registerModel);
    this.authService.signUp(this.registerModel)
      .subscribe(
        (success) => {
          this.snackBar
            .open('Registration was successful!', 'Close', {duration: 5000})
            .afterDismissed()
            .subscribe(() => {
              this.router.navigate(['/login']);
            });
        },
        (error) => {
          this.snackBar.open('Registration failed. A user with this email or username may already exist.', 'Close', {duration: 5000});
        }
      );
  }

  public checkInputs(): boolean {
    return this.registerModel.Username !== '' && this.registerModel.Password !== '' && this.registerModel.FirstName !== '' && this.registerModel.LastName !== ''
  }

  ngOnInit(): void {
    if (this.authService.isLoggedIn) {
      this.router.navigate(['/subjects'])
    }
  }
}
