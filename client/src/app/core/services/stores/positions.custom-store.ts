import { HttpClient } from '@angular/common/http';

import CustomStore from 'devextreme/data/custom_store';

import { AllPositions } from '../../../shared/models/trowoo';
import { PublicURLs } from '../../../shared/models/public-urls.enum';

export default class PositionsCustomStore extends CustomStore {
  private url = 'https://localhost:5001/' + PublicURLs.allPositions;

  constructor(private http: HttpClient) {
    super({
      key: 'portfolioId',
      load: () => {
        return this.http.get(this.url).toPromise().then((result: AllPositions[]) => {
          console.log(result);
          return result;
        });
      },
    });
  }
}
