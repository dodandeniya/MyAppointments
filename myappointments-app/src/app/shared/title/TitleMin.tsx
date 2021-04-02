import React from "react";
import Typography from "@material-ui/core/Typography";

export interface ITitleProps {
  children: any;
}

export default function TitleMin(props: ITitleProps) {
  return (
    <Typography component="h4" gutterBottom>
      {props.children}
    </Typography>
  );
}
