using Microsoft.EntityFrameworkCore;
using TaskManager.Model.Helpers;

namespace TaskManager.Model.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddControllers();
            services.AddSingleton<IDatabaseHelper>(provider =>
            {
                var connectionString = config.GetConnectionString("DefaultConnection");
                return new DatabaseHelper(connectionString);
            });

            services.AddCors();
            return services;
        }
    }
}
