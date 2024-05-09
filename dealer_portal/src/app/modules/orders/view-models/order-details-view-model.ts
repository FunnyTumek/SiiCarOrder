import { ConfigurationItem } from "src/app/shared/models/configuration-item";
import { Order } from "src/app/shared/models/order-models/order";
import { Customer } from "src/app/shared/models/order-models/order.model";

export interface OrderDetailsViewModel {
    configuration: ConfigurationItem[],
    customer: Customer,
    order: Order
}