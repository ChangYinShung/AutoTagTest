import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { ContentDefinitionsComponent } from './content-definitions.component';

describe('ContentDefinitionsComponent', () => {
  let component: ContentDefinitionsComponent;
  let fixture: ComponentFixture<ContentDefinitionsComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ ContentDefinitionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContentDefinitionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
