import { Component, EventEmitter, HostBinding, HostListener, Input, OnInit, Output, ViewChild } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { PAGE_INDEX, PAGE_SIZE } from 'src/app/shared/helpers/CASHED_KEYS';
import { OrderViewModel } from '../view-models/order.view-model';
import { PaginatedOrderViewModel } from '../view-models/paginatied-order-view-model';

@Component({
  selector: 'sii-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.scss']
})
export class OrderListComponent {

  @Input() orderListData: PaginatedOrderViewModel | null = null;
  @Output() orderSelectedId = new EventEmitter<number>();
  @Output() orderDetailsRedirect = new EventEmitter<number>();
  @Output() updatePaginatedOrderTable = new EventEmitter<{ pageIndex: number, pageSize: number }>();

  selectedOrder?: OrderViewModel;
  displayedColumns: string[] = [
    'id',
    'customerName',
    'creationDate',
    'price',
    'status',
  ];

  onRowSelected(row: OrderViewModel) {
    this.selectedOrder = row;
    this.orderSelectedId.emit(row.id);
  }

  onRowDblClick(row: OrderViewModel) {
    this.orderDetailsRedirect.emit(row.id);
  }

  getServerData(event: PageEvent) {
    const PaginatorEventEmitter = {
      pageIndex: event.pageIndex,
      pageSize: event.pageSize
    };

    localStorage.setItem(PAGE_INDEX, event.pageIndex.toString())
    localStorage.setItem(PAGE_SIZE, event.pageSize.toString())

    this.updatePaginatedOrderTable.emit(PaginatorEventEmitter);
  }

}
