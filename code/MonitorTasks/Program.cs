// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using TaskSchedulerBusiness.Data;

var tasksFilePath = @"sched-tasks.csv";

var configBuilder = new ConfigurationBuilder().AddJsonFile($"appsettings.json");

var _ = configBuilder.Build();

TaskSchedulerBusiness.Manager.DbContext = new MonitorTaskSchedulerDbContext();
TaskSchedulerBusiness.Manager.Delete(tasksFilePath);
TaskSchedulerBusiness.Manager.DumpTasks();
var tasks = TaskSchedulerBusiness.Manager.Load(tasksFilePath);
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
    bool succeeded = TaskSchedulerBusiness.Manager.Save(task, out string message);

    Console.WriteLine($"Save result: {succeeded} - {message}");

}

