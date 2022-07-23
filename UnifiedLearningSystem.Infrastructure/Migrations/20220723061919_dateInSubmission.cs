using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnifiedLearningSystem.Infrastructure.Migrations
{
    public partial class dateInSubmission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimeOfSubmission",
                table: "UserTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeOfSubmission",
                table: "UserTasks");
        }
    }
}
