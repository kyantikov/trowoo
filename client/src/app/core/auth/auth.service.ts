import { Injectable } from '@angular/core';

import { BehaviorSubject } from 'rxjs';

import { OktaAuthService, UserClaims } from '@okta/okta-angular';

import { AuthServiceExtensions } from './auth.service.extensions';
import { User } from '../../shared/models/user.model';

@Injectable()
export class AuthService {
  user = new BehaviorSubject<User>(null);

  constructor(private oktaAuthService: OktaAuthService) {
    this.getUserFromOkta().then((oktaUserInfo: UserClaims) => {
      const parsedUserObject = AuthServiceExtensions.parseUserClaims(oktaUserInfo);
      this.user.next(parsedUserObject);
    });
  }

  async getUserFromOkta() {
    return await this.oktaAuthService.getUser();
  }


}
