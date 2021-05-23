using Microsoft.EntityFrameworkCore.Migrations;

namespace SWE.UI.Migrations
{
    public partial class EditStudentAddPropStudentLogUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentLog_Studentes_StudentId",
                table: "StudentLog");

            migrationBuilder.DropIndex(
                name: "IX_StudentLog_StudentId",
                table: "StudentLog");

            migrationBuilder.AddColumn<string>(
                name: "StudentLogUserName",
                table: "Studentes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Studentes_StudentLogUserName",
                table: "Studentes",
                column: "StudentLogUserName",
                unique: true,
                filter: "[StudentLogUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Studentes_StudentLog_StudentLogUserName",
                table: "Studentes",
                column: "StudentLogUserName",
                principalTable: "StudentLog",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studentes_StudentLog_StudentLogUserName",
                table: "Studentes");

            migrationBuilder.DropIndex(
                name: "IX_Studentes_StudentLogUserName",
                table: "Studentes");

            migrationBuilder.DropColumn(
                name: "StudentLogUserName",
                table: "Studentes");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLog_StudentId",
                table: "StudentLog",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLog_Studentes_StudentId",
                table: "StudentLog",
                column: "StudentId",
                principalTable: "Studentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
