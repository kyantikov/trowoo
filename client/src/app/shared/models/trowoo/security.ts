import { Quote } from './quote';

export interface Security {
  id: number;
  ticker: string;
  name: string;
  quotes?: Quote[];
}
