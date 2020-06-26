import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss']
})
export class SideNavComponent implements OnInit {
  navigation: any;

  @Input()
  public isDrawerOpen: boolean;

  constructor(private authService: AuthService, private router: Router) {
    this.navigation = [
      { id: 1, text: 'Portfolios', icon: 'fa fa-folder fa-lg', filePath: '/portfolios'},
      { id: 2, text: 'Positions', icon: 'fa fa-table fa-lg', filePath: '/positions' },
    ];
  }

  ngOnInit() {
  }

  // TODO: fix bug here where when clicking a nav item in drawer,
  //  it closes drawer but this updates value in this component, while the menu updates value in app.component
  loadView(e) {
    this.router.navigate([e.addedItems[0].filePath]);
  }
}
