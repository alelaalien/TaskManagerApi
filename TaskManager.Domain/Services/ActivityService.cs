using TaskManager.Domain.CustomEntities;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Domain.QueryFilters;

namespace TaskManager.Domain.Services
{
    //Agregar las reglas de negocio en su metodo correspondiente
    public class ActivityService : IActivityService 
    {
        //private readonly IActivityRepository _repository;
        private readonly IUnitOfWork _unitOfWork; // IBaseRepository<Activity> _repository; 
        //Agregar las interfaces de servicios necesarios aqui utilizando la expresion anterior
        //en caso de que la entidad herede de baseEntity :)
        public ActivityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(Activity activity)
        {
            await _unitOfWork.ActivityRespository.Create(activity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
              await _unitOfWork.ActivityRespository.Delete(id);
              await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public PagedList<Activity> GetAll(ActivityQueryFilter filter)
        {
            var activities =  _unitOfWork.ActivityRespository.GetAll();

            if (filter.UserId != null)
            {
                activities = activities.Where(x => x.UserId == filter.UserId);
            }

            if(filter.DetailOrName != null)
            {
                activities = activities.Where(x => (x.Detail.ToLower().Contains(filter.DetailOrName.ToLower())
                || x.Name.ToLower().Contains(filter.DetailOrName.ToLower())));
            }
             
            if (filter.CreatedOrUpdatedAt.HasValue)
            {
                activities = activities.Where(x =>

                    (x.CreatedAt.HasValue ?
                         x.CreatedAt.Value.ToShortDateString() == filter.CreatedOrUpdatedAt.Value.ToShortDateString() : false)
                         ||
                    (x.UpdatedAt.HasValue ?
                         x.UpdatedAt.Value.ToShortDateString() == filter.CreatedOrUpdatedAt.Value.ToShortDateString(): false)

                ); 
            }
            if(filter.Date.HasValue) activities = activities.Where(x =>
                    
                    x.Date.HasValue ? x.Date.Value.ToShortDateString() == filter.Date.Value.ToShortDateString() : false
                    );

            var pagedActivities = PagedList<Activity>.CreateList(activities, filter.PageNumber, filter.PageSize);
            
            return pagedActivities;
             
        }
            

        public async Task<Activity> GetById(int id)
        {
            return await _unitOfWork.ActivityRespository.GetById(id);
        }

        public async Task<bool> Update(Activity activity)
        {
             _unitOfWork.ActivityRespository.Update(activity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
