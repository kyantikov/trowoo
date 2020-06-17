import { NgModule } from '@angular/core';

import { SharedModule } from '../../shared/shared.module';

import { PortfoliosManagerRoutingModule } from './portfolios-manager-routing.module';
import { PortfoliosManagerComponent } from './portfolios-manager.component';


@NgModule({
  declarations: [PortfoliosManagerComponent],
  imports: [
    SharedModule,
    PortfoliosManagerRoutingModule,
  ],
  exports: [
    PortfoliosManagerComponent,
  ],
})
export class PortfoliosManagerModule { }
