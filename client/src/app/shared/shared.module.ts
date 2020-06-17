import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DxDataGridModule } from 'devextreme-angular';


@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  exports: [
    CommonModule,
    DxDataGridModule,
  ],
})
export class SharedModule { }
