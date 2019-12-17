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
      parseSchema: function(schema, onSuccess, onFailure) {
        // handle parseSchema callback
        onSuccess(schema);
      },
      preSubmit: function (postData, onSuccess, onFailure) {
        // handle preSubmit callback
        onSuccess(postData);
      },
      postSubmit: function (response, onSuccess, onFailure) {
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
