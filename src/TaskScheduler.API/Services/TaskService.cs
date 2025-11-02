using TaskScheduler.API.Data.Interfaces;
using TaskScheduler.API.Services.Interfaces;
using TaskScheduler.Shared.Models;

namespace TaskScheduler.API.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateTaskAsync(TaskModel task)
        {
            await _repository.AddTaskAsync(task);
        }

        public async Task<IEnumerable<TaskModel>> GetTasksAsync()
        {
            return await _repository.GetAllTasksAsync();
        }
    }
}
