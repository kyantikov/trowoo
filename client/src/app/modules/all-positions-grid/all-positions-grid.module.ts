import { NgModule } from '@angular/core';

import { DxDataGridModule, DxButtonModule } from 'devextreme-angular';

import { SharedModule } from '../../shared/shared.module';
import { AllPositionsGridRoutingModule } from './all-positions-grid-routing.module';

import { AllPositionsGridComponent } from './pages/all-positions-grid.component';


@NgModule({
  declarations: [AllPositionsGridComponent],
  imports: [
    SharedModule,
    AllPositionsGridRoutingModule,
    DxDataGridModule,
    DxButtonModule,
  ],
  exports: [
    AllPositionsGridComponent,
  ]
})
export class AllPositionsGridModule { }
