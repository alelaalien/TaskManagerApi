using TaskManager.Domain.Interfaces;
using TaskManager.Infraestructure.Repositories;

namespace TaskManager.Presentation.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void AddSumary(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
