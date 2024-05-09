import { EnumDictionary } from "src/app/shared/helpers/enum-dictionary";
import { DictionaryItemType } from "../../enums/dictionary-item-type"

export const optionColumns: EnumDictionary<DictionaryItemType, string[]> = {
  [DictionaryItemType.AdditionalEquipment]: [
    'active',
    'code',
    'name',
  ],
  [DictionaryItemType.Brand]: [
    'active',
    'code',
    'name',
  ],
  [DictionaryItemType.Class]: [
    'active',
    'code',
    'name',
  ],
  [DictionaryItemType.Color]: [
    'active',
    'code',
    'name',
  ],
  [DictionaryItemType.Engine]: [
    'active',
    'code',
    'name',
    'type',
    'capacity',
    'power',
  ],
  [DictionaryItemType.EquipmentVersion]: [
    'active',
    'code',
    'name',
  ],
  [DictionaryItemType.Gearbox]: [
    'active',
    'code',
    'type',
    'gearsCount',
  ],
  [DictionaryItemType.Interior]: [
    'active',
    'code',
    'name',
  ],
  [DictionaryItemType.Model]: [
    'active',
    'code',
    'name',
  ],
};
