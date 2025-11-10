using TaskScheduler.Shared.Models;

namespace TaskScheduler.Shared.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskModel>> GetDueTasksAsync();
        Task AddTaskAsync(TaskModel task);
        Task<TaskModel?> GetTaskByIdAsync(Guid id);
    }
}
