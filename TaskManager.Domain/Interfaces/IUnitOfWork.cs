using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IActivityRepository ActivityRespository { get; }
        IBaseRepository<User> UserRespository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
