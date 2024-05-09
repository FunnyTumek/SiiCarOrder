import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MatDialogModule } from '@angular/material/dialog';
import { RouterTestingModule } from '@angular/router/testing';
import { of } from 'rxjs';

import { DictionariesContainerComponent } from './dictionaries-container.component';
import { DictionariesViewService } from './services/dictionaries-view.service';

describe('DictionariesContainerComponent', () => {
  let component: DictionariesContainerComponent;
  let fixture: ComponentFixture<DictionariesContainerComponent>;
  let mockDictionariesViewService: jasmine.SpyObj<DictionariesViewService>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DictionariesContainerComponent],
      imports: [
        RouterTestingModule,
        HttpClientTestingModule,
        MatDialogModule,
      ],
      providers: [
        { provide: DictionariesViewService, useFactory: () => mockDictionariesViewService },
      ],
    }).compileComponents();
  });

  beforeEach(() => {
    mockDictionariesViewService = jasmine.createSpyObj(
      "DictionariesViewService",
      ["setShowOnlyActive", "setSelectedItem", "setSelectedItemType"],
      { showOnlyActive: of(true), selectedItem: of(undefined), selectedItemType: of(undefined) });
    fixture = TestBed.createComponent(DictionariesContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
