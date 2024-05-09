import { GearboxType } from "../enums/gearbox-type";

export interface Gearbox {
  code: string;
  type: GearboxType;
  gearsCount: number;
  availability: boolean;
}
