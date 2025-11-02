using TaskScheduler.Shared.Models;

namespace TaskScheduler.API.Data.Interfaces
{
    public interface ITaskRepository
    {
        Task AddTaskAsync(TaskModel task);
        Task<IEnumerable<TaskModel>> GetAllTasksAsync();
        Task UpdateTaskStatusAsync(string taskId, string status);
    }
}
