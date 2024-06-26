import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentsViewComponent } from './payments-view.component';

describe('PaymentsViewComponent', () => {
  let component: PaymentsViewComponent;
  let fixture: ComponentFixture<PaymentsViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PaymentsViewComponent],
      imports: [HttpClientTestingModule]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PaymentsViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
