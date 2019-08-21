import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NewMeetingComponent } from './new-meeting/new-meeting.component';
import { MyMeetingComponent } from './my-meeting/my-meeting.component';
import { AllMeetingComponent } from './all-meeting/all-meeting.component';
import { InvitationComponent } from './invitation/invitation.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { HeaderComponent } from './shared/header/header.component';
import { EmployeeManagementComponent } from './employee-management/employee-management.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from './material.module';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule, NoopAnimationsModule } from '@angular/platform-browser/animations';
import { AngularMultiSelectModule } from 'angular2-multiselect-dropdown';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

const routes: Routes = [
  { path: '', redirectTo: '/newmeeting', pathMatch: 'full' },
  { path: 'newmeeting', component: NewMeetingComponent },
  { path: 'myMeetings/:id', component: MyMeetingComponent },
  { path: 'allMeeting/:id', component: AllMeetingComponent },
  { path: 'invitation/:invId/:empId', component: InvitationComponent },
  { path: '**', component: PageNotFoundComponent },
];

@NgModule({
  declarations: [ 
    NewMeetingComponent,
    MyMeetingComponent,
    AllMeetingComponent,
    EmployeeManagementComponent,
    InvitationComponent,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    NoopAnimationsModule,
    AngularMultiSelectModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    NgbModule,
    RouterModule.forRoot(routes)],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
