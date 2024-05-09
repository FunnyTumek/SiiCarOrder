import {IconButton, Snackbar, Button} from '@material-ui/core';
import {Close} from '@material-ui/icons';
import { Alert, AlertColor } from '@mui/material';
import React from "react";
import { HubConnectionBuilder, HttpTransportType } from '@microsoft/signalr';
import { BASEURL } from "../constant/connection/ConnectionConstants";

export default function NotificationSnackbar(){
    const handleCloseSnackbarClick = () => {
      setOpen(false);
    }
    
    const [open, setOpen] = React.useState(false);
    const [snackbarMessage, setSnackbarMessage] = React.useState("");
    const [snackbarType, setSnackbarType] = React.useState<AlertColor>('info');

    const connection = new HubConnectionBuilder()
      .withUrl(`${BASEURL}/notifications`, { skipNegotiation : true, transport : HttpTransportType.WebSockets})
      .withAutomaticReconnect()
      .build();
    
    connection.start();
    
    connection.on('SendNotification', (type, message) => {
      switch(type){
        case "Success": setSnackbarType('success'); break;
        case "Warning": setSnackbarType('warning'); break;
        case "Error": setSnackbarType('error'); break;
        default: setSnackbarType('info'); break;
      };
    
      setSnackbarMessage(message);
      setOpen(true);
    });

    return (
      <Snackbar
        anchorOrigin={{
          horizontal: "center",
          vertical: "bottom",
        }}
        open={open}
        action={
          <React.Fragment>
            <IconButton
              size="small"
              aria-label="close"
              color="inherit"
              onClick={handleCloseSnackbarClick}
            >
              <Close fontSize="small" />
            </IconButton>
          </React.Fragment>
}
>
<Alert severity={snackbarType} onClose={handleCloseSnackbarClick}>{snackbarMessage}</Alert>
</Snackbar>
    );
}