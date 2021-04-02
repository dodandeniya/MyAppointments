import { createStore, applyMiddleware } from "redux";
import thunk from "redux-thunk";
import { composeWithDevTools } from "redux-devtools-extension";
import rootReducer from "./reducers";
import { loadUser } from "redux-oidc";
import { OpenIdService } from "../core/services/openidService";

const initialState = {};

const middleware = [thunk];

const store = createStore(
  rootReducer,
  initialState as any,
  composeWithDevTools(applyMiddleware(...middleware))
);

loadUser(store, OpenIdService.getInstance().userManager);

export default store;
