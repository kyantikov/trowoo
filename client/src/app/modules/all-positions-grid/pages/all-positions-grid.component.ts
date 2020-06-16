import { Component, OnInit } from '@angular/core';

import { PortfolioService } from '../../../core/services/portfolio.service';

@Component({
  selector: 'app-all-portfolios-grid',
  templateUrl: './all-portfolios-grid.component.html',
  styleUrls: ['./all-portfolios-grid.component.scss']
})
export class AllPortfoliosGridComponent implements OnInit {
  portfolioData: any;

  constructor(private portfolioService: PortfolioService) { }

  ngOnInit() {
    this.portfolioData = this.portfolioService.store;
  }

}
