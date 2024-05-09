import { OrderViewModel } from "./order.view-model";

export interface PaginatedOrderViewModel {
    data: OrderViewModel[],
    pageIndex: number,
    pageSize: number,
    totalRecords: number
};
