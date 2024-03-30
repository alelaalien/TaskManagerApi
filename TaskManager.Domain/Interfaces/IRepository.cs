using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Create(T entity);
        Task Delete(int id);
        Task Update(int id);
    }
}
