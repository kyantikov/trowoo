import { Component, OnInit } from '@angular/core';

import { PortfolioService } from '../../../core/services/portfolio.service';

@Component({
  selector: 'app-all-portfolios-grid',
  templateUrl: './all-positions-grid.component.html',
  styleUrls: ['./all-positions-grid.component.scss']
})
export class AllPositionsGridComponent implements OnInit {
  portfolioData: any;

  constructor(private portfolioService: PortfolioService) { }

  ngOnInit() {
    this.portfolioData = this.portfolioService.store;
  }

}
