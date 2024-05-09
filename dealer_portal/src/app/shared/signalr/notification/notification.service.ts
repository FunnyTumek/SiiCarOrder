import { Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr";
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSnackBarConfig } from '@angular/material/snack-bar';
import { NotificationData } from './notification-data.model';
import { NotificationType } from '../../enums/notification-type.enum';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {

  private durationInMiliseconds = 3000;
  private url = environment.apiUrl;

  private hubConnection: signalR.HubConnection = new signalR.HubConnectionBuilder()
    .withUrl(`${this.url}/notificationHub`, {
      skipNegotiation: true,
      transport: signalR.HttpTransportType.WebSockets
    })
    .build();

  constructor(private _snackBar: MatSnackBar) { }

  public startConnection = () => {
    this.hubConnection
      .start()
      .then(() => console.log('SignalR: Connection started'))
      .catch(err => console.log('SignalR: Error while starting connection: ' + err))
  }

  public addNotificationDataListener = () => {
    this.hubConnection.on('TransferNotificationData', (data: NotificationData) => {
      if (data !== undefined) {
        this.openSnackBar(data);
      }
    });
  }

  private openSnackBar(data: NotificationData) {
    const config = new MatSnackBarConfig();
      config.duration = this.durationInMiliseconds;
    switch (data.type) {
      case NotificationType.Success:
        config.panelClass = 'notification-success-snackbar';
        break;
      case NotificationType.Warning:
        config.panelClass = 'notification-warning-snackbar';
        break;
      case NotificationType.Error:
        config.panelClass = 'notification-error-snackbar';
        break;
    }
    this._snackBar.open(data.message, undefined, config);
  }

}
