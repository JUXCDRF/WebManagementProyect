import { TestBed } from '@angular/core/testing';

import { TareaEventService } from './tarea-event.service';

describe('TareaEventService', () => {
  let service: TareaEventService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TareaEventService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
