import { Position } from './position';

export interface Portfolio {
  id: number;
  name: string;
  userId: string;
  positions?: Position[];
}
