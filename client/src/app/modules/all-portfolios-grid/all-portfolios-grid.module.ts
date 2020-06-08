import { NgModule } from '@angular/core';

import { DxDataGridModule } from 'devextreme-angular';

import { SharedModule } from '../../shared/shared.module';
import { AllPortfoliosGridRoutingModule } from './all-portfolios-grid-routing.module';

import { AllPortfoliosGridComponent } from './pages/all-portfolios-grid.component';


@NgModule({
  declarations: [AllPortfoliosGridComponent],
  imports: [
    SharedModule,
    AllPortfoliosGridRoutingModule,
    DxDataGridModule,
  ],
  exports: [
    AllPortfoliosGridComponent,
  ]
})
export class AllPortfoliosGridModule { }
