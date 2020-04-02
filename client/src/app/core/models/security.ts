import { Quote } from './quote';

export class Security {
  public id: number;
  public ticker: string;
  public name: string;
  public quotes: Quote[];
}
