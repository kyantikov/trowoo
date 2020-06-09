import { Position } from './position';

export interface AllPortfolios {
  id: number;
  name: string;
  userId: string;
  positions: Position[];
}
