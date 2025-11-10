using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using TaskScheduler.Shared.Interfaces;

namespace TaskScheduler.Functions.Functions
{
    public class TimerTaskSchedulerFunction
    {
        private readonly ILogger _logger;
        private readonly ITaskRepository _taskRepository;
        private readonly IMessageQueueService _messageQueueService; 

        public TimerTaskSchedulerFunction(
            ILoggerFactory loggerFactory,
            ITaskRepository taskRepository,
            IMessageQueueService messageQueueService)
        {
            _logger = loggerFactory.CreateLogger<TimerTaskSchedulerFunction>();
            _taskRepository = taskRepository;
            _messageQueueService = messageQueueService;
        }

        [Function("TimerTaskSchedulerFunction")]
        public async Task RunAsync([TimerTrigger("0 */1 * * * *")] TimerInfo timer)
        {
            _logger.LogInformation($"Timer trigger fired at: {DateTime.UtcNow}");

            var dueTasks = await _taskRepository.GetDueTasksAsync();
            foreach (var task in dueTasks)
            {
                _logger.LogInformation($"Queueing task to RabbitMQ: {task.Name}");
                await _messageQueueService.PublishAsync(task); 
            }
        }
    }
}
