import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})

export class HeaderComponent implements OnInit {
  userButtonOptions: any;
  menuButtonOptions: any;

  @Input()
  public isAuth: boolean;

  @Output()
  public drawerToggle = new EventEmitter<boolean>();

  constructor(private authService: AuthService) {
    this.userButtonOptions = {
      icon: 'arrowup',
      onClick: () => this.authService.logout('/login')
    };
    this.menuButtonOptions = {
      icon: 'menu',
      onClick: () => this.drawerToggle.emit(true)
    };

  }

  ngOnInit(): void {
  }

}
