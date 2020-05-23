import { Injectable } from '@angular/core';

import { BehaviorSubject, Observable } from 'rxjs';

import { OktaAuthService } from '@okta/okta-angular';

import { AuthServiceExtensions } from './auth.service.extensions';
import { User } from '../../shared/models/user.model';

@Injectable()
export class AuthService {
  private userSubject = new BehaviorSubject<User>(null);

  public $isLoggedIn: Observable<boolean>;
  public $user = this.userSubject.asObservable();

  constructor(private oktaAuthService: OktaAuthService) {
  }

  async autoLogin() {
    const accessToken = await this.oktaAuthService.getAccessToken();
    if (accessToken) {
      await this.createUserSubjectFromOktaUserClaims();
      return true;
    }
    return false;
  }

  private async createUserSubjectFromOktaUserClaims() {
    const oktaUserInfo = await this.oktaAuthService.getUser();
    if (oktaUserInfo) {
      const parsedUserObject = AuthServiceExtensions.parseUserClaims(oktaUserInfo);
      this.updateUserSubject(parsedUserObject);
    }
  }

  private updateUserSubject(userObj: User): void {
    this.userSubject.next(userObj);
  }

  private nullifyUserBehaviorSubject(): void {
    this.userSubject.next(null);
  }

}
