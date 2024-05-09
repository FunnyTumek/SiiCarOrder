import { AdditionalEquipmentItem } from "./AdditionalEquipmentItem";
import { BrandModel } from "./BrandModel";
import { CarClassModel } from "./CarClassModel";
import { CarModel } from "./CarModel";
import { ColorModel } from "./ColorModel";
import EngineModel from "./EngineModel";
import { EquipmentVersionModel } from "./EquipmentVersionModel";
import GearboxModel from "./GearboxModel";
import { InteriorModel } from "./InteriorModel";

export interface ConfigurationModel {
    brand: BrandModel,
    model: CarModel,
    equipmentVersion: EquipmentVersionModel,
    class: CarClassModel,
    engine: EngineModel,
    gearbox: GearboxModel,
    color: ColorModel,
    interior: InteriorModel,
    additionalEquipment: AdditionalEquipmentItem[],
    price: number,
}



