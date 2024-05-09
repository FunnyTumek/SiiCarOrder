import { AdditionalEquipment } from "./additional-equipment";
import { Brand } from "./brand";
import { Class } from "./class";
import { Color } from "./color";
import { Engine } from "./engine";
import { EquipmentVersion } from "./equipment-version";
import { Gearbox } from "./gearbox";
import { Interior } from "./interior";
import { Model } from "./model";


export type DictionaryItem = Brand |
  Model |
  EquipmentVersion |
  Class |
  Engine |
  Gearbox |
  Color |
  Interior |
  AdditionalEquipment;
