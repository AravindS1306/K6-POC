using Microsoft.AspNetCore.Mvc;
using TaskScheduler.Shared.Interfaces;
using TaskScheduler.Shared.Models;

namespace TaskScheduler.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _repository;

        public TaskController(ITaskRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] TaskModel task)
        {
            await _repository.AddTaskAsync(task);
            return Ok(task);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(Guid id)
        {
            var task = await _repository.GetTaskByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }
    }
}

