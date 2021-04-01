using Common.Account;
using MediatR;
using MyAppointments.Application.Interfaces;
using MyAppointments.Domain.Appointment;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyAppointments.Application.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, int>
    {
        private readonly IUnitOfWork uow;
        private readonly IUserIdentity identity;

        public CreateAppointmentCommandHandler(IUnitOfWork uow, IUserIdentity identity)
        {
            this.uow = uow;
            this.identity = identity;
        }

        public async Task<int> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Appointment appointment = new Appointment
            {
                AppointmentName = request.Name,
                Description = request.Description,
                CreatedBy = identity.UserName,
                CreatedDateTime = DateTimeOffset.Now
            };

            uow.Appointments.Create(appointment);
            await uow.SaveAsync();
            return appointment.Id;
        }
    }
}
