using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerBusiness.Data
{
    public class MonitorTaskSchedulerDbContext:DbContext
    {
        public DbSet<Model.Task> Tasks { get; set; }
        public DbSet<Model.TaskHistory> TasksHistory { get; set; }
        public DbSet<Model.TaskChanges> TasksChanges { get; set; }

        public MonitorTaskSchedulerDbContext() : base()
        {
            
        }

        public MonitorTaskSchedulerDbContext(DbContextOptions<MonitorTaskSchedulerDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.Task>().ToTable("Task");
            modelBuilder.Entity<Model.TaskHistory>().ToTable("TaskHistory");
            modelBuilder.Entity<Model.TaskChanges>().ToTable("TaskChanges");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\Dev;initial catalog=MonitorTaskScheduler;Integrated Security=true;MultipleActiveResultSets=true;App=MonitorTasksConsole;TrustServerCertificate=True;");
        }
    }
}
