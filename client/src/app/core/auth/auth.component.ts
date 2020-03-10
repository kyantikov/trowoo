import { Component, OnInit } from '@angular/core';
import { NavigationStart, Router } from '@angular/router';

import { OktaAuthService } from '@okta/okta-angular';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent implements OnInit {
  widget;

  constructor(private oktaAuth: OktaAuthService, private router: Router, private authService: AuthService) {
    // Show the widget when prompted, otherwise remove it from the DOM.
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
    this.widget.renderEl({el: '#widget-container'},
      (res) => {
        if (res.status === 'SUCCESS') {
          this.oktaAuth.loginRedirect('/dashboard', {sessionToken: res.session.token});
          this.widget.hide();
        }
      }, err => {throw err; });
  }

}
