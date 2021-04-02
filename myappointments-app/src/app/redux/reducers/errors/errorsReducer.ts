import { ERROR_MESSAGES_RESET, ERROR_MESSAGES_SUCCESS } from "../../constants";

export const errorsReducer = (state: any = null, action: any) => {
  switch (action.type) {
    case ERROR_MESSAGES_RESET:
      return null;
    case ERROR_MESSAGES_SUCCESS:
      return {
        errors: action.payload,
      };
    default:
      return state;
  }
};
