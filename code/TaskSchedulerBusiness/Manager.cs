using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TaskSchedulerBusiness.Data;
using TaskSchedulerBusiness.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TaskSchedulerBusiness
{
    public class Manager
    {
        public static MonitorTaskSchedulerDbContext? DbContext { get; set; }

        public Manager()
        {

        }

        public static void DumpTasks() 
        {
            ProcessStartInfo processInfo = new("cmd.exe", "/c " + "dump-tasks.bat")
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                WorkingDirectory = Path.GetDirectoryName(Environment.ProcessPath),
                // *** Redirect the output ***
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };

            Process? process = Process.Start(processInfo);

            if(process == null)
            {
                Console.WriteLine("Process is null");
                return;
            }

            process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
       Console.WriteLine("output>>" + e.Data);
            process.BeginOutputReadLine();

            process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine("error>>" + e.Data);
            process.BeginErrorReadLine();

            process.WaitForExit();

            Console.WriteLine("ExitCode: {0}", process.ExitCode);
            process.Close();
        }

        public static List<Model.Task> Load(string filePath)
        {
            List<Model.Task> tasks = new();

            string[] csvFileLines = File.ReadAllLines(filePath);
            for (int i = 1; i < csvFileLines.Length; i++)
            {
                var line = csvFileLines[i];

                var values = line.Split("\",\"");

                if (values.Length != 28)
                {
                    Console.WriteLine($"Line {line} is not valid");
                    continue;
                }

                if (values[1] == "TaskName")
                {
                    continue;
                }

                var task = new Model.Task()
                {
                    HostName = values[0][1..],
                    TaskName = values[1],
                    Next_Run_Time = values[2],
                    Status = values[3],
                    Logon_Mode = values[4],
                    Last_Run_Time = values[5],
                    Last_Result = values[6],
                    Author = values[7],
                    Task_To_Run = values[8],
                    Start_In = values[9],
                    Comment = values[10],
                    Scheduled_Task_State = values[11],
                    Idle_Time = values[12],
                    Power_Management = values[13],
                    Run_As_User = values[14],
                    Delete_Task_If_Not_Rescheduled = values[15],
                    Stop_Task_If_Runs_X_Hours_and_X_Mins = values[16],
                    Schedule = values[17],
                    Schedule_Type = values[18],
                    Start_Time = values[19],
                    Start_Date = values[20],
                    End_Date = values[21],
                    Days = values[22],
                    Months = values[23],
                    Repeat_Every = values[24],
                    Repeat_Until_Time = values[25],
                    Repeat_Until_Duration = values[26],
                    Repeat_Stop_If_Still_Running = values[27][..^1]
                };

                UpdateTaskNameIfExist(tasks, task, 2);

                tasks.Add(task);
            }

            return tasks;
        }

        private static void UpdateTaskNameIfExist(List<Model.Task> tasks, Model.Task task, int counter)
        {
            if(tasks.Any(x => x.TaskName == task.TaskName))
            {
                if (task.TaskName.Contains("-Dup-"))
                {
                    int suffixIndex = task.TaskName.LastIndexOf("-Dup-");
                    task.TaskName = task.TaskName[..suffixIndex];
                }
                
                task.TaskName = $"{task.TaskName}-Dup-{counter}";

                counter++;
                UpdateTaskNameIfExist(tasks, task, counter);
            }
        }

        public static bool Save(Model.Task task, out string message)
        {
            message = string.Empty;

            if (DbContext == null)
            {
                message = "DbContext is null";
                return false;
            }

            //if tasks already saved before in db.
            if(DbContext.Tasks.Any(
                x => x.TaskName == task.TaskName
                && x.HostName == task.HostName
                ))
            {
                var savedTask = DbContext.Tasks.Where(t => t.TaskName == task.TaskName && t.HostName == task.HostName).First();

                if(savedTask.Equals(task))
                {
                    message = "no changes since task last saved";
                    return true;
                }

                bool comparisonSucceeded = TaskBase.CompareTasks(savedTask, task, false, out List<TaskChange> changes, out string comparisonMessage);

                if (!comparisonSucceeded)
                {
                    message = comparisonMessage;
                    return false;
                }

                TaskHistory history = new(savedTask);
                DbContext.TaskHistories.Add(history);
                
                savedTask.CopyFrom(task);
                savedTask.Modified = DateTime.Now;
                DbContext.Update(savedTask);
                DbContext.SaveChanges();

                foreach (var change in changes)
                {
                    change.TaskHistoryId = history.Id;
                    DbContext.TaskChanges.Add(change);
                }

                DbContext.SaveChanges();
                return true;
            }

            task.Modified = DateTime.Now;
            DbContext.Add(task);
            DbContext.SaveChanges();

            return true;
        }

        
    }
}
