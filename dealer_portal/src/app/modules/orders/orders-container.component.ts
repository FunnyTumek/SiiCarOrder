import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { PAGE_INDEX, PAGE_SIZE } from 'src/app/shared/helpers/CASHED_KEYS';
import { OrderData } from 'src/app/shared/models/order-models/order-data';
import { OrdersService } from 'src/app/shared/services/fetch/orders.service';
import { QuickActionGroup } from 'src/app/shared/services/global-gui/quick-action.model';
import { QuickActionsService } from 'src/app/shared/services/global-gui/quick-actions.service';
import { OrderViewModel } from './view-models/order.view-model';
import { PaginatedOrderViewModel } from './view-models/paginatied-order-view-model';

@Component({
  selector: 'sii-orders-container',
  templateUrl: './orders-container.component.html',
  styleUrls: ['./orders-container.component.scss']
})
export class OrdersContainerComponent implements OnInit {

  orders$: Observable<PaginatedOrderViewModel>;

  constructor(
    private ordersService: OrdersService,
    private quickActions: QuickActionsService,
    private router: Router,) {
    const cashedSize = localStorage.getItem(PAGE_SIZE);
    const cashedIndex = localStorage.getItem(PAGE_INDEX);

    this.orders$ = this.ordersService.getPaginatedOrders(cashedIndex ? Number(cashedIndex) : 0, cashedSize ? Number(cashedSize) : 50)
      .pipe(map(result => ({ ...result, data: this.mapToOrderViewModel(result.data) })));
  }

  ngOnInit(): void {
    this.quickActions.showModuleActionPanel(this.createModuleActions());
  }

  onUpdatePaginatedOrderTable(event: { pageIndex: number, pageSize: number }) {
    this.orders$ = this.ordersService.getPaginatedOrders(event.pageIndex, event.pageSize)
      .pipe(map(result => {
        return { ...result, data: this.mapToOrderViewModel(result.data) }
      }));
  }

  onPaymentsPrint(): any {
    console.log('Method not implemented.');
  }

  onOrderPrint() {
    console.log('Method not implemented.');
  }

  onDetailsRedirect(id: number) {
    this.quickActions.closePanel().pipe(take(1)).subscribe(() =>
      this.router.navigate([`details/${id}`]));
  }

  private mapToOrderViewModel(orders: OrderData[]): OrderViewModel[] {
    return orders.map(x => ({
      id: x.id,
      customerName: x.customerFirstName + ' ' + x.customerLastName,
      creationDate: new Date(x.creationDate),
      price: x.price,
      status: x.status,
    }));
  }

  private createModuleActions(): QuickActionGroup[] {
    return [{
      label: 'Print',
      actions: [
        { enabled: true, label: 'Print order', handler: () => this.onOrderPrint() },
        { enabled: true, label: 'Print payments', handler: () => this.onPaymentsPrint() },
      ],
    }]
  }
}
