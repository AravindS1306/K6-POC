namespace TaskScheduler.API.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string CronExpression { get; set; } = string.Empty;
        public string TaskType { get; set; } = string.Empty;
        public DateTime NextRunTime { get; set; }
        public string Status { get; set; } = "Pending";
    }

}
