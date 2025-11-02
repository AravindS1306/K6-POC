using TaskScheduler.Shared.Models;

namespace TaskScheduler.API.Data.Interfaces
{
    public interface ITaskRepository
    {
        Task AddTaskAsync(TaskModel task);
        Task<IEnumerable<TaskModel>> GetAllTasksAsync();
        Task<TaskModel?> GetTaskByIdAsync(Guid id);
        Task UpdateTaskAsync(TaskModel task);
        Task DeleteTaskAsync(Guid id);
        Task SaveChangesAsync();
    }
}
