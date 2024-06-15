import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {FormControl, Validators} from "@angular/forms";
import {MatSnackBar} from "@angular/material/snack-bar";
import {LoginModel} from "../../_models/loginModel";
import {AuthService} from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  router: Router
  http: HttpClient
  email: FormControl
  snackBar: MatSnackBar
  loginModel: LoginModel

  constructor(http: HttpClient, snackBar: MatSnackBar, router: Router, public authService: AuthService) {
    this.snackBar = snackBar
    this.http = http
    this.router = router
    this.loginModel = new LoginModel()
    this.email = new FormControl('', [Validators.required, Validators.email])
  }

  public sendLoginCredentials(): void {
    this.authService.signIn(this.loginModel);
  }

  public checkInputs(): boolean {
    return this.loginModel.UserName !== '' && this.loginModel.Password !== ''
  }

  ngOnInit(): void {
    if (this.authService.isLoggedIn) {
      this.router.navigate(['subjects'])
    }
  }
}
