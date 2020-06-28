import { NgModule } from '@angular/core';

import { DxAutocompleteModule, DxDateBoxModule } from 'devextreme-angular';

import { SharedModule } from '../../shared/shared.module';
import { AllPositionsGridRoutingModule } from './all-positions-grid-routing.module';

import { AllPositionsGridComponent } from './pages/all-positions-grid.component';


@NgModule({
  declarations: [
    AllPositionsGridComponent
  ],
  imports: [
    SharedModule,
    AllPositionsGridRoutingModule,
    DxAutocompleteModule,
    DxDateBoxModule,
  ],
})
export class AllPositionsGridModule { }
