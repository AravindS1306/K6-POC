using Microsoft.EntityFrameworkCore;
using TaskScheduler.API.Data;
using TaskScheduler.Shared.Interfaces;
using TaskScheduler.Shared.Models;

namespace TaskScheduler.API.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskModel>> GetDueTasksAsync()
        {
            var now = DateTime.UtcNow;
            return await _context.Tasks
                .Where(t => t.Status == 0 && t.CreatedAt <= now)
                .ToListAsync();
        }

        public async Task AddTaskAsync(TaskModel task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task<TaskModel?> GetTaskByIdAsync(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }
    }
}
