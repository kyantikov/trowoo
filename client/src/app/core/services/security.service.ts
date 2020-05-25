import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import CustomStore from 'devextreme/data/custom_store';

import SecurityCustomStore from './stores/securityCustomStore';
import { Security } from '../../shared/models/trowoo';
import { PublicURLs } from '../../shared/models/public-urls.enum';

@Injectable({
  providedIn: 'root'
})
export class SecurityService {
  store: CustomStore;
  securities: Security[];
  private url = 'https://localhost:5001/' + PublicURLs.security;

  constructor(private http: HttpClient) {
    this.store = new SecurityCustomStore(this.url, this.http);
  }

}
