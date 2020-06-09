import { HttpClient } from '@angular/common/http';

import CustomStore from 'devextreme/data/custom_store';

import { AllPortfolios } from '../../../shared/models/trowoo';
import { PublicURLs } from '../../../shared/models/public-urls.enum';

// portfolio.store.ts
// portfolio.custom.store.ts
// portfolio.custom-store.ts

export default class PortfolioCustomStore extends CustomStore {
  private url = 'https://localhost:5001/' + PublicURLs.allPortfolios;

  constructor(private http: HttpClient) {
    super({
      key: 'portfolioId',
      load: () => {
        return this.http.get(this.url).toPromise().then((result: AllPortfolios[]) => {
          console.log(result);
          return result;
        });
      },
    });
  }
}
