import { Component } from '@angular/core';
import { OrdersService } from 'src/app/shared/services/fetch/orders.service';
import { ActivatedRoute } from '@angular/router';
import { map, tap, Observable, share } from 'rxjs';
import { PaymentsService } from 'src/app/shared/services/fetch/payments.service';
import { PaymentItemViewModel } from '../../view-models/payment.view-model'
import { HistoryData, HistoryService } from 'src/app/shared/services/fetch/history.service';
import { OrderDetailsViewModel } from '../../view-models/order-details-view-model';
import { mapPaymentToViewModel } from '../../view-models/map-payment-view-model';
import { mapOrderToViewModel } from '../../view-models/map-order-to-view-model';
import { QuickActionsService } from 'src/app/shared/services/global-gui/quick-actions.service';
import { QuickActionGroup } from 'src/app/shared/services/global-gui/quick-action.model';
import { OrderStatus } from 'src/app/shared/enums/order-status.enum';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmOrderDialogComponent } from '../confirm-order-dialog/confirm-order-dialog.component';
import { Order } from 'src/app/shared/models/order-models/order';
import { Customer } from "src/app/shared/models/order-models/order.model";
import { EMPTY_CUSTOMER } from 'src/app/shared/helpers/EMPTY_CUSTOMER';
import { EMPTY_ORDER } from 'src/app/shared/helpers/EMPTY_ORDER';
@Component({
  selector: 'sii-order-details-container',
  templateUrl: './order-details-container.component.html',
  styleUrls: ['./order-details-container.component.scss']
})
export class OrderDetailsContainerComponent {

  order$!: Observable<OrderDetailsViewModel>;
  payments$!: Observable<PaymentItemViewModel[]>;
  history$!: Observable<HistoryData[]>
  status: OrderStatus | undefined;
  orderId: number;

  order: Order = EMPTY_ORDER
  customer: Customer = EMPTY_CUSTOMER

  constructor(
    private ordersService: OrdersService,
    private route: ActivatedRoute,
    private paymentsService: PaymentsService,
    private historyService: HistoryService,
    private quickActions: QuickActionsService,
    private dialog: MatDialog
  ) {
    this.orderId = Number(this.route.snapshot.paramMap.get('id'));

    if (this.orderId !== null) {
      this.order$ = this.ordersService.getOrder(this.orderId).pipe(
        share(),
        tap(result => this.status = result.order.status),
        tap(result => this.orderId = result.order.id),
        tap(result => this.order = result.order),
        tap(result => this.customer = result.customer),
        map(result => mapOrderToViewModel(result)),
        tap(result => this.quickActions.showModuleActionPanel(this.createModuleActions())));


      this.payments$ = this.paymentsService.getPayments(this.orderId).pipe(
        share(),
        map(result => mapPaymentToViewModel(result, this.orderId)));

      this.history$ = this.historyService.getHistory(this.orderId);
    }
  }

  private createModuleActions(): QuickActionGroup[] {

    switch (this.status) {
      case OrderStatus.Created:
        return [{
          label: 'Order',
          actions: [
            { enabled: true, label: 'Confirm order', handler: () => this.openDialog() },
            { enabled: true, label: 'Cancel order', handler: () => this.cancelOrder() },
          ],
        }]

      case OrderStatus.Confirmed:
        return [{
          label: 'Order',
          actions: [
            { enabled: true, label: 'Cancel order', handler: () => this.cancelOrder() },
            { enabled: true, label: 'Print order', handler: () => this.printOrder() },
          ],
        },
        {
          label: ' Payments',
          actions: [
            { enabled: true, label: 'Confirm payment', handler: () => this.confirmPayment() },
          ],
        }]
      case OrderStatus.Paid:
        return [{
          label: 'Order',
          actions: [
            { enabled: true, label: 'Cancel order', handler: () => this.openDialog() },
          ],
        },
        {
          label: ' Production',
          actions: [
            { enabled: true, label: 'Check order', handler: () => this.confirmPayment() },
          ],
        }]
      case OrderStatus.ReadyToProduction:
        return [{
          label: 'Production',
          actions: [
            { enabled: true, label: 'Send to Production', handler: () => this.sendToProduction() },

          ],
        }]
      case OrderStatus.Production:
        return [{
          label: 'Production',
          actions: [
            { enabled: true, label: 'View details', handler: () => this.sendToProduction() },

          ],
        }]
        case OrderStatus.Produced:
        return [{
          label: 'Production',
          actions: [
            { enabled: true, label: 'Collect', handler: () => this.collectFromProduction() },

          ],
        }]
        case OrderStatus.Collected:
          return [{
            label: 'Order',
            actions: [
              { enabled: true, label: 'Hand Over', handler: () => this.handOverOrderToClient() },
  
            ],
          }]
      default:
        return []
    }
  }

  openDialog() {
    const dialogRef = this.dialog.open(ConfirmOrderDialogComponent, {
      data: {
        order: this.order,
        customer: this.customer
      },
    });

    dialogRef.afterClosed().subscribe(result => {
      this.confirmOrder(result.id, result.isAgreementSigned, result.advanceInPercent)
    });
  }

  confirmOrder(id: number, accept: boolean, percentage: number) {
    this.ordersService.confirmOrder(id, accept, percentage).subscribe(() => this.status = OrderStatus.Confirmed);
  }

  cancelOrder() {
    this.ordersService.cancelOrder(this.orderId).subscribe(() => this.status = OrderStatus.Canceled);
  }

  downloadFile(data: any) {
    const blob = new Blob([data], { type: 'application/pdf' });
    const url = window.URL.createObjectURL(blob);
    window.open(url);
  }

  confirmPayment() {

  }

  printOrder() {
    this.ordersService.printOrder(this.orderId).subscribe(data => this.downloadFile(data));
  }

  public getPrice() {
    return this.order.price
  }

  sendToProduction() {
    this.ordersService.sendOrderToProduction(this.orderId).subscribe();
  }

  collectFromProduction() {
    this.ordersService.collectOrderFromProduction(this.orderId).subscribe();
  }

  handOverOrderToClient() {
    this.ordersService.handOverOrderToClient(this.orderId).subscribe();
  }
}






