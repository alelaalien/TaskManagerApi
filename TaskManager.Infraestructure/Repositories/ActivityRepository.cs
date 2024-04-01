using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Infraestructure.Data;

namespace TaskManager.Infraestructure.Repositories
{
    public class ActivityRepository : BaseRepository<Activity>, IActivityRepository
    {
       
        public ActivityRepository(ApiDbContext context) : base(context)
        {
                
        }
        public async Task<IEnumerable<Activity>> GetAllByUserId(int userId)
        {
           return await  _entities.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
