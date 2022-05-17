import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { EmailingManagementComponent } from './emailing-management.component';

describe('EmailingManagementComponent', () => {
  let component: EmailingManagementComponent;
  let fixture: ComponentFixture<EmailingManagementComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ EmailingManagementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmailingManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
