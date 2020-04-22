import { Injectable } from '@angular/core';
import { NavigationStart, Router } from '@angular/router';

import * as OktaSignIn from '@okta/okta-signin-widget';
import { OktaAuthService } from '@okta/okta-angular';
import appConfig from '../../config/okta.config';

@Injectable()
export class LoginWidgetService {
  widget;

  constructor(private oktaAuth: OktaAuthService, private router: Router) {
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

    // Show the widget when prompted, otherwise remove it from the DOM.
    router.events.forEach(event => {
      if (event instanceof NavigationStart) {
        if (event.url === '/login') {
        } else {
          this.widget.remove();
        }
      }
     }).then(r => console.log(r));
  }

  getWidget() {
    return this.widget;
  }
}
