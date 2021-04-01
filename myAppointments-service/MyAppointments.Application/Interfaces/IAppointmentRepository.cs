using MyAppointments.Domain.Appointment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAppointments.Application.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<List<Appointment>> GetByUserName(string userName);
    }
}