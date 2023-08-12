using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerBusiness.Model
{
    public class TaskBase
    {
        #region Properties
        [MaxLength(700)]
        public string HostName { get; set; } = string.Empty;
        [MaxLength(200)]
        public string TaskName { get; set; } = string.Empty;
        public string Next_Run_Time { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Logon_Mode { get; set; } = string.Empty;
        public string Last_Run_Time { get; set; } = string.Empty;
        public string Last_Result { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Task_To_Run { get; set; } = string.Empty;
        public string Start_In { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public string Scheduled_Task_State { get; set; } = string.Empty;
        public string Idle_Time { get; set; } = string.Empty;
        public string Power_Management { get; set; } = string.Empty;
        public string Run_As_User { get; set; } = string.Empty;
        public string Delete_Task_If_Not_Rescheduled { get; set; } = string.Empty;
        public string Stop_Task_If_Runs_X_Hours_and_X_Mins { get; set; } = string.Empty;
        public string Schedule { get; set; } = string.Empty;
        public string Schedule_Type { get; set; } = string.Empty;
        public string Start_Time { get; set; } = string.Empty;
        public string Start_Date { get; set; } = string.Empty;
        public string End_Date { get; set; } = string.Empty;
        public string Days { get; set; } = string.Empty;
        public string Months { get; set; } = string.Empty;
        public string Repeat_Every { get; set; } = string.Empty;
        public string Repeat_Until_Time { get; set; } = string.Empty;
        public string Repeat_Until_Duration { get; set; } = string.Empty;
        public string Repeat_Stop_If_Still_Running { get; set; } = string.Empty;
        public DateTime Modified { get; set; }
        #endregion

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is not Task)
            {
                return false;
            }

            var task = (Task)obj;

            if (
                task.Author != Author
                || task.Comment != Comment
                || task.Days != Days
                || task.Delete_Task_If_Not_Rescheduled != Delete_Task_If_Not_Rescheduled
                || task.End_Date != End_Date
                || task.HostName != HostName
                || task.Idle_Time != Idle_Time
                || task.Last_Result != Last_Result
                || task.Last_Run_Time != Last_Run_Time
                || task.Logon_Mode != Logon_Mode
                || task.Months != Months
                || task.Next_Run_Time != Next_Run_Time
                || task.Power_Management != Power_Management
                || task.Repeat_Every != Repeat_Every
                || task.Repeat_Stop_If_Still_Running != Repeat_Stop_If_Still_Running
                || task.Repeat_Until_Duration != Repeat_Until_Duration
                || task.Repeat_Until_Time != Repeat_Until_Time
                || task.Run_As_User != Run_As_User
                || task.Schedule != Schedule
                || task.Schedule_Type != Schedule_Type
                || task.Scheduled_Task_State != Scheduled_Task_State
                || task.Start_In != Start_In
                || task.Start_Date != Start_Date
                || task.Start_Time != Start_Time
                || task.Status != Status
                || task.Stop_Task_If_Runs_X_Hours_and_X_Mins != Stop_Task_If_Runs_X_Hours_and_X_Mins
                || task.TaskName != TaskName
                || task.Task_To_Run != Task_To_Run
                )
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void CopyFrom(TaskBase source)
        {
            HostName = source.HostName;
            TaskName = source.TaskName;
            Next_Run_Time = source.Next_Run_Time;
            Status = source.Status;
            Logon_Mode = source.Logon_Mode;
            Last_Run_Time = source.Last_Run_Time;
            Last_Result = source.Last_Result;
            Author = source.Author;
            Task_To_Run = source.Task_To_Run;
            Start_In = source.Start_In;
            Comment = source.Comment;
            Scheduled_Task_State = source.Scheduled_Task_State;
            Idle_Time = source.Idle_Time;
            Power_Management = source.Power_Management;
            Run_As_User = source.Run_As_User;
            Delete_Task_If_Not_Rescheduled = source.Delete_Task_If_Not_Rescheduled;
            Stop_Task_If_Runs_X_Hours_and_X_Mins = source.Stop_Task_If_Runs_X_Hours_and_X_Mins;
            Schedule = source.Schedule;
            Schedule_Type = source.Schedule_Type;
            Start_Time = source.Start_Time;
            Start_Date = source.Start_Date;
            End_Date = source.End_Date;
            Days = source.Days;
            Months = source.Months;
            Repeat_Every = source.Repeat_Every;
            Repeat_Until_Time = source.Repeat_Until_Time;
            Repeat_Until_Duration = source.Repeat_Until_Duration;
            Repeat_Stop_If_Still_Running = source.Repeat_Stop_If_Still_Running;
        }

        public static bool CompareTasks(Task source, Task target, bool includeModified, out List<TaskChange> changes, out string message)
        {
            changes = new();
            message = string.Empty;

            if (source.TaskName != target.TaskName
                || source.HostName != target.HostName)
            {
                message = "source and destinations cannot be compared. TaskName or HostName are not equal";
                return false;
            }

            if (source.Author != target.Author)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Author),
                    OldValue = source.Author,
                    NewValue = target.Author
                });
            }

            if (source.Comment != target.Comment)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Comment),
                    OldValue = source.Comment,
                    NewValue = target.Comment
                });
            }

            if (source.Days != target.Days)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Days),
                    OldValue = source.Days,
                    NewValue = target.Days
                });
            }

            if (source.Delete_Task_If_Not_Rescheduled != target.Delete_Task_If_Not_Rescheduled)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Delete_Task_If_Not_Rescheduled),
                    OldValue = source.Delete_Task_If_Not_Rescheduled,
                    NewValue = target.Delete_Task_If_Not_Rescheduled
                });
            }

            if (source.End_Date != target.End_Date)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.End_Date),
                    OldValue = source.End_Date,
                    NewValue = target.End_Date
                });
            }

            if (source.Idle_Time != target.Idle_Time)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Idle_Time),
                    OldValue = source.Idle_Time,
                    NewValue = target.Idle_Time
                });
            }

            if (source.Last_Result != target.Last_Result)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Last_Result),
                    OldValue = source.Last_Result,
                    NewValue = target.Last_Result
                });
            }

            if (source.Last_Run_Time != target.Last_Run_Time)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Last_Run_Time),
                    OldValue = source.Last_Run_Time,
                    NewValue = target.Last_Run_Time
                });
            }

            if (source.Logon_Mode != target.Logon_Mode)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Logon_Mode),
                    OldValue = source.Logon_Mode,
                    NewValue = target.Logon_Mode
                });
            }

            if (source.Months != target.Months)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Months),
                    OldValue = source.Months,
                    NewValue = target.Months
                });
            }

            if (source.Next_Run_Time != target.Next_Run_Time)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Next_Run_Time),
                    OldValue = source.Next_Run_Time,
                    NewValue = target.Next_Run_Time
                });
            }

            if (source.Power_Management != target.Power_Management)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Power_Management),
                    OldValue = source.Power_Management,
                    NewValue = target.Power_Management
                });
            }

            if (source.Repeat_Every != target.Repeat_Every)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Repeat_Every),
                    OldValue = source.Repeat_Every,
                    NewValue = target.Repeat_Every
                });
            }

            if (source.Repeat_Stop_If_Still_Running != target.Repeat_Stop_If_Still_Running)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Repeat_Stop_If_Still_Running),
                    OldValue = source.Repeat_Stop_If_Still_Running,
                    NewValue = target.Repeat_Stop_If_Still_Running
                });
            }

            if (source.Repeat_Until_Duration != target.Repeat_Until_Duration)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Repeat_Until_Duration),
                    OldValue = source.Repeat_Until_Duration,
                    NewValue = target.Repeat_Until_Duration
                });
            }

            if (source.Repeat_Until_Time != target.Repeat_Until_Time)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Repeat_Until_Time),
                    OldValue = source.Repeat_Until_Time,
                    NewValue = target.Repeat_Until_Time
                });
            }

            if (source.Run_As_User != target.Run_As_User)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Run_As_User),
                    OldValue = source.Run_As_User,
                    NewValue = target.Run_As_User
                });
            }

            if (source.Schedule != target.Schedule)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Schedule),
                    OldValue = source.Schedule,
                    NewValue = target.Schedule
                });
            }

            if (source.Schedule_Type != target.Schedule_Type)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Schedule_Type),
                    OldValue = source.Schedule_Type,
                    NewValue = target.Schedule_Type
                });
            }

            if (source.Scheduled_Task_State != target.Scheduled_Task_State)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Scheduled_Task_State),
                    OldValue = source.Scheduled_Task_State,
                    NewValue = target.Scheduled_Task_State
                });
            }

            if (source.Start_In != target.Start_In)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Start_In),
                    OldValue = source.Start_In,
                    NewValue = target.Start_In
                });
            }

            if (source.Start_Date != target.Start_Date)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Start_Date),
                    OldValue = source.Start_Date,
                    NewValue = target.Start_Date
                });
            }

            if (source.Start_Time != target.Start_Time)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Start_Time),
                    OldValue = source.Start_Time,
                    NewValue = target.Start_Time
                });
            }

            if (source.Status != target.Status)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Status),
                    OldValue = source.Status,
                    NewValue = target.Status
                });
            }

            if (source.Stop_Task_If_Runs_X_Hours_and_X_Mins != target.Stop_Task_If_Runs_X_Hours_and_X_Mins)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Stop_Task_If_Runs_X_Hours_and_X_Mins),
                    OldValue = source.Stop_Task_If_Runs_X_Hours_and_X_Mins,
                    NewValue = target.Stop_Task_If_Runs_X_Hours_and_X_Mins
                });
            }

            if (source.Task_To_Run != target.Task_To_Run)
            {
                changes.Add(new TaskChange()
                {
                    HostName = source.HostName,
                    TaskName = source.TaskName,
                    PropertyName = nameof(source.Task_To_Run),
                    OldValue = source.Task_To_Run,
                    NewValue = target.Task_To_Run
                });
            }

            if (includeModified)
            {
                if (source.Modified != target.Modified)
                {
                    changes.Add(new TaskChange()
                    {
                        HostName = source.HostName,
                        TaskName = source.TaskName,
                        PropertyName = nameof(source.Modified),
                        OldValue = source.Modified.ToString(),
                        NewValue = target.Modified.ToString()
                    });
                }
            }

            return true;
        }
    }
}
