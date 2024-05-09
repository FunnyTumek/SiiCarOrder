import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { OrdersService } from 'src/app/shared/services/fetch/orders.service';
import { of } from 'rxjs';
import { OrdersContainerComponent } from './orders-container.component';
import { RouterTestingModule } from '@angular/router/testing';

describe('OrdersContainerComponent', () => {
  let component: OrdersContainerComponent;
  let fixture: ComponentFixture<OrdersContainerComponent>;
  let mockOrdersService: jasmine.SpyObj<OrdersService>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OrdersContainerComponent],
      imports: [
        HttpClientTestingModule,
        RouterTestingModule
      ],
      providers: [
        { provide: OrdersService, useFactory: () => mockOrdersService },
      ],
    }).compileComponents();
  });

  beforeEach(() => {
    mockOrdersService = jasmine.createSpyObj(
      "OrdersService",
      {
        getOrders: of([]),
        getPaginatedOrders: of(null)
      }
    );
    fixture = TestBed.createComponent(OrdersContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
