import { TestBed } from '@angular/core/testing';

import { DictionariesViewService } from './dictionaries-view.service';

describe('DictionariesViewService', () => {
  let service: DictionariesViewService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        DictionariesViewService,
      ],
    });
    service = TestBed.inject(DictionariesViewService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
