using TaskScheduler.Shared.Enums;

namespace TaskScheduler.Shared.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string CronExpression { get; set; } = string.Empty;
        public string TaskType { get; set; } = string.Empty;
        public string? TargetUrl { get; set; }
        public DateTime NextRunTime { get; set; }
        public DateTime? LastRunTime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ScheduledTaskStatus Status { get; set; } = ScheduledTaskStatus.Pending;
        public string? LastRunMessage { get; set; }
    }
}
