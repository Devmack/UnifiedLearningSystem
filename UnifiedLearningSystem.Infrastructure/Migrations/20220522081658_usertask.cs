using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnifiedLearningSystem.Infrastructure.Migrations
{
    public partial class usertask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTasks",
                columns: table => new
                {
                    AggregateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskOwnerUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepositoriumLink_Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTasks", x => x.AggregateID);
                });

            migrationBuilder.CreateTable(
                name: "TaskReview",
                columns: table => new
                {
                    TaskUserAggregateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskReview", x => new { x.TaskUserAggregateID, x.Id });
                    table.ForeignKey(
                        name: "FK_TaskReview_UserTasks_TaskUserAggregateID",
                        column: x => x.TaskUserAggregateID,
                        principalTable: "UserTasks",
                        principalColumn: "AggregateID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskReview");

            migrationBuilder.DropTable(
                name: "UserTasks");
        }
    }
}
