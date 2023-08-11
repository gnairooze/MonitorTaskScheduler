using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerBusiness.Model
{
    public class TaskBase
    {
        public string HostName { get; set; } = string.Empty;
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
    }
}
