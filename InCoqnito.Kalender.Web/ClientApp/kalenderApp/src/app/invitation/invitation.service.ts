import { Injectable } from '@angular/core';
import { throwError, Observable } from 'rxjs';
import { HttpErrorResponse, HttpHeaders, HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { RatingRequest } from '../models/RatingRequest';
import { IinvitationVM } from '../models/invitationVM';

@Injectable({
  providedIn: 'root'
})
export class InvitationService {

  constructor(private httpClient: HttpClient) { }

  getInvitationInfo(invId: number): Observable<IinvitationVM>{
    return this.httpClient.get<IinvitationVM>('https://localhost:44336/api/Invitation?id='+invId)
    .pipe(catchError(this.handleError));
  }
  
  submitRating(request: RatingRequest) {
    const body = JSON.stringify(request);
    const headerOptions = new HttpHeaders({ 'Content-Type': 'application/json'});
      return this.httpClient.post<boolean>('https://localhost:44336/api/Rating', body, {
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
