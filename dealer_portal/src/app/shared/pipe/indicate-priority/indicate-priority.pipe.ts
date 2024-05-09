import { Pipe, PipeTransform } from '@angular/core';
import { OrderStatus } from '../../enums/order-status.enum';
import { PaymentStatus } from '../../enums/payment-status.enum';

@Pipe({
  name: 'indicatePriority'
})
export class IndicatePriorityPipe implements PipeTransform {

  HIGHT_PRIORITY = 'LightCoral';
  MEDIUM_PRIORITY = 'BlanchedAlmond';
  LOW_PRIORITY = 'Lightblue';
  COMPLETE = 'DarkSeaGreen';
  CANCELED = 'Gainsboro';


  transform(value: OrderStatus | PaymentStatus | undefined): string {
    switch (value) {
      case OrderStatus.Created:
        return this.MEDIUM_PRIORITY;
      case OrderStatus.Confirmed:
        return this.MEDIUM_PRIORITY;
      case OrderStatus.Paid:
        return this.MEDIUM_PRIORITY;
      case OrderStatus.Settled:
        return this.LOW_PRIORITY;
      case OrderStatus.Production:
        return this.LOW_PRIORITY;
      case OrderStatus.Produced:
        return this.LOW_PRIORITY;
      case OrderStatus.Collected:
        return this.LOW_PRIORITY;
      case OrderStatus.Delivered:
        return this.LOW_PRIORITY;
      case OrderStatus.Finished:
        return this.COMPLETE;
      case OrderStatus.Canceled:
        return this.CANCELED;

      case PaymentStatus.Waiting:
        return this.HIGHT_PRIORITY;
      case PaymentStatus.Paid:
        return this.COMPLETE;

      default:
        return '';
    }

  }
}
