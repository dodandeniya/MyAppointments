using MyAppointments.Domain.Appointment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAppointments.Application.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        public Task<IList<Appointment>> GetByUserName(string userName);
    }
}