import { Injectable } from '@angular/core';
import { NavigationStart, Router } from '@angular/router';

import * as OktaSignIn from '@okta/okta-signin-widget';
import loginWidgetConfig from './login-widget.config';

@Injectable()
export class LoginWidgetService {
  widget;

  constructor(private router: Router) {
    this.widget = new OktaSignIn(loginWidgetConfig);

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
