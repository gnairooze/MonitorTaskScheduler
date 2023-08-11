using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSchedulerBusiness.Migrations
{
    /// <inheritdoc />
    public partial class AddModifiedIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Task_Modified",
                table: "Task",
                column: "Modified");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Task_Modified",
                table: "Task");
        }
    }
}
