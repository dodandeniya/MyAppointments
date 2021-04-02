import { combineReducers } from "redux";
import { errorsReducer } from "./errors/errorsReducer";
import { reducer as oidcReducer } from "redux-oidc";
import { getAppointmentsReducer } from "./appointment/appointmentReducers";

const rootReducer = combineReducers({
  oidc: oidcReducer,
  errors: errorsReducer,
  appointments: getAppointmentsReducer,
});

export default rootReducer;
export type RootState = ReturnType<typeof rootReducer>;
