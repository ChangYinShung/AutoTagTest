import { TestBed } from '@angular/core/testing';

import { EcPayService } from './ec-pay.service';

describe('EcPayService', () => {
  let service: EcPayService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EcPayService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
