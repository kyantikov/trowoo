import { Security } from './security';

export interface Quote {
  id: number;
  quoteDate: Date;
  open: number;
  close: number;
  high: number;
  low: number;
  adjustedClose: number;
  volume: number;
  dividendAmount: number;
  splitCoefficient: number;
  security: Security;
}
