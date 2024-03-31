using TaskManager.Domain.Interfaces;
using TaskManager.Domain.Services;
using TaskManager.Infraestructure.Repositories;

namespace TaskManager.Presentation.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void AddSumary(this IServiceCollection services)
        {
            //reemplazados por repositorio generico
            //services.AddTransient<IUserRepository, UserRepository>();
            //services.AddTransient<IActivityRepository, ActivityRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IActivityService, ActivityService>(); 
        }
    }
}
