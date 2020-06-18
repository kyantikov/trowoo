import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import CustomStore from 'devextreme/data/custom_store';

import PositionsCustomStore from './stores/positions.custom-store';

@Injectable({
  providedIn: 'root'
})
export class PositionService {
  store: CustomStore;

  constructor(private http: HttpClient) {
    this.store = new PositionsCustomStore(this.http);
  }
}
