using TaskScheduler.Shared.Models;

namespace TaskScheduler.Shared.Interfaces
{
    public interface IMessageQueueService
    {
        Task PublishAsync(TaskModel task);
    }
}

