import {Component, Input, OnChanges, OnInit, SimpleChanges} from '@angular/core';

import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})

export class HeaderComponent implements OnInit {
  private userButtonOptions: any;

  @Input()
  public isAuth: boolean;

  constructor(private authService: AuthService) {
    this.userButtonOptions = {
      icon: 'arrowup',
      onClick: () => {
        this.authService.logout('/login');
      }
    };
  }

  ngOnInit(): void {
  }

}
