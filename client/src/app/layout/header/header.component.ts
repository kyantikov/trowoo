import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

// TODO: consider moving HeaderOption class to its own service file and use that service as a provider here

class HeaderOption {
  text: string;
  icon: string;
}

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
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
    this.redirect(path);
  }

  redirect(path: string) {
    this.router.navigate([path]);
  }


}
