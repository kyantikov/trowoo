import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { AdminUrls } from '../../../shared/models/admin-urls.enum';

@Injectable({
  providedIn: 'root'
})
export class AdminHttpService {
  private baseUrl = 'https://localhost:5001/' ;

  constructor(private http: HttpClient) { }

  retrieveQuotesFromAlphaVantage() {
    return this.http.get(this.baseUrl + AdminUrls.quote);
  }
}
