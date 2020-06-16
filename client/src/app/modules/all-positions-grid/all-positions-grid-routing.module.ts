import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AllPositionsGridComponent } from './pages/all-positions-grid.component';

const routes: Routes = [
  { path: '', component: AllPositionsGridComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AllPositionsGridRoutingModule { }
