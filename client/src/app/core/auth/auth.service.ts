import { Injectable } from '@angular/core';

import { from } from 'rxjs';

import { OktaAuthService } from '@okta/okta-angular';

import { AuthServiceExtensions } from './auth.service.extensions';
import { User } from '../../shared/models/user.model';


@Injectable()
export class AuthService {

  constructor(private oktaAuthService: OktaAuthService) {}

  async getUser(): Promise<User> {
    return AuthServiceExtensions.parseUserClaims(await this.oktaAuthService.getUser());
  }

  getAccessToken() {
    return from(this.oktaAuthService.getAccessToken());
  }

  async getAuthState() {
    return await this.oktaAuthService.isAuthenticated();
  }

  logout(url: string) {
    this.oktaAuthService.logout(url);
  }
}
