using MyAppointments.Domain.Interfaces;
using System;

namespace MyAppointments.Domain.Appointment
{
    public class Appointment : ITraceEntity
    {
        public int Id { get; set; }
        public string AppointmentName { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
    }
}
