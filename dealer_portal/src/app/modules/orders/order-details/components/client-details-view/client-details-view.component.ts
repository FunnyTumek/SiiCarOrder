import { Component, Input } from '@angular/core';
import { Order } from 'src/app/shared/models/order-models/order';
import { Customer } from 'src/app/shared/models/order-models/order.model';

@Component({
  selector: 'sii-client-details-view',
  templateUrl: './client-details-view.component.html',
  styleUrls: ['./client-details-view.component.scss']
})
export class ClientDetailsViewComponent {

  @Input() customer: Customer | undefined;
  @Input() order: Order | undefined;

}
