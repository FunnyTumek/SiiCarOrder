import {IconButton, Snackbar, Button} from '@material-ui/core';
import {Close} from '@material-ui/icons';
import MuiAlert, { Alert, AlertProps, AlertColor } from '@mui/material';
import React from "react";

type Props = {
    open: boolean,
    snackbarType: AlertColor,
    snackbarMessage: string,
    handleCloseSnackbarClick: React.MouseEventHandler
  }

export default function NotificationSnackbar(props: any) {

    return (
        <Snackbar
          anchorOrigin={{
          horizontal: "center",
          vertical: "bottom",
          }}
          open={props.open}
          action={
            <React.Fragment>
              <IconButton
                size="small"
                aria-label="close"
                color="inherit"
                onClick={props.onClick}
              >
                <Close fontSize="small" />
              </IconButton>
            </React.Fragment>
          }
        >
          <Alert severity={props.snackbarType} onClose={props.handleCloseSnackbarClick}>{props.snackbarMessage}</Alert>
        </Snackbar> 
    )
}