import { TestBed } from '@angular/core/testing';

import { UnifyThemeService } from './unify-theme.service';

describe('UnifyThemeService', () => {
  let service: UnifyThemeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UnifyThemeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
