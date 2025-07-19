import { TestBed } from '@angular/core/testing';

import { ItareaRequestService } from './itarea-request.service';

describe('ItareaRequestService', () => {
  let service: ItareaRequestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ItareaRequestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
