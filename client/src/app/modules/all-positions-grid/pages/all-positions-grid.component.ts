import { Component, OnInit } from '@angular/core';

import { PositionService } from '../../../core/services/position.service';

@Component({
  selector: 'app-all-portfolios-grid',
  templateUrl: './all-positions-grid.component.html',
  styleUrls: ['./all-positions-grid.component.scss']
})
export class AllPositionsGridComponent implements OnInit {
  portfolioData: any;

  constructor(private positionService: PositionService) { }

  ngOnInit() {
    this.portfolioData = this.positionService.store;
  }

}
