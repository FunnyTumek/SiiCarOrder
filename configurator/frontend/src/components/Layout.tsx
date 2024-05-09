import theme from '../themes/theme';
import { Header } from './Header';
import { ThemeProvider } from '@mui/material';
import Content from './Content';
import { Outlet } from 'react-router-dom';

import { HubConnection, JsonHubProtocol, HubConnectionState, HubConnectionBuilder, LogLevel, HttpTransportType } from '@microsoft/signalr';
import {IconButton, Snackbar, Button} from '@material-ui/core';
import {Close} from '@material-ui/icons';
import MuiAlert, { Alert, AlertProps, AlertColor } from '@mui/material';
import React from "react";
import NotificationSnackbar from './NotificationSnackbar';

export default function Layout() {
  
  
  return (
    <ThemeProvider theme={theme}>
      <Header title="Sii Car" />

      <NotificationSnackbar></NotificationSnackbar>

      <Content>
        <Outlet />
      </Content>
    </ThemeProvider>
  )
}