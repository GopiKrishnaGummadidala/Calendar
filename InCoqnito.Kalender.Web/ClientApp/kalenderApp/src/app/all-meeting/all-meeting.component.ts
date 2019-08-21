import { Component, OnInit } from '@angular/core';
import { SignalRService } from './signal-r.service';
import { HttpClient } from '@angular/common/http';
import { MatTableDataSource } from '@angular/material';
import { IinvitationVM } from '../models/invitationVM';

@Component({
  selector: 'app-all-meeting',
  templateUrl: './all-meeting.component.html',
  styleUrls: ['./all-meeting.component.scss']
})
export class AllMeetingComponent implements OnInit {

  dataSource: any;
  displayedColumns: string[] = ['authorName', 'description', 'date', 'rating','startTime','endTime'];
  constructor(public signalRService: SignalRService, private http: HttpClient) { }

  ngOnInit() {
    this.signalRService.startConnection();
    this.signalRService.addTransferDataListener();   
    this.startHttpRequest();
  }

  private startHttpRequest = () => {
    this.http.get('https://localhost:44336/api/rating')
      .subscribe((res: IinvitationVM[]) => {
        this.dataSource = new MatTableDataSource(res);
      })
  }

}
