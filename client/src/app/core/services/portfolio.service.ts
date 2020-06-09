import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import CustomStore from 'devextreme/data/custom_store';

import PortfolioCustomStore from './stores/portfolio.custom-store';

@Injectable({
  providedIn: 'root'
})
export class PortfolioService {
  store: CustomStore;

  constructor(private http: HttpClient) {
    this.store = new PortfolioCustomStore(this.http);
  }
}
