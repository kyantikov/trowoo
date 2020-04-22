import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DxDataGridModule } from 'devextreme-angular';
import { DxResponsiveBoxModule } from 'devextreme-angular';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './pages/dashboard.component';
import { DataGridComponent } from './components/data-grid/data-grid.component';


@NgModule({
  declarations: [
    DashboardComponent,
    DataGridComponent,
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    DxDataGridModule,
    DxResponsiveBoxModule,
  ]
})
export class DashboardModule { }
