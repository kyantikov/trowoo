import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss']
})
export class SideNavComponent implements OnInit {
 buttonOptions: any;
  isDrawerOpen: boolean;
  navigation: any;

  constructor(private authService: AuthService, private router: Router) {
    this.navigation = [
      { id: 1, text: 'Portfolios', icon: 'folder', filePath: '/portfolios' },
    ];
    this.buttonOptions = {
      icon: 'menu',
      onClick: () => {
        this.isDrawerOpen = !this.isDrawerOpen;
      }
    };
  }

  ngOnInit() {
  }

  loadView(e) {
    console.log(this.router.url);
    this.router.navigate([this.router.url + e.addedItems[0].filePath]);
    this.isDrawerOpen = false;
  }
}
