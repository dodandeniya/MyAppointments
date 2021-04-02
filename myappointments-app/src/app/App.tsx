import { Container, Grid } from "@material-ui/core";
import React from "react";
import { Header } from "./core/header/Header";
import Router from "./core/router/Router";
import { useStyles } from "./styles/style";
import { useSelector } from "react-redux";
import { RootState } from "./redux/reducers";
import TostNotification from "./shared/tostNotification/TostNotification";

export interface IAppProps {}

export default function App(props: IAppProps) {
  const classes = useStyles();
  const errors = useSelector((state: RootState) => state.errors);

  return (
    <>
      <Header />
      <Container maxWidth="lg" className={classes.container}>
        <Grid container spacing={3}>
          <Router />
        </Grid>
      </Container>
      {errors && <TostNotification messages={errors.errors} severity="error" />}
    </>
  );
}
