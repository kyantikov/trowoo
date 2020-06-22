import { HttpClient } from '@angular/common/http';

import CustomStore from 'devextreme/data/custom_store';

import { AuthService } from '../../auth/auth.service';
import { Portfolio } from '../../../shared/models/trowoo';
import { PublicURLs } from '../../../shared/models/public-urls.enum';

export default class PortfolioCustomStore extends CustomStore {
  private loadedData: Portfolio[];
  private url = 'https://localhost:5001/' + PublicURLs.portfolios;

  constructor(private http: HttpClient, private authService: AuthService) {
    super({
      key: 'id',
      load: () => {
        return this.http.get(this.url).toPromise().then( (result: Portfolio[]) => {
          this.loadedData = result;
          return result;
        });
      },
      insert: async values => {
        values.userId = (await this.authService.getUser()).id;
        return this.http.post(this.url, values).toPromise();
      },
      update: (key, values) => {
        const matchedPortfolio = this.loadedData.filter( (p: Portfolio) => p.id === key )[0];
        const updatedPortfolio = { ...matchedPortfolio, ...values };
        return this.http.put(this.url, updatedPortfolio).toPromise();
      },
      remove: key => {
        return this.http.delete(this.url + key).toPromise();
      }
    });
  }
}
