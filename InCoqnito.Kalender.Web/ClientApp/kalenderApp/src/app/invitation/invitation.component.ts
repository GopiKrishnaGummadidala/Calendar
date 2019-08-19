import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-invitation',
  templateUrl: './invitation.component.html',
  styleUrls: ['./invitation.component.scss']
})
export class InvitationComponent implements OnInit {
public userId: number;
public meetingAuthor: string;
public meetingDate: string;
public meetingDescription: string;
public rating: number;
  constructor() { }

  ngOnInit() {
  }

}
