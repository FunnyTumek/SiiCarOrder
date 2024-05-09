import { Configuration } from "../configuration";
import { Order } from "./order";
import { Customer } from "./order.model";

export interface OrderDetails {
    configuration: Configuration,
    customer: Customer,
    order: Order
}