import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { PaymentStatus } from '../../enums/payment-status.enum';

export interface PaymentData {
  id: number
  price: number,
  status: PaymentStatus,
  paymentDate: any,
}

@Injectable({ providedIn: 'root' })

export class PaymentsService {
  url = environment.apiUrl
  constructor(private http: HttpClient) { }

  getPayments(orderId: number): Observable<PaymentData[]> {
    return this.http.get<PaymentData[]>(`${this.url}/api/orders/${orderId}/payments`)
  }

  calculatePayments(orderId: number, percentage: number): Observable<PaymentData[]> {
    return this.http.get<PaymentData[]>(`${this.url}/api/orders/${orderId}/calculatepayments?percentage=${percentage}`)
  }

  confirmPayment(orderId: number, paymentId: number) {
    return this.http.post(`${this.url}/api/orders/${orderId}/payments/${paymentId}`, null)
  }

}


