import { TestBed } from '@angular/core/testing';

import { ContentCompositesService } from './content-composites.service';

describe('ContentCompositesService', () => {
  let service: ContentCompositesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ContentCompositesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
