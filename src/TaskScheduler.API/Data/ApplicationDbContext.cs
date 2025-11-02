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
            modelBuilder.Entity<TaskModel>()
                        .ToTable("Tasks")
                        .HasKey(t => t.Id);
            modelBuilder.Entity<TaskModel>().ToTable("tasks");
        }
    }
}
