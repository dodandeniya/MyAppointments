import React from "react";
import { useHistory } from "react-router";
import { OpenIdService } from "../../../../core/services/openidService";
import { CallbackComponent } from "redux-oidc";

/* eslint-disable-next-line */
export interface CallbackScreenProps {}

export function CallbackScreen() {
  const history = useHistory();

  return (
    <CallbackComponent
      userManager={OpenIdService.getInstance().userManager}
      successCallback={() => history.push("/dashboard")}
      errorCallback={(error) => {
        history.push("/error");
        console.error(error);
      }}
    >
      <div>Redirecting...</div>
    </CallbackComponent>
  );
}

export default CallbackScreen;
