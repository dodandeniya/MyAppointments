using Microsoft.EntityFrameworkCore;
using MyAppointments.Application.Interfaces;
using MyAppointments.Domain.Appointment;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppointments.Persistence.Repositories
{
    internal class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {


        public AppointmentRepository(MyAppointmentsDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IList<Appointment>> GetByUserName(string userName)
        {
            return await dbSet.Where(a => a.CreatedBy == userName).ToListAsync();
        }
    }
}