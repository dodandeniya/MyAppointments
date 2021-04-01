using Microsoft.EntityFrameworkCore;
using MyAppointments.Domain.Appointment;
using MyAppointments.Persistence.Appointments;

namespace MyAppointments.Persistence
{
    public class MyAppointmentsDbContext : DbContext
    {
        public MyAppointmentsDbContext(DbContextOptions<MyAppointmentsDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Appointment> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
        }
    }
}
