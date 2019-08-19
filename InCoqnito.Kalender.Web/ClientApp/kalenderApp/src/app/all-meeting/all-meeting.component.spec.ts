import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AllMeetingComponent } from './all-meeting.component';

describe('AllMeetingComponent', () => {
  let component: AllMeetingComponent;
  let fixture: ComponentFixture<AllMeetingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AllMeetingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AllMeetingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
