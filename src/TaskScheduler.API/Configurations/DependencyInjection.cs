using TaskScheduler.API.Repositories;
using TaskScheduler.Shared.Interfaces;

namespace TaskScheduler.API.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Services
            services.AddScoped<ITaskRepository, TaskRepository>();

            return services;
        }
    }
}
