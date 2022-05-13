using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnifiedLearningSystem.Infrastructure.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TaskTitle_Value",
                table: "LearningTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskTitle_Value",
                table: "LearningTasks");
        }
    }
}
