using MediatR;

namespace MyAppointments.Application.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
