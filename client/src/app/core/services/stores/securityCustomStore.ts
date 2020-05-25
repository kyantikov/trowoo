import { HttpClient } from '@angular/common/http';

import CustomStore from 'devextreme/data/custom_store';

import { Security } from '../../../shared/models/trowoo';

export default class SecurityCustomStore extends CustomStore {
  private loadedData: Security[];

  constructor(private url: string, private http: HttpClient) {
    super({
      key: 'id',
      load: () => {
        return this.http.get(this.url)
          .toPromise()
          .then( (result: any) => {
            this.loadedData = result;
            return result;
          });
      },
      insert: values => {
        return this.http.post(this.url, values).toPromise();
      },
      update: (key, values) => {
        const matchedSecurity = this.loadedData.filter(e => e.id === key)[0];
        const updatedSecurity = {...matchedSecurity, ...values};
        return this.http.put(this.url, updatedSecurity).toPromise();
      },
      remove: key => {
        return this.http.delete(this.url + key).toPromise();
      }
    });
  }
}
