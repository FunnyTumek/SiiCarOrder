import { OrderStatus } from "src/app/shared/enums/order-status.enum";
export interface OrderViewModel {
  id: number;
  customerName: string;
  creationDate: Date;
  price: number;
  status: OrderStatus;
}