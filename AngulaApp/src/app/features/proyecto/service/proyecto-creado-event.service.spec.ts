import { TestBed } from '@angular/core/testing';

import { ProyectoCreadoEventService } from './proyecto-creado-event.service';

describe('ProyectoCreadoEventService', () => {
  let service: ProyectoCreadoEventService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProyectoCreadoEventService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
