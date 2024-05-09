import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { OrderData } from '../../models/order-models/order-data';
import { OrderDetails } from '../../models/order-models/order-details';
import { PaginatedOrderModel } from '../../models/order-models/paginated-order-model';

@Injectable()

export class OrdersService {

  url = environment.apiUrl
  constructor(private http: HttpClient) { }

  getOrders(): Observable<OrderData[]> {
    return this.http.get<OrderData[]>(`${this.url}/api/orders/all`);
  }

  getPaginatedOrders(pageIndex: number, pageSize: number): Observable<PaginatedOrderModel> {
    return this.http.get<PaginatedOrderModel>(`${this.url}/api/orders?pageIndex=${pageIndex}&pageSize=${pageSize}`)
  }

  getOrder(id: number): Observable<OrderDetails> {
    return this.http.get<OrderDetails>(`${this.url}/api/orders/${id}`);
  }

  confirmOrder(id: number, accept: boolean, percentage: number) {
    return this.http.post(`${this.url}/api/orders/${id}/confirmOrder?accept=${accept}&percentage=${percentage}`, null)
  }

  cancelOrder(id: number) {
    return this.http.post(`${this.url}/api/orders/${id}/cancelorder`, null)
  }

  printOrder(id: number) {
    return this.http.post(`${this.url}/api/orders/${id}/print`, { location: "report.pdf" }, { responseType: 'blob' })
  }

  sendOrderToProduction(id: number) {
    console.log('click', id);
    return this.http.post(`${this.url}/api/orders/${id}/factoryOrder`, null)
  }

  collectOrderFromProduction(id: number){
    return this.http.post(`${this.url}/api/orders/${id}/collectOrder`, null)
  }

  handOverOrderToClient(id: number){
    return this.http.post(`${this.url}/api/orders/${id}/handOver`, null)
  }

}
