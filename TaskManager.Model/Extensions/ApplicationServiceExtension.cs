using TaskManager.Model.Helpers;
using TaskManager.Model.Repository;

namespace TaskManager.Model.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            SQLitePCL.Batteries.Init();
            services.AddControllers();

            services.AddSingleton<IDatabaseHelper>(provider =>
            {
                var connectionString = config.GetConnectionString("DefaultConnection");
                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new InvalidOperationException("Database connection string is not configured.");
                }
                return new DatabaseHelper(connectionString);
            });
            services.AddScoped<ITasksRepository, TasksRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IStatesRepository, StateRepository>();
            services.AddScoped<IPrioritiesRepository, PrioritiesRepository>();

            return services;
        }
    }
}
