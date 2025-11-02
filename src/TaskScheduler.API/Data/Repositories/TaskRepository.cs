using Microsoft.EntityFrameworkCore;
using TaskScheduler.API.Data.Interfaces;
using TaskScheduler.Shared.Models;

namespace TaskScheduler.API.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddTaskAsync(TaskModel task)
        {
            await _context.Tasks.AddAsync(task);
        }

        public async Task<IEnumerable<TaskModel>> GetAllTasksAsync()
        {
            return await _context.Tasks
                                 .AsNoTracking()
                                 .OrderByDescending(t => t.NextRunTime)
                                 .ToListAsync();
        }

        public async Task<TaskModel?> GetTaskByIdAsync(Guid id)
        {
            return await _context.Tasks
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateTaskAsync(TaskModel task)
        {
            _context.Tasks.Update(task);
        }

        public async Task DeleteTaskAsync(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
