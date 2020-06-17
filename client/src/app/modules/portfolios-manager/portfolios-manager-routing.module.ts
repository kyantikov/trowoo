import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PortfoliosManagerComponent } from './portfolios-manager.component';

const routes: Routes = [
  { path: '', component: PortfoliosManagerComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PortfoliosManagerRoutingModule { }
