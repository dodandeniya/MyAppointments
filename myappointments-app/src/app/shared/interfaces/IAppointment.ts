export interface IAppointment {
  name: string;
  description: string;
}

export interface IUpdateAppointment extends IAppointment {
  id: number;
}
