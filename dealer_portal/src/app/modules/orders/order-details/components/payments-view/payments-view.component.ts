/* eslint-disable @angular-eslint/no-input-rename */
import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { PaymentItemViewModel } from '../../../view-models/payment.view-model';
import { PaymentData, PaymentsService } from 'src/app/shared/services/fetch/payments.service';
import { Order } from 'src/app/shared/models/order-models/order';
import { PaymentStatus } from 'src/app/shared/enums/payment-status.enum';
import { OrderStatus } from 'src/app/shared/enums/order-status.enum';

@Component({
  selector: 'sii-payments-view',
  templateUrl: './payments-view.component.html',
  styleUrls: ['./payments-view.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})

export class PaymentsViewComponent implements OnChanges {

  @Input() order: Order | undefined;
  @Input() dataSource: PaymentItemViewModel[] = [];

  payments: PaymentData[] = [];
  balance: number = 0;
  sumOfConfirmedPayments: number = 0;
  progressBar: number = 0;
  statuses = PaymentStatus;

  public get availableDataSource()
  {
    if(this.order?.status === OrderStatus.Production || this.order?.status === OrderStatus.Produced)
    {
      return this.dataSource;
    }
    else
    {
      return this.dataSource.slice(0, 1);
    }
  }

  constructor(
    private paymentsService: PaymentsService,
  ) {
  }
  ngOnChanges(changes: SimpleChanges): void {

    if (changes.hasOwnProperty('order') || changes.hasOwnProperty('dataSource')) {
      if (this.order && this.dataSource.length > 0) {
        this.getOrderBalance(this.order?.id, this.dataSource)
      } else {
        this.sumOfConfirmedPayments = 0;
      }
    }
  }

  getOrderBalance(orderId: number | undefined, paymets: PaymentItemViewModel[]) {
    if (orderId) {
      this.sumOfConfirmedPayments = paymets.filter(item => item.status === PaymentStatus.Paid).map(i => i.price).reduce((partialSum, a) => partialSum + a, 0)
      this.balance = this.sumOfConfirmedPayments - this.order!.price
      this.setBalance(this.balance)
      return
    }
  }

  setBalance(balance: number) {
    this.setProgressBar(100 + Math.round(balance / this.order!.price * 100));
  }

  setProgressBar(progress: number) {
    this.progressBar = progress
  }

  confirmPayment(orderId: number, paymentId: number) {
    this.paymentsService.confirmPayment(orderId, paymentId)
      .subscribe(ret => {
        const p = this.dataSource.find(item => item.paymentId == paymentId)
        if (p) {
          p.status = PaymentStatus.Paid;
          this.getOrderBalance(orderId, this.dataSource);
        }
      })

  }
}







