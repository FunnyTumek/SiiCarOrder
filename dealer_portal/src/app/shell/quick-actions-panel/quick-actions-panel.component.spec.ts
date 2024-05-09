import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

import { QuickActionsPanelComponent } from './quick-actions-panel.component';

describe('QuickActionsPanelComponent', () => {
  let component: QuickActionsPanelComponent;
  let fixture: ComponentFixture<QuickActionsPanelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [QuickActionsPanelComponent],
      imports: [
        NoopAnimationsModule,
      ],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QuickActionsPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
