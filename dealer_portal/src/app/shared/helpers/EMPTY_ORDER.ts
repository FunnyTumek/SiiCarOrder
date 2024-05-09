import { OrderStatus } from "../enums/order-status.enum";
import { Order } from "../models/order-models/order";

export const EMPTY_ORDER: Order = {
    id: 0,
    price: 0,
    status: OrderStatus.Canceled,
    discount: 0,
    creationDate: new Date(),
    agreementSignedDate: new Date(),
    plannedDeliveryDate: new Date(),

}