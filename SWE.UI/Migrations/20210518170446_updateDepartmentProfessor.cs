using Microsoft.EntityFrameworkCore.Migrations;

namespace SWE.UI.Migrations
{
    public partial class updateDepartmentProfessor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessorManageId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ProfessorManageId",
                table: "Departments",
                column: "ProfessorManageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Professores_ProfessorManageId",
                table: "Departments",
                column: "ProfessorManageId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Professores_ProfessorManageId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_ProfessorManageId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ProfessorManageId",
                table: "Departments");
        }
    }
}
