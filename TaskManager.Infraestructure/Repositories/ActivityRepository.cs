

using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Infraestructure.Data;

namespace TaskManager.Infraestructure.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private ApiDbContext _database;

        public ActivityRepository(ApiDbContext dbContext)
        {
            _database = dbContext;
        }
        public async Task Create(Activity activity)
        {
            _database.Activities.Add(activity);
            await _database.SaveChangesAsync(); 
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Activity>> GetAll()
        {
            var activities = await _database.Activities.ToListAsync();

            return activities;
            
        }

        public async Task<Activity> GetById(int id)
        {
            var activity = await _database
                                    .Activities
                                    .SingleOrDefaultAsync(
                                       item => item.ActivityId == id
                                    );
            return activity;
        }

        public Task<Activity> Update(Activity activity)
        {
            throw new NotImplementedException();
        }
    }
}
