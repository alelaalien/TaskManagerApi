using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Infraestructure.Data;

namespace TaskManager.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiDbContext _context;
        private readonly IActivityRepository _activityRepository;
        private readonly IBaseRepository<User> _userRepository;

        //agregar los demas
        public UnitOfWork(ApiDbContext context)
        {
            _context = context;
        }
        public IActivityRepository  ActivityRespository => _activityRepository ?? new ActivityRepository(_context);

        public IBaseRepository<User> UserRespository => _userRepository ?? new BaseRepository<User>(_context);
         
        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
           await  _context.SaveChangesAsync();
        }
    }
}
