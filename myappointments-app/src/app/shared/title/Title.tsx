import React from 'react';
import Typography from '@material-ui/core/Typography';

export interface ITitleProps {
  children: any;
}

export default function Title(props: ITitleProps) {
  return (
    <Typography component="h2" variant="h6" gutterBottom>
      {props.children}
    </Typography>
  );
}
