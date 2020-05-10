import { Injectable } from '@angular/core';

import { OktaAuthService } from '@okta/okta-angular';
import { UserClaims } from '@okta/okta-angular';
import { BehaviorSubject, from, Subscription } from 'rxjs';

interface User {
  id: string;
  firstName: string;
  lastName: string;
  fullName: string;
}

@Injectable()
export class AuthService {
  user: any;

  constructor(private oktaAuthService: OktaAuthService) {
    this.getUserFromOkta().then();
  }

  async getUserFromOkta() {
    return await this.oktaAuthService.getUser().then((user) => (console.log(user)) );
  }

  parseUserClaims(claims: UserClaims) {
    // let userData = {}
  }
}
