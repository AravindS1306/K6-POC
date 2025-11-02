using TaskScheduler.Shared.Models;

namespace TaskScheduler.API.Services.Interfaces
{
    public interface ITaskService
    {
        Task CreateTaskAsync(TaskModel task);
        Task<IEnumerable<TaskModel>> GetTasksAsync();
    }
}
