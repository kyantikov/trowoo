import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AllPortfoliosGridComponent } from './pages/all-portfolios-grid.component';

const routes: Routes = [
  { path: '', component: AllPortfoliosGridComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AllPortfoliosGridRoutingModule { }
