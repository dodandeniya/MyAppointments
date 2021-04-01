using MediatR;
using MyAppointments.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyAppointments.Application.Appointments.Queries.GetAllAppointments
{
    public class GetAllAppointmentsQueryHandler : IRequestHandler<GetAllAppointmentsQuery, List<ViewAppointmentQueryDto>>
    {
        private readonly IUnitOfWork uow;
        public GetAllAppointmentsQueryHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<List<ViewAppointmentQueryDto>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return (await uow.Appointments.GetAll()).Select(s => new ViewAppointmentQueryDto
            {
                Id = s.Id,
                Name = s.AppointmentName,
                Description = s.Description
            }).ToList();
        }
    }
}
