using TaskScheduler.Shared.Enums;

namespace TaskScheduler.Shared.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string CronExpression { get; set; } = string.Empty;
        public string TaskType { get; set; } = string.Empty;
        public DateTime NextRunTime { get; set; }
        public TaskSchedulerStatus Status { get; set; } = TaskSchedulerStatus.Pending;
    }
}
