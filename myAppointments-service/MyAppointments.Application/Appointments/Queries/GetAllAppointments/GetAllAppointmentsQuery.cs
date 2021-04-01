using MediatR;
using System.Collections.Generic;

namespace MyAppointments.Application.Appointments.Queries.GetAllAppointments
{
    public class GetAllAppointmentsQuery : IRequest<List<ViewAppointmentQueryDto>>
    {
    }
}
