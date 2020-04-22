import { Component, OnInit } from '@angular/core';

import { OktaAuthService } from '@okta/okta-angular';

import { LoginWidgetService } from '../login-widget.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  providers: [LoginWidgetService]
})
export class LoginComponent implements OnInit {
  widget;

  constructor(private oktaAuthService: OktaAuthService, private loginWidgetService: LoginWidgetService) {
    this.widget = loginWidgetService.getWidget();
  }

  ngOnInit() {
    this.widget.renderEl(
      {el: '#okta-signin-container'},
      (res) => {
        if (res.status === 'SUCCESS') {
          this.oktaAuthService.loginRedirect('/dashboard');
          this.widget.hide();
        }
      },
      err => { throw err; }
    );
  }

}
