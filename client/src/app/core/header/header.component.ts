import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})

export class HeaderComponent implements OnInit {
  userButtonOptions: any;

  constructor(private router: Router) {
    this.userButtonOptions = {
      icon: 'user',
      onClick: () => {
        console.log('did something');
      }
    };
  }


  ngOnInit() {
  }

  onTabChange(e) {
    const path = e.itemData.text.toLowerCase();
    this.redirectToPath(path);
  }

  redirectToPath(path: string) {
    this.router.navigate([path]);
  }


}
