import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Order } from 'src/app/shared/models/order-models/order';
import { Customer } from 'src/app/shared/models/order-models/order.model';
export interface TableTitleType {
  name: string;
  position: number;
  quantity: number;
  price: number;
}
@Component({
  selector: 'sii-confirm-order-dialog',
  templateUrl: './confirm-order-dialog.component.html',
  styleUrls: ['./confirm-order-dialog.component.scss']
})

export class ConfirmOrderDialogComponent {

  checked = false;
  advanceValue = 0
  secondTransferValue = 0
  advanceInPercent = 0
  isAgreementSigned = false

  displayedColumns: string[] = ['position', 'name', 'quantity', 'price'];

  dataSource: TableTitleType[] = [
    { position: 1, name: 'Sii Car', quantity: 1, price: this.data.order.price },
  ];

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: { order: Order, customer: Customer },
    public dialogRef: MatDialogRef<ConfirmOrderDialogComponent>,
  ) {

  }

  closeDialog() { }

  confirmDialog() {
    const result = {
      id: this.data.order.id,
      advanceInPercent: this.advanceInPercent,
      isAgreementSigned: this.isAgreementSigned
    }
    this.dialogRef.close(result);
  }
  formatLabel(value: number) {
    return (Math.round(value) + '%');
  }

  calcAdvance(advanceInPercent: number) {
    this.advanceValue = this.data.order.price / 100 * advanceInPercent;
    this.secondTransferValue = this.data.order.price - this.advanceValue;
  }
}
