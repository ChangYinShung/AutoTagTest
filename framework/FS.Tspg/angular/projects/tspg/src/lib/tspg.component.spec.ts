import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { TspgComponent } from './tspg.component';

describe('TspgComponent', () => {
  let component: TspgComponent;
  let fixture: ComponentFixture<TspgComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ TspgComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TspgComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
