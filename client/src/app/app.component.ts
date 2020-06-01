import { Component, OnInit } from '@angular/core';

import { AuthService } from './core/auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  public title = 'trowoo';

  public isAuthenticated$: boolean;

  constructor(private authService: AuthService) {}

  async ngOnInit(): Promise<void> {
    this.authService.getAuthState().then(state => this.isAuthenticated$ = state);
  }

}
