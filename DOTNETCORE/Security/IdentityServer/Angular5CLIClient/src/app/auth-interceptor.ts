import { AuthService } from './auth.service';
import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs/observable';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private _authService: AuthService) {  }

  intercept (req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = this._authService.getAccessToken();
    if (token) {
      const authReq = req.clone({
        headers: req.headers.set('Authorization', 'Bearer ' + token)
      });
      return next.handle(authReq);
    } else {
      return next.handle(req);
    }
  }
}
