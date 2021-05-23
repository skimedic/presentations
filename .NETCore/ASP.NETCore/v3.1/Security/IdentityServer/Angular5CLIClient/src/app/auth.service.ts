import { Injectable } from '@angular/core';
import { UserManager, User } from 'oidc-client';

@Injectable()
export class AuthService {
  userManager: UserManager;
  user: User;

  constructor() {
    const config = {
      authority: 'http://localhost:5000',
      client_id: 'angular-cli-client',
      redirect_uri: 'http://localhost:4200/?callback',
      response_type: 'id_token token',
      scope: 'openid profile myApi',
      post_logout_redirect_uri: 'http://localhost:4200/'
    };
    this.userManager = new UserManager(config);
  }

  login() {
    this.userManager.signinRedirect();
  }

  logout() {
    this.userManager.signoutRedirect();
  }

  getAccessToken() {
    return this.user ? this.user.access_token : null;
  }

  initializeUser() {
    if (document.URL.indexOf('?callback') >= 0) {
      this.userManager.signinRedirectCallback().then(user => {
        this.user = user;
        window.location.href = '/';
      });
    } else {
      this.userManager.getUser().then(user => this.user = user);
    }

  }
}
