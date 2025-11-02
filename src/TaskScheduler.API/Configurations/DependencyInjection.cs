using Microsoft.EntityFrameworkCore;
using TaskScheduler.API.Data;
using TaskScheduler.API.Data.Repositories;
using TaskScheduler.API.Services;
using TaskScheduler.API.Services.Interfaces;
using ITaskRepository = TaskScheduler.API.Data.Interfaces.ITaskRepository;

namespace TaskScheduler.API.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            //DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            // Services
            services.AddScoped<ITaskService, TaskService>();

            // Repository
            services.AddScoped<ITaskRepository, TaskRepository>();

            // Utilities (optional)
            // services.AddSingleton<ILoggingUtility, LoggingUtility>();

            return services;
        }
    }
}
