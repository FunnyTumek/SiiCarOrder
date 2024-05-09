import { EngineType } from "../enums/engine-type";

export interface Engine {
  code: string;
  name: string;
  type: EngineType;
  capacity: number;
  power: number;
  availability: boolean;
}
