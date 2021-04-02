import { AppBar, IconButton, Toolbar, Typography } from "@material-ui/core";
import React from "react";
import { useSelector } from "react-redux";
import { RootState } from "../../redux/reducers";
import { useStyles } from "../../styles/style";
import PersonIcon from "@material-ui/icons/Person";

export interface IHeader {}

export function Header(props: IHeader) {
  const classes = useStyles();
  const user = useSelector((state: RootState) => state.oidc.user);

  return (
    <AppBar position="static">
      <Toolbar>
        <Typography variant="h6">My Appointments</Typography>
        {user && !user.expired && (
          <>
            <IconButton color="inherit" className={classes.menuButton}>
              <PersonIcon />
            </IconButton>
            <label>{user.profile.name}</label>
          </>
        )}
      </Toolbar>
    </AppBar>
  );
}
