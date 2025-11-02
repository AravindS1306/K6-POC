using Microsoft.AspNetCore.Mvc;
using TaskScheduler.API.Services.Interfaces;
using TaskScheduler.Shared.Models;

namespace TaskScheduler.API.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService) => _taskService = taskService;

        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskModel task)
        {
            await _taskService.CreateTaskAsync(task);
            return Ok("Task created successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks() => Ok(await _taskService.GetTasksAsync());
    }
}
