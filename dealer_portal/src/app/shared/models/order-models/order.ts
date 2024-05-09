import { OrderStatus } from "../../enums/order-status.enum";

export interface Order {
    id: number,
    price: number,
    status: OrderStatus,
    discount: number,
    creationDate: Date,
    agreementSignedDate: Date
    plannedDeliveryDate: Date
}
