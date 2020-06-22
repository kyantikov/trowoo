import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import CustomStore from 'devextreme/data/custom_store';

import SecurityCustomStore from './stores/security.custom-store';

@Injectable({
  providedIn: 'root'
})
export class SecurityService {
  store: CustomStore;

  constructor(private http: HttpClient) {
    this.store = new SecurityCustomStore(this.http);
  }

}
