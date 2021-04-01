using Common.Account;
using MediatR;
using MyAppointments.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyAppointments.Application.Appointments.Queries.GetAllByUserName
{
    public class GetAllByUserNameQueryHandler : IRequestHandler<GetAllByUserNameQuery, List<ViewAppointmentByUserNameDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IUserIdentity identity;

        public GetAllByUserNameQueryHandler(IUnitOfWork uow, IUserIdentity identity)
        {
            this.uow = uow;
            this.identity = identity;
        }

        public async Task<List<ViewAppointmentByUserNameDto>> Handle(GetAllByUserNameQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return (await uow.Appointments.GetByUserName(identity.UserName)).Select(s => new ViewAppointmentByUserNameDto
            {
                Id = s.Id,
                Name = s.AppointmentName,
                Description = s.Description
            }).ToList();
        }
    }
}
