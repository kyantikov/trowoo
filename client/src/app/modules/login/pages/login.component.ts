import { Component, OnInit } from '@angular/core';
import { NavigationStart, Router } from '@angular/router';

import { OktaAuthService } from '@okta/okta-angular';

import { AuthService } from '../../../core/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  widget;
  signIn;

  constructor(private oktaAuth: OktaAuthService, private router: Router, private authService: AuthService) {
    // Show the widget when prompted, otherwise remove it from the DOM.
    this.signIn = oktaAuth;
    this.widget = authService.getWidget();
    router.events.forEach(event => {
      if (event instanceof NavigationStart) {
        if (event.url === '/login') {
        } else {
          this.widget.remove();
        }
      }
     }).then(r => console.log(r));
  }

  ngOnInit() {
    this.widget.renderEl(
        {el: '#okta-signin-container'},
        (res) => {
          if (res.status === 'SUCCESS') {
            this.oktaAuth.loginRedirect('/dashboard');
            this.widget.hide();
          }
        },
        err => {throw err; }
      );
  }

}
