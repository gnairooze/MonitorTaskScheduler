using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
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
        public DbSet<Model.TaskHistory> TaskHistories { get; set; }
        public DbSet<Model.TaskChange> TaskChanges { get; set; }

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
            modelBuilder.Entity<Model.TaskChange>().ToTable("TaskChanges");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfiguration Configuration = builder.Build();

            optionsBuilder.UseSqlServer(
                Configuration.GetConnectionString("MonitorTaskSchedulerDbConnection"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
