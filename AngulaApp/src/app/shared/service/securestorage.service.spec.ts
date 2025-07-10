import { TestBed } from '@angular/core/testing';

import { SecurestorageService } from './securestorage.service';

describe('SecurestorageService', () => {
  let service: SecurestorageService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SecurestorageService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
