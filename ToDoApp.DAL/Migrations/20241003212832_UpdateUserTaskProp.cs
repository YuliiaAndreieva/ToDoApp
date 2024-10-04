using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserTaskProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isDone",
                table: "UserTasks",
                newName: "IsDone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDone",
                table: "UserTasks",
                newName: "isDone");
        }
    }
}
