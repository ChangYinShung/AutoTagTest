import { TestBed } from '@angular/core/testing';

import { TspgService } from './tspg.service';

describe('TspgService', () => {
  let service: TspgService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TspgService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
