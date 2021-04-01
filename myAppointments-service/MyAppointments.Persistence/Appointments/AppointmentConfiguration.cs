using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAppointments.Domain.Appointment;

namespace MyAppointments.Persistence.Appointments
{
    internal class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointment");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.AppointmentName)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(p => p.Description).HasMaxLength(3000);
        }
    }
}