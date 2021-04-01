using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyAppointments.Application.Interfaces;

namespace MyAppointments.Persistence
{
    public static class Configurations
    {
        public static void AddEFConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration["dbConnectionString"];

            services.AddDbContext<MyAppointmentsDbContext>(opts =>
             opts.UseSqlite(connectionString)
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
