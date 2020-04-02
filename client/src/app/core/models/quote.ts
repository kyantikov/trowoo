import { Security } from './security';

export class Quote {
  public id: number;
  public quoteDate: Date;
  public open: number;
  public close: number;
  public high: number;
  public low: number;
  public adjustedClose: number;
  public volume: number;
  public dividendAmount: number;
  public splitCoefficient: number;
  public security: Security;
}
