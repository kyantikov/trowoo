import { Component, OnInit } from '@angular/core';
import * as OktaSignIn from '@okta/okta-signin-widget';

import { OktaAuthService } from "@okta/okta-angular";
import { NavigationStart, Router} from "@angular/router";

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent implements OnInit {

  constructor(private oktaAuth: OktaAuthService, router: Router) {
    // Show the widget when prompted, otherwise remove it from the DOM.
    router.events.forEach(event => {
      if (event instanceof NavigationStart) {
        if (event.url === '/login') {
        } else {
          this.widget.remove();
        }
      }
    });
  }

  widget = new OktaSignIn({
    baseUrl: 'https://dev-793026.okta.com',
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

  ngOnInit() {
    this.widget.renderEl({el: '#okta-signin-container'},
      (res) => {
        if (res.status === 'SUCCESS') {
          this.oktaAuth.loginRedirect('/dashboard', {sessionToken: res.session.token});
          this.widget.hide();
        }
      }, err => {throw err});
  }

}
