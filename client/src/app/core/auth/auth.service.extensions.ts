export class AuthServiceExtensions {

  public static getTokenExpirationFromLocalStorage() {
    const storageIsPopulated = localStorage.length > 0;
    if (storageIsPopulated) {
      const storageData = JSON.parse(localStorage.getItem('okta-token-storage'));
      const accessTokenData = storageData.accessToken;
      return accessTokenData.expiresAt;
    }
    return null;
  }
}
