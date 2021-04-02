import * as actions from "../constants";

interface IAppointmentTypes {
  type:
    | typeof actions.GET_ALL_APPOINTMENTS_BY_NAME_FAIL
    | typeof actions.GET_ALL_APPOINTMENTS_BY_NAME_REQUEST
    | typeof actions.GET_ALL_APPOINTMENTS_BY_NAME_SUCCESS;

  payload: any;
}

export type AppointmentTypes = IAppointmentTypes;
