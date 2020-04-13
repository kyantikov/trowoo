import { Injectable } from '@angular/core';

import { PublicURLs } from '../../../../shared/models/public-urls.enum';
import { Security } from '../../../../shared/models/security';
import CustomStore from 'devextreme/data/custom_store';
import { createStore } from 'devextreme-aspnet-data-nojquery';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SecurityHttpService {
  private baseUrl = 'https://localhost:5001/';
  store: CustomStore;
  // securities: Security;

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get(this.baseUrl + PublicURLs.security);
  }

  getById(id: number) {
    return this.http.get(this.baseUrl + PublicURLs.security + id);
  }

  getByTicker(ticker: string) {
    return this.http.get(this.baseUrl + PublicURLs.security + ticker);
  }

  create(security: Security) {
    return this.http.post(this.baseUrl + PublicURLs.security, security);
  }

  update(updatedSecurity: Security) {
    return this.http.put(this.baseUrl + PublicURLs.security, updatedSecurity);
  }

  delete(id: number) {
    return this.http.delete(this.baseUrl + PublicURLs.security + id);
  }
}
