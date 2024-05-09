import { ComponentFixture, TestBed } from '@angular/core/testing';
import { OrderDetailsModule } from '../../order-details.module';
import { ClientDetailsViewComponent } from './client-details-view.component';

describe('ClientDetailsViewComponent', () => {
  let component: ClientDetailsViewComponent;
  let fixture: ComponentFixture<ClientDetailsViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ClientDetailsViewComponent],
      imports: [OrderDetailsModule]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClientDetailsViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
