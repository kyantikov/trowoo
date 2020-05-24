import { Component, OnDestroy, OnInit } from '@angular/core';

import { AuthService } from './core/auth/auth.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'trowoo';
  private authSubscription = new Subscription();


  constructor(private authService: AuthService) {
  }

  ngOnInit(): void {
    this.authSubscription
      .add(this.authService.$isLoggedIn.subscribe(l => console.log(l)))
      .add(this.authService.$user.subscribe(u => console.log(u)));
  }

  ngOnDestroy(): void {
    this.authSubscription.unsubscribe();
  }
}
