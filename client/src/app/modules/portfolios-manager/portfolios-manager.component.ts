import { Component, OnInit } from '@angular/core';
import {PortfolioService} from '../../core/services/portfolio.service';

@Component({
  selector: 'app-portfolios-manager',
  templateUrl: './portfolios-manager.component.html',
  styleUrls: ['./portfolios-manager.component.scss']
})
export class PortfoliosManagerComponent implements OnInit {
  portfolioData: any;

  constructor(private portfolioService: PortfolioService) { }

  ngOnInit() {
    this.portfolioData = this.portfolioService.store;
  }

}
