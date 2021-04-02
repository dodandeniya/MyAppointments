import { UserManager, WebStorageStateStore } from "oidc-client";
import { environment as envDev } from "../../../environments/environment";
import { environment as envProd } from "../../../environments/environment.prod";

export class OpenIdService {
  private static instance: OpenIdService;
  public userManager: UserManager;

  private constructor() {
    this.userManager = new UserManager(this.getConfig());
  }

  public static getInstance(): OpenIdService {
    if (!OpenIdService.instance) {
      OpenIdService.instance = new OpenIdService();
    }

    return OpenIdService.instance;
  }

  async login() {
    this.userManager.signinRedirect();
  }

  async logout() {
    this.userManager.signoutRedirect();
  }

  startSilentRenew() {
    this.userManager.startSilentRenew();
  }

  get events() {
    return this.userManager.events;
  }

  signinSilent() {
    return this.userManager.signinSilent();
  }

  async getUser() {
    return await this.userManager.getUser();
  }

  getSigninRedirectCallback() {
    return this.userManager.signinRedirectCallback();
  }

  signinSilentCallback() {
    return this.userManager.signinSilentCallback();
  }

  private getConfig() {
    let hostUrl =
      process.env.NODE_ENV === "production"
        ? envProd.myAppointmentURL
        : envDev.myAppointmentURL;
    return {
      authority:
        process.env.NODE_ENV === "production"
          ? envProd.identityServerURL
          : envDev.identityServerURL,
      client_id: "myAppoiments_spa",
      redirect_uri: `${hostUrl}/callback`,
      response_type: "id_token token",
      scope: "openid profile myAppoiments_api",
      post_logout_redirect_uri: `${hostUrl}/login`,
      automaticSilentRenew: true,
      silent_redirect_uri: `${hostUrl}/silent_renew`,
      includeIdTokenInSilentRenew: true,
      monitorSession: false,
      userStore: new WebStorageStateStore({
        store: localStorage,
      }),
      stateStore: new WebStorageStateStore({
        store: localStorage,
      }),
    };
  }
}
