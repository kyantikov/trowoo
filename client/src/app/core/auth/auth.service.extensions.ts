import { UserClaims } from '@okta/okta-angular';

import { User } from '../../shared/models/user.model';

export class AuthServiceExtensions {

  public static parseUserClaims(claims: UserClaims): User {
    if (claims === null) {
      return null;
    }
    return new User(
      claims.sub, claims.given_name, claims.family_name, claims.preferred_username
    );
  }

  // public static getTokenExpirationFromLocalStorage() {
  //   const storageIsPopulated = localStorage.length > 0;
  //   if (storageIsPopulated) {
  //     const storageData = JSON.parse(localStorage.getItem('okta-token-storage'));
  //     const accessTokenData = storageData.accessToken;
  //     return accessTokenData.expiresAt;
  //   }
  //   return null;
  // }
}
