import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})

export class HeaderComponent implements OnInit {

  @Input()
  public isAuth: boolean;

  @Output()
  public drawerToggle = new EventEmitter<boolean>();

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
  }

  onDrawerToggle(e) {
    // console.log(e);
    this.drawerToggle.emit(e);
  }

  onLogout() {
    this.authService.logout('/login');
  }
}
