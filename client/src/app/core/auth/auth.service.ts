import { Injectable } from '@angular/core';

import {BehaviorSubject, from, Observable, of} from 'rxjs';

import { OktaAuthService } from '@okta/okta-angular';

import { AuthServiceExtensions } from './auth.service.extensions';
import { User } from '../../shared/models/user.model';

@Injectable()
export class AuthService {
  private userBehaviorSubject = new BehaviorSubject<User>(null);

  public isLoggedIn = new Observable<boolean>();
  public $user = new Observable<User>();

  constructor(private oktaAuthService: OktaAuthService) {
    this.autoLogin().then(successfulLogin => {
      this.isLoggedIn = of(successfulLogin);
      this.$user = this.userBehaviorSubject.asObservable();
    });
  }

  async autoLogin() {
    const accessToken = await this.oktaAuthService.getAccessToken();
    if (accessToken) {
      await this.createUserBehaviorSubjectFromOktaUserClaims();
      return true;
    }
  }

  private async createUserBehaviorSubjectFromOktaUserClaims() {
    const oktaUserInfo = await this.oktaAuthService.getUser();
    if (oktaUserInfo) {
      const parsedUserObject = AuthServiceExtensions.parseUserClaims(oktaUserInfo);
      this.updateUserBehaviorSubject(parsedUserObject);
    }
  }


  private updateUserBehaviorSubject(userObj: User): void {
    this.userBehaviorSubject.next(userObj);
  }

  private nullifyUserBehaviorSubject(): void {
    this.userBehaviorSubject.next(null);
  }

}
