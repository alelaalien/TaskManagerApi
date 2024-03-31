//reemplazado por repositorio genrerico

namespace TaskManager.Infraestructure.Repositories
{
    //public class ActivityRepository : IActivityRepository
    //{
    //    private ApiDbContext _database;

    //    public ActivityRepository(ApiDbContext dbContext)
    //    {
    //        _database = dbContext;
    //    }
    //    public async Task Create(Activity activity)
    //    {
    //        _database.Activities.Add(activity);
    //        await _database.SaveChangesAsync(); 
    //    }

    //    public async Task<bool> Delete(int id)
    //    {
    //        var currentActivity = await GetById(id);
    //        _database.Activities.Remove(currentActivity);
    //        var row = await _database.SaveChangesAsync();
    //        return row > 0;
    //    } 
    //    public async Task<Activity> GetById(int id)
    //    {
    //        var activity = await _database
    //                                .Activities
    //                                .SingleOrDefaultAsync(
    //                                   item => item.Id == id
    //                                );
    //        return activity;
    //    }

    //    public async Task<bool> Update(Activity activity)
    //    {
    //        var currentActivity = await GetById(activity.Id);
    //        currentActivity.Date = activity.Date;
    //        currentActivity.Detail = activity.Detail;
    //        currentActivity.Name = activity.Name;
    //        currentActivity.UpdatedAt = DateTime.Now;

    //        int row = await _database.SaveChangesAsync();
    //        return row > 0;
    //    }
    //    public async Task<IEnumerable<Activity>> GetAll()
    //    {
    //        var activities = await _database.Activities.ToListAsync();

    //        return activities;

    //    }
    //}
}
