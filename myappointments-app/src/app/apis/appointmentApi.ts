import axios from "axios";
import {
  IAppointment,
  IUpdateAppointment,
} from "../shared/interfaces/IAppointment";
import {
  getConfig,
  apiUrl,
  getConfigWithParams,
} from "../shared/utils/apiConfigs";
import { handleResponse, handleError } from "../shared/utils/apiUtils";

export const createAppointment = async (appointment: IAppointment) => {
  return await axios
    .post(`${apiUrl}/Appointment`, appointment, getConfig())
    .then(handleResponse)
    .catch(handleError);
};

export const updateAppointment = async (appointment: IUpdateAppointment) => {
  return await axios
    .put(`${apiUrl}/Appointment`, appointment, getConfig())
    .then(handleResponse)
    .catch(handleError);
};

export const getAllAppointments = async () => {
  return await axios
    .get(`${apiUrl}/Appointment`, getConfig())
    .then(handleResponse)
    .catch(handleError);
};

export const getAllAppointmentsByName = async () => {
  return await axios
    .get(`${apiUrl}/Appointment/GetAllByName`, getConfig())
    .then(handleResponse)
    .catch(handleError);
};

export const deleteAppointment = async (id: number) => {
  return await axios
    .delete(`${apiUrl}/Appointment`, getConfigWithParams({ id: id }))
    .then(handleResponse)
    .catch(handleError);
};
