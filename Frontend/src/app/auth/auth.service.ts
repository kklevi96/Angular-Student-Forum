//https://www.positronx.io/angular-jwt-user-authentication-tutorial/

import {HttpClient, HttpErrorResponse, HttpHeaders,} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable, throwError} from 'rxjs';
import {catchError, map} from 'rxjs/operators';

import {Router} from '@angular/router';
import {MatSnackBar} from "@angular/material/snack-bar";

export type User = {
  id: string;
  userName: string;
  email: string
  firstName: string;
  lastName: string;
  roles: string[];
};

export type LoginResponse = {
  expiration: string;
  id: string;
  token: string;
};

export type RegisterRequest = {
  Email: string;
  FirstName: string;
  LastName: string;
  Password: string;
  Username: string;
};

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  headers = new HttpHeaders().set('Content-Type', 'application/json');
  public currentUser: User | undefined = undefined;
  loading = false;
  signInError = '';
  snackBar: MatSnackBar
  clickCount: number = 0;
  requiredClicks: number = 10;
  deleteAllowed: boolean = false;


  constructor(private http: HttpClient, public router: Router, snackBar: MatSnackBar) {
    this.snackBar = snackBar
  }

  get isLoggedIn(): boolean {
    let authToken = localStorage.getItem('forum-token');
    const isLoggedIn = authToken !== null;

    if (isLoggedIn && !this.currentUser && !this.loading) {
      this.loading = true;
      this.getUserProfile().subscribe(
        (res) => {
          this.currentUser = res;
        },
        (err) => {
          this.doLogout();
        }
      );
    }

    return isLoggedIn;
  }

  // Sign-up
  signUp(user: RegisterRequest): Observable<any> {
    let api = 'https://localhost:7015/api/Auth';
    return this.http.put(api, user).pipe(catchError(this.handleError));
  }

  // Sign-in
  signIn(user: { UserName: string; Password: string }) {
    this.signInError = '';
    return this.http
      .post<LoginResponse>('https://localhost:7015/api/Auth', user)
      .subscribe(
        (res: any) => {
          localStorage.setItem('forum-token', res.token);
          return this.getUserProfile().subscribe((res) => {
            this.currentUser = res;
            this.router.navigate(['/home']);
            console.log(this.getToken());
          });
        },
        (error) => {
          this.signInError = error;
          this.snackBar.open('Login failed', 'Close', {duration: 5000})

        }
      );
  }

  deleteMyself() {
    return this.http.delete('https://localhost:7015/api/Auth/');
  }

  delegateAdmin() {
    return this.http.patch('https://localhost:7015/api/Auth/DelegateAdmin', '');
  }

  removeAdmin() {
    return this.http.patch('https://localhost:7015/api/Auth/RemoveAdmin', '');
  }

  getToken() {
    return localStorage.getItem('forum-token');
  }

  doLogout() {
    let removeToken = localStorage.removeItem('forum-token');
    this.clickCount = 0;
    this.currentUser = undefined;
    this.deleteAllowed = false;
    if (removeToken == null) {
      this.router.navigate(['/home']);
    }
  }

  // User profile
  getUserProfile(): Observable<User> {
    let api = 'https://localhost:7015/api/Auth';
    return this.http.get<User>(api, {headers: this.headers}).pipe(
      map((res) => {
        console.log(res);
        return res as User;
      }),
      catchError(this.handleError)
    );
  }

  // Error
  handleError(error: HttpErrorResponse) {
    let msg = '';
    if (error.error instanceof ErrorEvent) {
      // client-side error
      msg = error.error.message;
    } else {
      // server-side error
      msg = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(() => new Error(msg));
  }

  isAdmin(): boolean {
    if (!this.currentUser)
      return false;
    return this.currentUser.roles?.includes("Admin");
  }


}
