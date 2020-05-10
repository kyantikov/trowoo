import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import CustomStore from 'devextreme/data/custom_store';

import TrowooCustomStore from '../../shared/models/trowooCustomStore';
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
    this.store = new TrowooCustomStore(this.url, this.http);
  }

}
