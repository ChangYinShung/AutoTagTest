import { TestBed } from '@angular/core/testing';

import { EShopManagementService } from './e-shop-management.service';

describe('EShopManagementService', () => {
  let service: EShopManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EShopManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
