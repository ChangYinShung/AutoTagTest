import { TestBed } from '@angular/core/testing';

import { EmailingManagementService } from './emailing-management.service';

describe('EmailingManagementService', () => {
  let service: EmailingManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmailingManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
