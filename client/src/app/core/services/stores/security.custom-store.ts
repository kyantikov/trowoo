import { HttpClient } from '@angular/common/http';

import CustomStore from 'devextreme/data/custom_store';

import { Security } from '../../../shared/models/trowoo';
import { PublicURLs } from '../../../shared/models/public-urls.enum';

export default class SecurityCustomStore extends CustomStore {
  private loadedData: Security[];
  private url = 'https://localhost:5001/' + PublicURLs.security;

  constructor(private http: HttpClient) {
    super({
      key: 'id',
      load: () => {
        return this.http.get(this.url).toPromise().then( (result: Security[]) => {
          this.loadedData = result;
          return result;
        });
      },
      insert: values => {
        return this.http.post(this.url, values).toPromise();
      },
      update: (key, values) => {
        const matchedSecurity = this.loadedData.filter( (s: Security) => s.id === key )[0];
        const updatedSecurity = { ...matchedSecurity, ...values };
        return this.http.put(this.url, updatedSecurity).toPromise();
      },
      remove: key => {
        return this.http.delete(this.url + key).toPromise();
      }
    });
  }
}
