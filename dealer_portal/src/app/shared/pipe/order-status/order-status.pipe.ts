import { Pipe, PipeTransform } from '@angular/core';
import { OrderStatus } from '../../enums/order-status.enum';
import { PaymentStatus } from '../../enums/payment-status.enum';

@Pipe({
  name: 'orderStatus'
})
export class OrderStatusPipe implements PipeTransform {

  transform(value: OrderStatus | PaymentStatus | undefined): string {
    switch (value) {
      case OrderStatus.Created:
        return 'Created';
      case OrderStatus.Confirmed:
        return 'Confirmed';
      case OrderStatus.ReadyToProduction:
        return 'Ready to production';
      case OrderStatus.Paid:
        return 'Paid';
      case OrderStatus.Settled:
        return 'Settled';
      case OrderStatus.Production:
        return 'Production';
      case OrderStatus.Produced:
        return 'Produced';
      case OrderStatus.Collected:
        return 'Collected';
      case OrderStatus.Delivered:
        return 'Delivered';
      case OrderStatus.Finished:
        return 'Finished';
      case OrderStatus.Canceled:
        return 'Canceled';

      case PaymentStatus.Waiting:
        return 'Waiting for payment';
      case PaymentStatus.Paid:
        return 'Paid'

      default:
        return '';
    }
  }

}
