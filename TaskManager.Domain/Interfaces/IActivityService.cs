using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces
{
    public interface IActivityService
    {
        Task Create(Activity activity);
        IEnumerable<Activity>  GetAll();
        Task<Activity> GetById(int id); 
        Task<bool> Delete(int id);
        Task<bool> Update(Activity activity);
    }
}