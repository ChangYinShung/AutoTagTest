import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { CmsKitComponent } from './cms-kit.component';

describe('CmsKitComponent', () => {
  let component: CmsKitComponent;
  let fixture: ComponentFixture<CmsKitComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ CmsKitComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CmsKitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
