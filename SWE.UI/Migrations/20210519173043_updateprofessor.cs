using Microsoft.EntityFrameworkCore.Migrations;

namespace SWE.UI.Migrations
{
    public partial class updateprofessor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Departments_DepartmentId",
                table: "Professores");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Professores",
                newName: "DepartmentsId");

            migrationBuilder.RenameIndex(
                name: "IX_Professores_DepartmentId",
                table: "Professores",
                newName: "IX_Professores_DepartmentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Departments_DepartmentsId",
                table: "Professores",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Departments_DepartmentsId",
                table: "Professores");

            migrationBuilder.RenameColumn(
                name: "DepartmentsId",
                table: "Professores",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Professores_DepartmentsId",
                table: "Professores",
                newName: "IX_Professores_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Departments_DepartmentId",
                table: "Professores",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
