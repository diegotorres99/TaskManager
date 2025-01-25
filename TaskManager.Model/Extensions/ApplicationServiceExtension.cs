﻿using TaskManager.Model.Data.Migrations;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Model.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddControllers();
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors();
            //services.AddScoped<ITokenService, TokenService>();
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<ILikesRepository, LikesRepository>();
            //services.AddScoped<IPhotoService, PhotoService>();
            //services.AddScoped<IMessageRepository, MessageRepository>();
            //services.AddScoped<LogUserActivity>();
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            return services;
        }
    }
}
