import { Injectable } from '@angular/core';

import {from, Observable} from 'rxjs';
import { map, switchMap } from 'rxjs/operators';

import { OktaAuthService } from '@okta/okta-angular';

import { AuthServiceExtensions } from './auth.service.extensions';
import { User } from '../../shared/models/user.model';


@Injectable()
export class AuthService {
  public user$: Observable<User>;

  constructor(private oktaAuthService: OktaAuthService) {
    this.user$ = this.oktaAuthService.$authenticationState
      .pipe(
        switchMap(state => state ? this.oktaAuthService.getUser() : null),
        map(user => AuthServiceExtensions.parseUserClaims(user)),
      );
  }

  logout(url: string) {
    this.oktaAuthService.logout(url);
  }

  async getAuthState() {
    return await this.oktaAuthService.isAuthenticated();
  }
}
