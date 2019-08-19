import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import {catchError} from 'rxjs/operators';
import { IEmployee } from '../models/IEmployeeDto';
import { InvitationRequest } from '../models/InvitationRequest';

@Injectable({
  providedIn: 'root'
})
export class NewmeetingService {

  constructor(private httpClient: HttpClient) { }

  getEmployeesInfo(): Observable<IEmployee[]>{
    return this.httpClient.get<IEmployee[]>('https://localhost:44336/api/employee')
    .pipe(catchError(this.handleError));
  }
  
  shareMeeting(request: InvitationRequest) {
    const body = JSON.stringify(request);
    const headerOptions = new HttpHeaders({ 'Content-Type': 'application/json'});
      return this.httpClient.post<boolean>('https://localhost:44336/api/Invitation', body, {
        headers: headerOptions
      }).pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // return an observable with a user-facing error message
    return throwError(
      'Something bad happened; please try again later.');
  };
}
