using Microsoft.EntityFrameworkCore.Migrations;

namespace SWE.UI.Migrations
{
    public partial class updateStudentrelationtostudentlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentLog_StudentId",
                table: "StudentLog");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLog_StudentId",
                table: "StudentLog",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentLog_StudentId",
                table: "StudentLog");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLog_StudentId",
                table: "StudentLog",
                column: "StudentId");
        }
    }
}
