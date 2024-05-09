import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { RouterTestingModule } from '@angular/router/testing';
import { HistoryService } from 'src/app/shared/services/fetch/history.service';
import { OrdersService } from 'src/app/shared/services/fetch/orders.service';
import { PaymentsService } from 'src/app/shared/services/fetch/payments.service';
import { of } from 'rxjs';
import { OrderDetailsContainerComponent } from './order-details-container.component';
import { createTestOrderDetails } from 'src/app/shared/test-utils/test-model-factory';

describe('OrderDetailsContainerComponent', () => {
  let component: OrderDetailsContainerComponent;
  let fixture: ComponentFixture<OrderDetailsContainerComponent>;
  let mockOrdersService: jasmine.SpyObj<OrdersService>;
  let mockPaymentService: jasmine.SpyObj<PaymentsService>;
  let mockHistoryService: jasmine.SpyObj<HistoryService>;

  beforeEach(async () => {
    mockOrdersService = jasmine.createSpyObj('OrdersService', ['getOrder']);
    mockPaymentService = jasmine.createSpyObj('PaymentService', ['getPayments']);
    mockHistoryService = jasmine.createSpyObj('HistoryService', ['getHistory']);

    await TestBed.configureTestingModule({
      declarations: [OrderDetailsContainerComponent],
      providers: [
        { provide: OrdersService, useFactory: () => mockOrdersService },
        { provide: PaymentsService, useFactory: () => mockPaymentService },
        { provide: HistoryService, useFactory: () => mockHistoryService },
        { provide: MAT_DIALOG_DATA, useValue: {} },
        { provide: MatDialogRef, useValue: {} }
      ],
      imports: [
        RouterTestingModule,
        MatDialogModule,

      ],
    })
      .compileComponents();
  });

  beforeEach(waitForAsync(() => {
    mockOrdersService.getOrder.and.returnValue(of(createTestOrderDetails()));
    mockPaymentService.getPayments.and.returnValue(of([]))
    fixture = TestBed.createComponent(OrderDetailsContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
