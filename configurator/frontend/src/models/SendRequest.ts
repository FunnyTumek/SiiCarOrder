import { CustomerData } from "./CustomerData";
import { IConfigurationModelDto } from "./IConfigurationModelDto";

export interface sendRequest {
    configuration: IConfigurationModelDto,
    customer: CustomerData
}