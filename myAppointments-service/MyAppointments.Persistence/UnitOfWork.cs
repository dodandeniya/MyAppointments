using MyAppointments.Application.Interfaces;
using MyAppointments.Persistence.Repositories;
using System.Threading.Tasks;

namespace MyAppointments.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyAppointmentsDbContext dbContext;
        private IAppointmentRepository appointments = null;

        public UnitOfWork(MyAppointmentsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IAppointmentRepository Appointments => appointments ??= new AppointmentRepository(dbContext);

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
