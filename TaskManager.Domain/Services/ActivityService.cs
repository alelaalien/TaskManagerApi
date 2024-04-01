using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

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
        }

        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.ActivityRespository.Delete(id);
            return true;
        }

        public IEnumerable<Activity> GetAll()
        {
            return  _unitOfWork.ActivityRespository.GetAll();
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
