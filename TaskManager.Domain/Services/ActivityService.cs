using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Domain.Services
{
    //Agregar las reglas de negocio en su metodo correspondiente
    public class ActivityService : IActivityService 
    {
        //private readonly IActivityRepository _repository;
        private readonly IBaseRepository<Activity> _repository; 
        //Agregar las interfaces de servicios necesarios aqui utilizando la expresion anterior
        //en caso de que la entidad herede de baseEntity :)
        public ActivityService(IBaseRepository<Activity> repository)
        {
            _repository = repository;
        }

        public async Task Create(Activity activity)
        {
            await _repository.Create(activity);
        }

        public async Task<bool> Delete(int id)
        {
            await _repository.Delete(id);
            return true;
        }

        public async Task<IEnumerable<Activity>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Activity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<bool> Update(Activity activity)
        {
            await _repository.Update(activity);
            return true;
        }
    }
}
