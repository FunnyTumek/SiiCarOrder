import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderDetailsContainerComponent } from './order-details-container/order-details-container.component';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { OrdersService } from 'src/app/shared/services/fetch/orders.service';
import { CarConfigurationViewComponent } from './components/car-configuration-view/car-configuration-view.component';
import { PaymentsViewComponent } from './components/payments-view/payments-view.component';
import { HistoryViewComponent } from './components/history-view/history-view.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { ClientDetailsViewComponent } from './components/client-details-view/client-details-view.component';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { PaymentsService } from 'src/app/shared/services/fetch/payments.service';
import { HistoryService } from 'src/app/shared/services/fetch/history.service';
import { OrderStatusModule } from 'src/app/shared/pipe/order-status/order-status.module';
import { IndicatePriorityModule } from 'src/app/shared/pipe/indicate-priority/indicate-priority.module';
import { ConfirmOrderDialogComponent } from './confirm-order-dialog/confirm-order-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FormsModule } from '@angular/forms';
import { MatSliderModule } from '@angular/material/slider';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatInputModule } from '@angular/material/input';
import { MatProgressBarModule } from '@angular/material/progress-bar';

const MATERIAL_MODULES = [
  MatCardModule,
  MatButtonModule,
  MatExpansionModule,
  MatIconModule,
  MatCheckboxModule,
  MatTableModule,
  MatSliderModule,
  MatSlideToggleModule,
  MatInputModule,
  MatProgressBarModule,
  MatDialogModule,
]
@NgModule({
  declarations: [
    OrderDetailsContainerComponent,
    CarConfigurationViewComponent,
    PaymentsViewComponent,
    HistoryViewComponent,
    ClientDetailsViewComponent,
    ConfirmOrderDialogComponent
  ],
  imports: [
    CommonModule,
    OrderStatusModule,
    IndicatePriorityModule,
    FormsModule,
    ...MATERIAL_MODULES
  ],
  exports: [
    OrderDetailsContainerComponent,
  ],
  providers: [
    OrdersService,
    PaymentsService,
    HistoryService,
  ]
})
export class OrderDetailsModule { }
