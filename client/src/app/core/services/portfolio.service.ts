import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import CustomStore from 'devextreme/data/custom_store';

import PortfolioCustomStore from './stores/portfolio.custom-store';
import {AuthService} from '../auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class PortfolioService {
  store: CustomStore;

  constructor(private http: HttpClient, private authService: AuthService) {
    this.store = new PortfolioCustomStore(this.http, this.authService);
  }
}
