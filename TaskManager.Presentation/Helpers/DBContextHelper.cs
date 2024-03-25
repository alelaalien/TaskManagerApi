using TaskManager.Infraestructure.Data; 
using Microsoft.EntityFrameworkCore;
namespace TaskManager.Presentation.Helpers
{
    public static class DBContextHelper
    {
        public static void AddConfiguratedDBFromTheAppSettingStringConnection(this IServiceCollection services)
        {
            var cd = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build();
            services.AddDbContext<ApiDbContext>(options =>

                options.UseSqlServer(
                        cd.GetConnectionString("TaskManager")
                    )

            );  
        }

    }
}
