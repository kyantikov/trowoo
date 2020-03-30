import { Injectable } from '@angular/core';

import * as OktaSignIn from '@okta/okta-signin-widget';
import { OktaAuthService } from '@okta/okta-angular';
import appConfig from '../../app.config';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  widget;

  constructor(private oktaAuth: OktaAuthService) {
    this.widget = new OktaSignIn({
      baseUrl: appConfig.issuer.split('/oauth2')[0],
      clientId: appConfig.clientId,
      issuer: appConfig.issuer,
      redirectUri: appConfig.redirectUri,
      logo: '',
      registration: {
        parseSchema: (schema, onSuccess, onFailure) => {
          // handle parseSchema callback
          onSuccess(schema);
        },
        preSubmit: (postData, onSuccess, onFailure) => {
          // handle preSubmit callback
          onSuccess(postData);
        },
        postSubmit: (response, onSuccess, onFailure) => {
          // handle postsubmit callback
          onSuccess(response);
        }
      },
      features: {
        registration: true,
      },
    });
  }

  getWidget() {
    return this.widget;
  }
}
