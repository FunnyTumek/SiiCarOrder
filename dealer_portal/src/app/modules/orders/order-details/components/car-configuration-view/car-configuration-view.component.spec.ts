import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarConfigurationViewComponent } from './car-configuration-view.component';

describe('CarConfigurationViewComponent', () => {
  let component: CarConfigurationViewComponent;
  let fixture: ComponentFixture<CarConfigurationViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarConfigurationViewComponent]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CarConfigurationViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
