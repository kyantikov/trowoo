import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {Router} from '@angular/router';

// TODO: consider moving HeaderOption interface to its own service file and use that service as a provider here

interface HeaderOption {
  text: string;
  icon: string;
  url?: string;
}

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
  encapsulation: ViewEncapsulation.None
})

export class HeaderComponent implements OnInit {
  navItems: HeaderOption[];

  constructor(private router: Router) { }

  ngOnInit() {
    this.navItems = [
      {text: 'Login', icon: 'user'},
      {text: 'Home', icon: 'home'}
    ];
  }

  onTabChange(e) {
    const path = e.itemData.text.toLowerCase();
    this.redirectToPath(path);
  }

  redirectToPath(path: string) {
    this.router.navigate([path]);
  }


}
