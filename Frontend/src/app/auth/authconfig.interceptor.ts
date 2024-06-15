//https://www.positronx.io/angular-jwt-user-authentication-tutorial/

import {HttpHandler, HttpInterceptor, HttpRequest,} from '@angular/common/http';
import {Injectable} from '@angular/core';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor() {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const accessToken = localStorage.getItem('forum-token');
    req = req.clone({
      setHeaders: {
        Authorization: 'Bearer ' + accessToken,
      },

    });
    //console.log(accessToken + ' interceptor works!');
    return next.handle(req);
  }
}

