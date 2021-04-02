import React, { useEffect } from "react";
import Title from "../../../shared/title/Title";
import TitleMin from "../../../shared/title/TitleMin";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "../../../redux/reducers";
import { getAllAppointmentsByName } from "../../../redux/actions/appointment/appointmentActions";
import TableView from "../../../shared/table/TableView";
import { IAppointment } from "../../../shared/interfaces/IAppointment";

export interface IDashboardScreenProps {}

export default function DashboardScreen(props: IDashboardScreenProps) {
  const dispatch = useDispatch();
  const appointments = useSelector(
    (state: RootState) => state.appointments
  ) as any;

  useEffect(() => {
    if (appointments.myAppointments.length === 0) {
      dispatch(getAllAppointmentsByName());
    }
  }, [dispatch, appointments]);

  const handleEditItem = (item: IAppointment) => {
    console.log("edit");
  };

  const handleDeleteItem = (item: IAppointment) => {
    console.log("delete");
  };

  return (
    <div>
      <Title>Dash board</Title>
      <TitleMin>My Appointments</TitleMin>

      {appointments.myAppointments.length > 0 && (
        <TableView
          canDelete
          canEdit
          data={appointments.myAppointments}
          onEdit={handleEditItem}
          onDelete={handleDeleteItem}
        />
      )}
    </div>
  );
}
