import { TestBed } from '@angular/core/testing';

import { ContentDefinitionsService } from './content-definitions.service';

describe('ContentDefinitionsService', () => {
  let service: ContentDefinitionsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ContentDefinitionsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
