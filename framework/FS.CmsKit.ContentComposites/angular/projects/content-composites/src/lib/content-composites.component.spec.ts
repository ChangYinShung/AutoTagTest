import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { ContentCompositesComponent } from './content-composites.component';

describe('ContentCompositesComponent', () => {
  let component: ContentCompositesComponent;
  let fixture: ComponentFixture<ContentCompositesComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ ContentCompositesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContentCompositesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
