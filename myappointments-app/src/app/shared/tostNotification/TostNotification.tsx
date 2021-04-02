import React, { useEffect, useState } from 'react';
import { Snackbar } from '@material-ui/core';
import MuiAlert, { AlertProps, Color } from '@material-ui/lab/Alert';

function Alert(props: AlertProps) {
  return <MuiAlert elevation={6} variant="filled" {...props} />;
}

export interface ITostNotificationProps {
  messages: any;
  severity: Color;
}

export default function TostNotification(props: ITostNotificationProps) {
  const [open, setOpen] = useState(false);

  useEffect(() => {
    if (props.messages) {
      setOpen(true);
    }
  }, [props.messages]);

  const handleClose = (event?: React.SyntheticEvent, reason?: string) => {
    if (reason === 'clickaway') {
      return;
    }

    setOpen(false);
  };

  return (
    <div>
      <Snackbar open={open} autoHideDuration={6000} onClose={handleClose}>
        <Alert onClose={handleClose} severity={props.severity}>
          {props.messages}
        </Alert>
      </Snackbar>
    </div>
  );
}
