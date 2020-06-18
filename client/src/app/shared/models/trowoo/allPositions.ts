import { Position } from './position';

export interface AllPositions {
  portfolioId: number;
  portfolioName: string;
  portfolioUserId: string;
  positions: Position[];
}
