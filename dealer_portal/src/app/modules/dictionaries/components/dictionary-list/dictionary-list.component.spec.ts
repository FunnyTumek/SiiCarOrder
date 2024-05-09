import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { DictionariesViewService } from '../../services/dictionaries-view.service';
import { DictionariesService } from '../../services/fetch/dictionaries.service';
import { of } from 'rxjs';

import { DictionaryListComponent } from './dictionary-list.component';

describe('DictionaryListComponent', () => {
  let component: DictionaryListComponent;
  let fixture: ComponentFixture<DictionaryListComponent>;
  let mockDictionariesViewService: jasmine.SpyObj<DictionariesViewService>;
  let mockDictionariesService: jasmine.SpyObj<DictionariesService>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DictionaryListComponent],
      imports: [
        RouterTestingModule,
        HttpClientTestingModule,
      ],
      providers: [
        { provide: DictionariesViewService, useFactory: () => mockDictionariesViewService },
        { provide: DictionariesService, useFactory: () => mockDictionariesService },
      ],
    }).compileComponents();
  });

  beforeEach(() => {
    mockDictionariesViewService = jasmine.createSpyObj(
      "DictionariesViewService",
      ["setShowOnlyActive", "setSelectedItem", "setSelectedItemType"],
      { showOnlyActive: of(true), selectedItem: of(undefined), selectedItemType: of(undefined) });
    mockDictionariesService = jasmine.createSpyObj(
      "DictionariesService",
      ["getOptionsForType", "updateOptionForType"]
    );
    fixture = TestBed.createComponent(DictionaryListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
