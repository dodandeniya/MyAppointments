import { environment as envDev } from "../../../environments/environment";
import { environment as envProd } from "../../../environments/environment.prod";
import store from "../../redux/store";

export const getConfig = () => {
  const state = store.getState();

  return {
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${state?.oidc?.user?.access_token}`,
    },
  };
};

export const getConfigWithParams = (params: any) => {
  const state = store.getState();
  return {
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${state?.oidc?.user?.access_token}`,
    },
    params: params,
  };
};

export const apiUrl =
  process.env.NODE_ENV === "production"
    ? envProd.myAppointmentServiceURL
    : envDev.myAppointmentServiceURL;
