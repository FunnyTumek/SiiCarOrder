import { OrderData } from "./order-data";

export interface PaginatedOrderModel {
    data: OrderData[],
    pageIndex: number,
    pageSize: number,
    totalRecords: number
}