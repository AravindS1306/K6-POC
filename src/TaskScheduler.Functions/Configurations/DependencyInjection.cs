using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskScheduler.API.Repositories;
using TaskScheduler.Functions.Services;
using TaskScheduler.Shared.Interfaces;
using TaskScheduler.Shared.Services;
using ITaskRepository = TaskScheduler.Shared.Interfaces.ITaskRepository;

namespace TaskScheduler.Functions.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Repository
            services.AddScoped<ITaskExecutor, TaskExecutor>();

            // Messaging Queue Service
            services.AddScoped<IMessageQueueService, RabbitMqService>();

            // Services
            services.AddScoped<ITaskRepository, TaskRepository>();

            return services;
        }
    }
}
