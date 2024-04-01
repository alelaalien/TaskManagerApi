using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Infraestructure.Data;

namespace TaskManager.Infraestructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ApiDbContext _context;
        protected DbSet<T> _entities;

        public BaseRepository(ApiDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public async Task Create(T entity)
        {
           await _context.AddAsync(entity);
          //  await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
             var entity = await GetById(id);
             _entities.Remove(entity);
           //  await _context.SaveChangesAsync();
        }

        public   IEnumerable<T>  GetAll()
        {
            return   _entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public  void Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
           _entities.Update(entity);
         //  await _context.SaveChangesAsync();
        }
    }
}
