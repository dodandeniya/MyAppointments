import * as actions from "../../constants";
import * as api from "../../../apis/appointmentApi";
import { setErrors } from "../errors/errorsActions";

export const getAllAppointmentsByName = () => async (
  dispatch: any,
  getState: any
) => {
  try {
    dispatch({ type: actions.GET_ALL_APPOINTMENTS_BY_NAME_REQUEST });
    const data = await api.getAllAppointmentsByName();
    dispatch({
      type: actions.GET_ALL_APPOINTMENTS_BY_NAME_SUCCESS,
      payload: data,
    });
  } catch (error) {
    dispatch({
      type: actions.GET_ALL_APPOINTMENTS_BY_NAME_FAIL,
      payload:
        error.response && error.response.data.message
          ? error.response.data.message
          : error.message,
    });
    dispatch(setErrors(error));
  }
};
