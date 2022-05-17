import { TestBed } from '@angular/core/testing';

import { EntityManagementService } from './entity-management.service';

describe('EntityManagementService', () => {
  let service: EntityManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EntityManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
