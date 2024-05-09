import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdersContainerComponent } from './orders-container.component';
import { RouterModule, Routes } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { OrderListComponent } from './order-list/order-list.component';
import { OrderDetailsContainerComponent } from './order-details/order-details-container/order-details-container.component';
import { OrderStatusModule } from 'src/app/shared/pipe/order-status/order-status.module';
import { IndicatePriorityModule } from 'src/app/shared/pipe/indicate-priority/indicate-priority.module';
import { OrderDetailsModule } from './order-details/order-details.module';
import { MatPaginatorModule } from '@angular/material/paginator';
import { OrdersService } from 'src/app/shared/services/fetch/orders.service';

const routes: Routes = [
  { path: '', component: OrdersContainerComponent },
  { path: 'details/:id', component: OrderDetailsContainerComponent }
];
@NgModule({
  declarations: [
    OrdersContainerComponent,
    OrderListComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MatTableModule,
    OrderDetailsModule,
    OrderStatusModule,
    IndicatePriorityModule,
    MatPaginatorModule
  ],
  exports: [
    OrdersContainerComponent
  ],
  providers: [
    OrdersService
  ]
})
export class OrdersModule { }
