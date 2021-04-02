import * as actions from "../../constants";
import { AppointmentTypes } from "../../actions/actionTypes";
import { initialAppointmentList } from "../../initialStates";
import { IAppointment } from "../../../shared/interfaces/IAppointment";

export const getAppointmentsReducer = (
  state = initialAppointmentList,
  action: AppointmentTypes
) => {
  switch (action.type) {
    case actions.GET_ALL_APPOINTMENTS_BY_NAME_REQUEST:
      return state;
    case actions.GET_ALL_APPOINTMENTS_BY_NAME_SUCCESS:
      return { myAppointments: action.payload as Array<IAppointment> };
    case actions.GET_ALL_APPOINTMENTS_BY_NAME_FAIL:
      return { error: action.payload as string };
    default:
      return state;
  }
};
