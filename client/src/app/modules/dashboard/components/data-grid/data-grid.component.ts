import { Component, OnInit } from '@angular/core';

import CustomStore from 'devextreme/data/custom_store';

import { SecurityService } from '../../../../core/services/security.service';

@Component({
  selector: 'app-data-grid',
  templateUrl: './data-grid.component.html',
  styleUrls: ['./data-grid.component.scss']
})
export class DataGridComponent implements OnInit {
  dataSource: any;

  constructor(private securityService: SecurityService) { }

  ngOnInit() {
    this.dataSource = this.securityService.store;
  }

}
