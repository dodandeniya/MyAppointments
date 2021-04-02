import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./app/App";
import reportWebVitals from "./reportWebVitals";
import CssBaseline from "@material-ui/core/CssBaseline";
import { BrowserRouter as Router } from "react-router-dom";
import { Provider } from "react-redux";
import store from "./app/redux/store";
import { OidcProvider } from "redux-oidc";
import { OpenIdService } from "./app/core/services/openidService";

ReactDOM.render(
  <Provider store={store}>
    <Router>
      <CssBaseline />
      <OidcProvider
        store={store}
        userManager={OpenIdService.getInstance().userManager}
      >
        <App />
      </OidcProvider>
    </Router>
  </Provider>,
  document.getElementById("root")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
