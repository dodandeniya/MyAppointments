import React from "react";
import { Route, Switch } from "react-router-dom";
import Home from "../../components/home/Home";
import LoginScreen from "../../components/login-screen/LoginScreen";
import CallbackScreen from "../../components/modules/authentication/callback-screen/CallbackScreen";
import SilentRenewScreen from "../../components/modules/authentication/silent-renew-screen/SilentRenewScreen";
import DashboardScreen from "../../components/modules/dashboard/DashboardScreen";

const Router = () => {
  return (
    <Switch>
      <Route path="/login" component={LoginScreen} />
      <Route path="/callback" component={CallbackScreen} />
      <Route path="/silent_renew" component={SilentRenewScreen} />
      <Route path="/dashboard" component={DashboardScreen} />
      <Route path="/" component={Home} />
    </Switch>
  );
};

export default Router;
