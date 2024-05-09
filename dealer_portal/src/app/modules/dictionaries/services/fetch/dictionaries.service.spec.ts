import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { DictionariesService } from './dictionaries.service';

describe('DictionariesService', () => {
  let service: DictionariesService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule,
      ],
      providers: [
        DictionariesService,
      ],
    });
    service = TestBed.inject(DictionariesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
