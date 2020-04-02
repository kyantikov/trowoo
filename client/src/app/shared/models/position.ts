import { Security } from './security';
import { TrailingStop } from './trailingStop';
import { LowPrice } from './lowPrice';
import { HighPrice } from './highPrice';

export interface Position {
  id: number;
  openedDate: Date;
  cost: number;
  security: Security;
  trailingStop: TrailingStop;
  lowPrice: LowPrice;
  highPrice: HighPrice;
}
