import { Button } from "@material-ui/core";
import React from "react";
import { OpenIdService } from "../../core/services/openidService";

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
      <h1>Welcome to LoginScreen!</h1>
      <Button onClick={(e) => onLoginButtonClick(e)}>Sign In</Button>
    </div>
  );
}

export default LoginScreen;
