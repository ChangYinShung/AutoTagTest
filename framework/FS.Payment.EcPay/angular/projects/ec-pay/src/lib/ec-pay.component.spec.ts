import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { EcPayComponent } from './ec-pay.component';

describe('EcPayComponent', () => {
  let component: EcPayComponent;
  let fixture: ComponentFixture<EcPayComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ EcPayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EcPayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
