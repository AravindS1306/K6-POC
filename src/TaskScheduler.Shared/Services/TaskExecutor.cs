using Microsoft.Extensions.Logging;
using TaskScheduler.Shared.Interfaces;
using TaskScheduler.Shared.Models;

namespace TaskScheduler.Shared.Services
{
    public class TaskExecutor : ITaskExecutor
    {
        private readonly ILogger<TaskExecutor> _logger;

        public TaskExecutor(ILogger<TaskExecutor> logger)
        {
            _logger = logger;
        }

        public async Task ExecuteAsync(TaskModel task)
        {
            _logger.LogInformation($"Executing task: {task.Name}");
            await Task.Delay(1000); 
            _logger.LogInformation($"Task completed: {task.Name}");
        }
    }
}
