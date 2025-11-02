using System.ComponentModel.DataAnnotations;
using TaskScheduler.Shared.Enums;

namespace TaskScheduler.Shared.Models
{
    public class TaskModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string CronExpression { get; set; } = string.Empty;
        public string TaskType { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public TaskSchedulerStatus Status { get; set; } = TaskSchedulerStatus.Pending;
    }
}
