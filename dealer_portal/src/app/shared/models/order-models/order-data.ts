import { OrderStatus } from "../../enums/order-status.enum";

export interface OrderData {
    id: number,
    customerFirstName: string,
    customerLastName: string,
    creationDate: string,
    price: number,
    status: OrderStatus,
}