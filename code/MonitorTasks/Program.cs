// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaskSchedulerBusiness.Data;

var configBuilder = new ConfigurationBuilder().AddJsonFile($"appsettings.json");

var config = configBuilder.Build();

//not working
//var connectionString = config.GetConnectionString("MonitorTaskSchedulerDbConnection");
var connectionString = "Server=.\\Dev;initial catalog=MonitorTaskScheduler;Integrated Security=true;MultipleActiveResultSets=true;App=MonitorTasksConsole;";

var dbOptions = new DbContextOptionsBuilder<MonitorTaskSchedulerDbContext>()
    .UseSqlServer(connectionString)
    .EnableSensitiveDataLogging()
    .Options;

TaskSchedulerBusiness.Manager.DbContext = new MonitorTaskSchedulerDbContext(dbOptions);
TaskSchedulerBusiness.Manager.DumpTasks();
var tasks = TaskSchedulerBusiness.Manager.Load(@"sched-tasks.csv");
Console.WriteLine("Load result:");
Console.WriteLine(tasks.Count);

if(tasks.Count == 0)
{
    Console.WriteLine("No tasks found");
    return;
}

foreach (var task in tasks)
{
    Console.WriteLine(task.TaskName);
    TaskSchedulerBusiness.Manager.Save(task);
}

