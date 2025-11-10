using TaskScheduler.Shared.Models;

namespace TaskScheduler.Shared.Interfaces
{
    public interface ITaskExecutor
    {
        Task ExecuteAsync(TaskModel task);
    }
}
