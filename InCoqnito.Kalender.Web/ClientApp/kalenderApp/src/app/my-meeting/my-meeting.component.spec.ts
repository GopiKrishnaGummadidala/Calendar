import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MyMeetingComponent } from './my-meeting.component';

describe('MyMeetingComponent', () => {
  let component: MyMeetingComponent;
  let fixture: ComponentFixture<MyMeetingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyMeetingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyMeetingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
