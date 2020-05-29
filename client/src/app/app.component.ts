import { Component, OnDestroy, OnInit } from '@angular/core';

import { Observable } from 'rxjs';

import { AuthService } from './core/auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'trowoo';
  public isAuthenticated$: Observable<boolean>;

  constructor(private authService: AuthService) {
  }

  ngOnInit(): void {
    this.isAuthenticated$ = this.authService.authenticationState$;
  }

  ngOnDestroy(): void {
  }
}
