import { Injectable } from '@angular/core';

import * as OktaSignIn from '@okta/okta-signin-widget';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  widget = new OktaSignIn({
    baseUrl: 'https://dev-793026.okta.com',
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
    }
  });

  getWidget() {
    return this.widget;
  }
}
