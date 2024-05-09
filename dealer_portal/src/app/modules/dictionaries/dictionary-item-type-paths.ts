import { EnumDictionary } from "src/app/shared/helpers/enum-dictionary";
import { DictionaryItemType } from "./enums/dictionary-item-type";

export const dictionaryItemTypePaths: EnumDictionary<DictionaryItemType, string> = {
  Brand: "brands",
  Model: "models",
  EquipmentVersion: "equipment-versions",
  Class: "classes",
  Engine: "engines",
  Gearbox: "gearboxes",
  Color: "colors",
  Interior: "interiors",
  AdditionalEquipment: "additional-equipments",
};
