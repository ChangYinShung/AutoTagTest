import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { UnifyThemeComponent } from './unify-theme.component';

describe('UnifyThemeComponent', () => {
  let component: UnifyThemeComponent;
  let fixture: ComponentFixture<UnifyThemeComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ UnifyThemeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UnifyThemeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
