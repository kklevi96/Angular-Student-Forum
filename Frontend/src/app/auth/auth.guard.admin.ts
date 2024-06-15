//https://www.positronx.io/angular-jwt-user-authentication-tutorial/

import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from '@angular/router';
import {Observable} from 'rxjs';
import {AuthService} from "./auth.service";

@Injectable({
  providedIn: 'root'
})
export class AuthGuardAdmin implements CanActivate {
  constructor(
    public authService: AuthService,
    public router: Router
  ) {
  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    if (!this.authService.isAdmin()) {
      this.router.navigate(['subjects'])
    }
    return true;
  }
}
