import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IEmployee } from '../models/IEmployeeDto';

@Injectable({
  providedIn: 'root'
})
export class NewmeetingService {

  constructor(private httpClient: HttpClient) { }

  getEmployeesInfo(): Observable<IEmployee[]>{
    return this.httpClient.get<IEmployee[]>('https://localhost:44336/api/employee');
  }
  
}
