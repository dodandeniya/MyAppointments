using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyAppointments.Application.Appointments.Commands.CreateAppointment;
using MyAppointments.Application.Appointments.Commands.DeleteAppointment;
using MyAppointments.Application.Appointments.Commands.UpdateAppointment;
using MyAppointments.Application.Appointments.Queries.GetAllAppointments;
using MyAppointments.Application.Appointments.Queries.GetAllByUserName;

namespace MyAppointments.Api.MediatR
{
    public static class MediatRConfiguration
    {
        public static void AddMediatRConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(
                typeof(CreateAppointmentCommandHandler),
                typeof(UpdateAppointmentCommandHandler),
                typeof(DeleteAppointmentCommandHandler),
                typeof(GetAllAppointmentsQueryHandler),
                typeof(GetAllByUserNameQueryHandler)
            );
        }
    }
}
