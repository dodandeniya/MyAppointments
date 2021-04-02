import * as actions from "../../constants";

export const setErrors = (error: any) => async (dispatch: any) => {
  dispatch({ type: actions.ERROR_MESSAGES_RESET });
  dispatch({
    type: actions.ERROR_MESSAGES_SUCCESS,
    payload:
      error.response && error.response.data.message
        ? error.response.data.message
        : error.message,
  });
};
