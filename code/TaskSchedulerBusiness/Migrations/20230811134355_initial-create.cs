using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSchedulerBusiness.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    HostName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Next_Run_Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logon_Mode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Run_Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Task_To_Run = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start_In = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scheduled_Task_State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idle_Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Power_Management = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Run_As_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Delete_Task_If_Not_Rescheduled = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stop_Task_If_Runs_X_Hours_and_X_Mins = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Schedule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Schedule_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start_Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start_Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    End_Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Days = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Months = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Repeat_Every = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Repeat_Until_Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Repeat_Until_Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Repeat_Stop_If_Still_Running = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => new { x.HostName, x.TaskName });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");
        }
    }
}
