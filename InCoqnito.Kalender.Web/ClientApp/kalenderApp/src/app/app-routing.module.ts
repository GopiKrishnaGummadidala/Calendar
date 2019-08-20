import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NewMeetingComponent } from './new-meeting/new-meeting.component';
import { MyMeetingComponent } from './my-meeting/my-meeting.component';
import { AllMeetingComponent } from './all-meeting/all-meeting.component';
import { InvitationComponent } from './invitation/invitation.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const routes: Routes = [
  { path: '', redirectTo: '/newmeeting', pathMatch: 'full' },
  { path: 'newmeeting', component: NewMeetingComponent },
  { path: 'myMeetings/:id', component: MyMeetingComponent },
  { path: 'allMeeting/:id', component: AllMeetingComponent },
  { path: 'invitation/:invId/:empId', component: InvitationComponent },
  { path: '**', component: PageNotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
