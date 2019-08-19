import { Component, OnInit } from '@angular/core';
import { NewmeetingService } from './newmeeting.service';

@Component({
  selector: 'app-new-meeting',
  templateUrl: './new-meeting.component.html',
  styleUrls: ['./new-meeting.component.scss']
})
export class NewMeetingComponent implements OnInit {
  public meetingDate: Date;
  public meetingAuthor: string;
  public startTime: string;
  public endTime: string;
  public meetingDescription: string;
  usersList: any = [];
  selectedUsers = [];
  settings = {};

  constructor(private _meetingService: NewmeetingService) { }

  ngOnInit() {
    this.meetingAuthor = 'gopikrishna.gummadidala@gmail.com';
    this.startTime = '09:00';
    this.endTime = '09:00';
    this.usersDropdownSettingsInit();
  }

  onSearch(evt: any) {
    console.log(evt.target.value);
    this.usersList = [];
    this._meetingService.getEmployeesInfo()
      .subscribe(res => {
        console.log(res);
        this.usersList = res;
      }, error => {
        console.log(error);
      });
  }
  onItemSelect(item: any) {
    console.log(item);
    console.log(this.selectedUsers);
  }
  OnItemDeSelect(item: any) {
    console.log(item);
    console.log(this.selectedUsers);
  }
  onSelectAll(items: any) {
    console.log(items);
  }
  onDeSelectAll(items: any) {
    console.log(items);
  }

  usersDropdownSettingsInit() {
    this.settings = {
      text: "Select Users",
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      classes: "myclass custom-class",
      primaryKey: "id",
      labelKey: "name",
      noDataLabel: "Search Users...",
      enableSearchFilter: true,
      searchBy: ['name', 'emailId']
    };
  }

}
