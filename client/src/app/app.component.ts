import { Component, OnInit } from '@angular/core';

import { AuthService } from './core/auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  public title = 'trowoo';

  public isAuthenticated: boolean;
  public isDrawerOpen = false;

  constructor(private authService: AuthService) {}

  ngOnInit() {
    this.authService.getAuthState().then(state => this.isAuthenticated = state);
  }

  receiveDrawerToggle(e) {
    this.isDrawerOpen = !this.isDrawerOpen;
  }

}
