using System.Threading.Tasks;

namespace MyAppointments.Application.Interfaces
{
    public interface IUnitOfWork
    {
        public IAppointmentRepository Appointments { get; }
        void Save();
        Task SaveAsync();
    }
}
