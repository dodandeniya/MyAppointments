import React from "react";
import { processSilentRenew } from "redux-oidc";

/* eslint-disable-next-line */
export interface SilentRenewScreenProps {}

export function SilentRenewScreen(props: SilentRenewScreenProps) {
  processSilentRenew();
  return (
    <div>
      <h1>Welcome to SilentRenewScreen!</h1>
    </div>
  );
}

export default SilentRenewScreen;
