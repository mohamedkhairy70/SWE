using Microsoft.EntityFrameworkCore.Migrations;

namespace SWE.UI.Migrations
{
    public partial class RestartRelationStudentandStudentLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Studentes_StudentLogUserName",
                table: "Studentes");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "StudentLog",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Studentes_StudentLogUserName",
                table: "Studentes",
                column: "StudentLogUserName",
                unique: true,
                filter: "[StudentLogUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Studentes_StudentLogUserName",
                table: "Studentes");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentLog");

            migrationBuilder.CreateIndex(
                name: "IX_Studentes_StudentLogUserName",
                table: "Studentes",
                column: "StudentLogUserName");
        }
    }
}
