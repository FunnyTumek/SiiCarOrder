import { AdditionalEquipmentItem } from "./AdditionalEquipmentItem";
import { BrandModel } from "./BrandModel";
import { CarClassModel } from "./CarClassModel";
import { CarModel } from "./CarModel";
import { ColorModel } from "./ColorModel";
import EngineModel from "./EngineModel";
import { EquipmentVersionModel } from "./EquipmentVersionModel";
import GearboxModel from "./GearboxModel";
import { InteriorModel } from "./InteriorModel";


// export interface CarModelOptions {
//     brand: string[],
//     model: string[],
//     equipmentVersion: string[],
//     class: string[],
//     engine: EngineModel[],
//     gearbox: GearboxModel[],
//     color: string[],
//     interior: string[],
//     additionalEquipment: string[]
// }


export interface CarOptionsModel {
    brand: BrandModel[],
    model: CarModel[],
    equipmentVersion: EquipmentVersionModel[],
    class: CarClassModel[],
    engine: EngineModel[],
    gearbox: GearboxModel[],
    color: ColorModel[],
    interior: InteriorModel[],
    additionalEquipment: AdditionalEquipmentItem[]
}


// export const EmptyCarModelOptions: CarModelOptions = {
//     brand: '',
//     model: [],
//     equipmentVersion: [],
//     class: [],
//     engine: [],
//     gearbox: [],
//     color: [],
//     interior: [],
//     additionalEquipment: []
// }