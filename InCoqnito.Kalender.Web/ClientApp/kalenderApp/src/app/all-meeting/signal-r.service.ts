import { Injectable } from '@angular/core';
import { IinvitationVM } from '../models/invitationVM';
import * as signalR from '@aspnet/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  public data: IinvitationVM[];
 
private hubConnection: signalR.HubConnection
 
  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
                            .withUrl('https://localhost:44336/rating')
                            .build();
 
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err))
  }
 
  public addTransferDataListener = () => {
    this.hubConnection.on('rating', (data) => {
      this.data = data;
      console.log(data);
    });
  }
}
