import { AdditionalEquipmentItem } from "../../../models/AdditionalEquipmentItem";
import { CarClassModel } from "../../../models/CarClassModel";
import { CarModel } from "../../../models/CarModel";
import { ColorModel } from "../../../models/ColorModel";
import { ConfigurationModel } from "../../../models/ConfigurationModel";
import EngineModel from "../../../models/EngineModel";
import { EquipmentVersionModel } from "../../../models/EquipmentVersionModel";
import GearboxModel from "../../../models/GearboxModel";
import { InteriorModel } from "../../../models/InteriorModel";
import { SimpleConfigurationItem } from "../../../models/SimpleConfigurationItem";
import ACTIONS from "./StepperActions";

type ConfiguratorAction = {
    type: string,
    payload: SimpleConfigurationItem | EngineModel | GearboxModel | AdditionalEquipmentItem
}

function configurationReducer(state: ConfigurationModel, action: ConfiguratorAction): ConfigurationModel {
    const { type, payload } = action;
    switch (type) {
        case ACTIONS.ADD_CAR_CLASS:
            return { ...state, class: payload as CarClassModel }
        case ACTIONS.ADD_CAR_MODEL:
            return { ...state, model: payload as CarModel }
        case ACTIONS.ADD_CAR_EQUIPMENT_VERSION:
            return { ...state, equipmentVersion: payload as EquipmentVersionModel }
        case ACTIONS.ADD_CAR_COLOR:
            return { ...state, color: payload as ColorModel }
        case ACTIONS.ADD_CAR_INTERIOR:
            return { ...state, interior: payload as InteriorModel }
        case ACTIONS.ADD_CAR_ENGINE:
            return { ...state, engine: payload as EngineModel }
        case ACTIONS.ADD_CAR_GEARBOX:
            return { ...state, gearbox: payload as GearboxModel }
        case ACTIONS.SELECT_CAR_ADDITIONAL_EQUIPMENT:
            let choice = payload as AdditionalEquipmentItem;
            if (state.additionalEquipment.some(x => x.code === choice.code)) {
                return { ...state, additionalEquipment: state.additionalEquipment.filter(i => i.code !== choice.code) }
            } else {
                return { ...state, additionalEquipment: [...state.additionalEquipment, choice] }
            }
        default:
            return state
    }
};

export default configurationReducer;