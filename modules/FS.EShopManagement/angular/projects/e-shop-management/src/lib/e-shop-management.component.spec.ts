import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { EShopManagementComponent } from './e-shop-management.component';

describe('EShopManagementComponent', () => {
  let component: EShopManagementComponent;
  let fixture: ComponentFixture<EShopManagementComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ EShopManagementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EShopManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
