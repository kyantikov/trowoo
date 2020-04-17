import { HttpClient } from '@angular/common/http';

import CustomStore from 'devextreme/data/custom_store';

import { HighPrice, LowPrice, Portfolio, Quote, Security, TrailingStop } from './trowoo';


interface TrowooData extends Security, Quote, Position, Portfolio, HighPrice, LowPrice, TrailingStop { }

export default class TrowooCustomStore extends CustomStore {
  private loadedData: TrowooData[];

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
        return this.http.post(this.url, values)
          .toPromise()
          .then(result => {
            return result;
          });
      },
      // TODO: fix 'e.id' error below ----> fixed with interface above:: is this correct??
      // !! may not work for batch updating
      update: (key, values) => {
        // console.log(values);
        const matchedEntity = this.loadedData.filter(e => e.id === key).pop();
        // console.log(matchedEntity);
        const updatedSecurity = {...matchedEntity, ...values};
        // console.log(updatedSecurity);
        return this.http.put(this.url, updatedSecurity)
          .toPromise()
          .then(result => {
            return result;
          });
      },
      remove: key => {
        return this.http.delete(this.url + key)
          .toPromise()
          .then(result => {
            return result;
          });
      }
    });
  }
}
