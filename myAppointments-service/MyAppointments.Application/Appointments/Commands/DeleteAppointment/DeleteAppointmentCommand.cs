using MediatR;

namespace MyAppointments.Application.Appointments.Commands.DeleteAppointment
{
    public class DeleteAppointmentCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
