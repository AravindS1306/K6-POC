using Microsoft.EntityFrameworkCore;
using TaskScheduler.Shared.Models;

namespace TaskScheduler.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var entity = modelBuilder.Entity<TaskModel>().ToTable("tasks");
            entity.ToTable("tasks");

            entity.Property(t => t.Id).HasColumnName("id");
            entity.Property(t => t.Name).HasColumnName("name");
            entity.Property(t => t.CronExpression).HasColumnName("cronexpression");
            entity.Property(t => t.TaskType).HasColumnName("tasktype");
            entity.Property(t => t.TargetUrl).HasColumnName("targeturl");
            entity.Property(t => t.NextRunTime).HasColumnName("nextruntime");
            entity.Property(t => t.LastRunTime).HasColumnName("lastruntime");
            entity.Property(t => t.CreatedAt).HasColumnName("createdat");
            entity.Property(t => t.Status).HasColumnName("status");
            entity.Property(t => t.LastRunMessage).HasColumnName("lastrunmessage");
        }
    }
}
