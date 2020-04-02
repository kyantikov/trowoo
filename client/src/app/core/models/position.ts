import { Security } from './security';
import { TrailingStop } from './trailingStop';
import { LowPrice } from './lowPrice';
import { HighPrice } from './highPrice';

export class Position {
  public id: number;
  public openedDate: Date;
  public cost: number;
  public security: Security;
  public trailingStop: TrailingStop;
  public lowPrice: LowPrice;
  public highPrice: HighPrice;
}
