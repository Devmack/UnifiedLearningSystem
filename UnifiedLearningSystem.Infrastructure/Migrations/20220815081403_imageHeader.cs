using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnifiedLearningSystem.Infrastructure.Migrations
{
    public partial class imageHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TaskImageHeader_Value",
                table: "LearningTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskImageHeader_Value",
                table: "LearningTasks");
        }
    }
}
