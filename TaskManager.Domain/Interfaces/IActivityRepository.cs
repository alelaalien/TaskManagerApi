
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces
{
    public interface IActivityRepository
    {
        Task<IEnumerable<Activity>> GetAll();
        Task<Activity> GetById(int id);
        Task Create(Activity activity);
        Task<bool> Delete(int id);
        Task<Activity> Update(Activity activity); 
    }
}
