using TaskManager.Domain.Interfaces;
using TaskManager.Domain.Services;
using TaskManager.Infraestructure.Interfaces;
using TaskManager.Infraestructure.Repositories;
using TaskManager.Infraestructure.Services;

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
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IUriService>(provider =>
                {
                    var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                    var request = accesor.HttpContext.Request;
                    var absolutelyUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent(), "/");

                    return new UriService(absolutelyUri);

                }
            );
        }
    }
}
