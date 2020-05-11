import { Injectable } from '@angular/core';

import { BehaviorSubject } from 'rxjs';

import { OktaAuthService, UserClaims } from '@okta/okta-angular';

import { AuthServiceExtensions } from './auth.service.extensions';
import { User } from '../../shared/models/user.model';

@Injectable()
export class AuthService {
  user = new BehaviorSubject<User>(null);

  constructor(private oktaAuthService: OktaAuthService) {
    this.getUserFromOkta().then(oktaUserInfo => {
      const parsedUserInfo = this.parseUserClaims(oktaUserInfo);
      this.user.next(parsedUserInfo);
    });
  }

  async getUserFromOkta() {
    return await this.oktaAuthService.getUser();
  }

  parseUserClaims(claims: UserClaims) {
    const tokenExp = AuthServiceExtensions.getTokenExpirationFromLocalStorage();
    return new User(
      claims.sub, claims.given_name, claims.family_name, claims.preferred_username, tokenExp,
    );
  }

}
