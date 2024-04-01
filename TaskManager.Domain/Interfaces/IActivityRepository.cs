
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces
{
    public interface IActivityRepository : IBaseRepository<Activity>
    {
        Task<IEnumerable<Activity>> GetAllByUserId(int userId);
        //llevados al unit
        //Task Create(Activity activity);
        //Task<Activity> GetById(int id);
        //Task<bool> Delete(int id);
        //Task<bool> Update(Activity activity); 
    }
}
