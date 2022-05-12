using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnifiedLearningSystem.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    AggregateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title_Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.AggregateID);
                });

            migrationBuilder.CreateTable(
                name: "LearningTasks",
                columns: table => new
                {
                    AggregateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskDescription_Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LearningLessonAggregateID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningTasks", x => x.AggregateID);
                    table.ForeignKey(
                        name: "FK_LearningTasks_Lessons_LearningLessonAggregateID",
                        column: x => x.LearningLessonAggregateID,
                        principalTable: "Lessons",
                        principalColumn: "AggregateID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LearningTasks_LearningLessonAggregateID",
                table: "LearningTasks",
                column: "LearningLessonAggregateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LearningTasks");

            migrationBuilder.DropTable(
                name: "Lessons");
        }
    }
}
