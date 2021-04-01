using Common.Exceptions;
using MediatR;
using MyAppointments.Application.Interfaces;
using MyAppointments.Domain.Appointment;
using System.Threading;
using System.Threading.Tasks;

namespace MyAppointments.Application.Appointments.Commands.DeleteAppointment
{
    public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, int>
    {
        private readonly IUnitOfWork uow;

        public DeleteAppointmentCommandHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<int> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Appointment appointment = await uow.Appointments.GetById(request.Id);
            if (appointment == null)
            {
                throw new CustomValidationException(new ErrorModel("UpdateAppointment", "Appointment is not found for given id"));
            }

            await uow.Appointments.Delete(appointment.Id);
            await uow.SaveAsync();

            return appointment.Id;
        }
    }
}
