using TaskManager.Domain.CustomEntities;
using TaskManager.Domain.Entities;
using TaskManager.Domain.QueryFilters;

namespace TaskManager.Domain.Interfaces
{
    public interface IActivityService
    {
        Task Create(Activity activity);
        PagedList<Activity>  GetAll(ActivityQueryFilter filter);
        Task<Activity> GetById(int id); 
        Task<bool> Delete(int id);
        Task<bool> Update(Activity activity);
    }
}