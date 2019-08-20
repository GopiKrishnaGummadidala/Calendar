import { Component, OnInit } from '@angular/core';
import { NewmeetingService } from './newmeeting.service';
import { ToastrService } from 'ngx-toastr'; 
import { InvitationRequest } from '../models/InvitationRequest';

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

  constructor(private _meetingService: NewmeetingService, private toastr: ToastrService ) { }

  ngOnInit() {
    this.meetingAuthor = 'gopikrishna.gummadidala@gmail.com';
    this.startTime = '09:00';
    this.endTime = '09:00';
    this.toastr.success("Successfully meeting shared", 'Success',{timeOut:1000000});  
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

  validate(){
    if(!this.meetingAuthor){
      this.toastr.warning("Please enter Author", 'Warning');  
      return false;
    }
    if(!this.meetingDate){
      this.toastr.warning("Please enter Date", 'Warning');  
      return false;
    }
    if(!this.meetingDescription){
      this.toastr.warning("Please enter Description", 'Warning');  
      return false;
    }
    if(!(this.startTime < this.endTime)){
      this.toastr.warning("Please select valid Start and End Time", 'Warning');  
      return false;
    }
    if(this.selectedUsers.length == 0){
      this.toastr.warning("Please enter select Users", 'Warning');  
      return false;
    }
      return true;
  }

  shareMeeting(){
    if(this.validate()){
      let request = new InvitationRequest();
      request.authorId = 1;
      request.date = this.meetingDate;
      request.startTime = this.startTime;
      request.endTime = this.endTime;
      request.description = this.meetingDescription;
      request.sharedEmails = this.selectedUsers;
      this._meetingService.shareMeeting(request)
      .subscribe(res => {
        if(res){
          this.toastr.warning("Successfully meeting shared", 'Success');  
        }else{
          this.toastr.warning("Something went wrong! Please try again later", 'Error'); 
        }
      }, error => {
        console.log(error);
        this.toastr.warning("Something went wrong! Please try again later", 'Error');
      });
    }
  }

}
