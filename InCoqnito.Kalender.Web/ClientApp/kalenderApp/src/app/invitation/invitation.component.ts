import { Component, OnInit } from '@angular/core';
import { InvitationService } from './invitation.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';
import { RatingRequest } from '../models/RatingRequest';

@Component({
  selector: 'app-invitation',
  templateUrl: './invitation.component.html',
  styleUrls: ['./invitation.component.scss']
})
export class InvitationComponent implements OnInit {
  public invId: number;
  public empId: number;
  public meetingAuthor: string;
  public meetingDate: Date;
  public meetingDescription: string;
  public rating: number;
  constructor(private _invitationService: InvitationService, private _toastr: ToastrService,
    private _route: ActivatedRoute ) { }

  ngOnInit() {
    this.invId = parseInt(this._route.snapshot.paramMap.get('invId'));
    this.empId = parseInt(this._route.snapshot.paramMap.get('empId'));
    this.getInvitationInfo();
  }

  getInvitationInfo(){
    this._invitationService.getInvitationInfo(this.invId)
    .subscribe(res => {
      if(res != null){
        this.meetingAuthor = res.authorName;
        this.meetingDescription = res.description;
        this.meetingDate = res.date;
      }
    }, error => {
      console.log(error);
    });
  }

  validate(){
    if(!this.rating){
      this._toastr.warning("Please enter Rating", 'Warning');  
      return false;
    }
    return true;
  }

  submitRating(){
    if(this.validate()){
      let request = new RatingRequest();
      request.invId = this.invId;
      request.empId = this.empId;
      request.rating = this.rating;
      this._invitationService.submitRating(request)
      .subscribe(res => {
        if(res){
          this._toastr.success("Successfully rating submitted", 'Success');  
        }else{
          this._toastr.error("Something went wrong! Please try again later", 'Error'); 
        }
      }, error => {
        console.log(error);
        this._toastr.error("Something went wrong! Please try again later", 'Error');
      });
    }
  }
}
