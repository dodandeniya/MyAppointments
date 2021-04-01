using MediatR;
using System.Collections.Generic;

namespace MyAppointments.Application.Appointments.Queries.GetAllByUserName
{
    public class GetAllByUserNameQuery : IRequest<List<ViewAppointmentByUserNameDto>>
    {
    }
}
