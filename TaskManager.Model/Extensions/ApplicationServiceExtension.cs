using TaskManager.Model.Helpers;
using TaskManager.Model.Repository;

namespace TaskManager.Model.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
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

            // Configure CORS policy (replace "YourPolicyName" as needed)
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("YourPolicyName", builder =>
            //    {
            //        builder.WithOrigins("https://your-frontend-domain.com") // Allow specific origins
            //               .AllowAnyMethod()
            //               .AllowAnyHeader();
            //    });
            //});

            return services;
        }
    }
}
