using Common.Account;
using Common.Exceptions;
using MediatR;
using MyAppointments.Application.Interfaces;
using MyAppointments.Domain.Appointment;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyAppointments.Application.Appointments.Commands.UpdateAppointment
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, int>
    {
        private readonly IUnitOfWork uow;
        private readonly IUserIdentity identity;

        public UpdateAppointmentCommandHandler(IUnitOfWork uow, IUserIdentity identity)
        {
            this.uow = uow;
            this.identity = identity;
        }

        public async Task<int> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Appointment appointment = await uow.Appointments.GetById(request.Id);
            if (appointment == null)
            {
                throw new CustomValidationException(new ErrorModel("UpdateAppointment", "Appointment is not found for given id"));
            }

            appointment.AppointmentName = request.Name;
            appointment.Description = request.Description;
            appointment.ModifiedBy = identity.UserName;
            appointment.ModifiedDateTime = DateTimeOffset.Now;

            uow.Appointments.Update(appointment);
            await uow.SaveAsync();

            return appointment.Id;
        }
    }
}
