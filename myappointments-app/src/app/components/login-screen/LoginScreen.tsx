import { Button } from "@material-ui/core";
import React from "react";
import { OpenIdService } from "../../core/services/openidService";
import Title from "../../shared/title/Title";

/* eslint-disable-next-line */
export interface LoginScreenProps {}

export function LoginScreen() {
  const onLoginButtonClick = async (e: any) => {
    const oidc = OpenIdService.getInstance();
    e.preventDefault();
    await oidc.login();
  };

  return (
    <div>
      <Title>Login</Title>
      <Button
        onClick={(e) => onLoginButtonClick(e)}
        variant="contained"
        color="primary"
      >
        Sign In
      </Button>
    </div>
  );
}

export default LoginScreen;
