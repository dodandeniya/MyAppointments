using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyAppointments.Application.Appointments.Commands.CreateAppointment;

namespace MyAppointments.Api.MediatR
{
    public static class MediatRConfiguration
    {
        public static void AddMediatRConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(
                typeof(CreateAppointmentCommandHandler)
            );
        }
    }
}
