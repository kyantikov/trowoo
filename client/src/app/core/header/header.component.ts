import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})

export class HeaderComponent implements OnInit {
  private userButtonOptions: any;

  constructor(private router: Router, private authService: AuthService) {
    this.userButtonOptions = {
      icon: 'arrowup',
      onClick: () => {
        this.authService.logout('/login');
      }
    };
  }

  ngOnInit() {
  }

}
