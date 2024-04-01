using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task Create(T entity);
        Task Delete(int id);
        void Update(T entity);
    }
}
