using Microsoft.EntityFrameworkCore.Migrations;

namespace SWE.UI.Migrations
{
    public partial class UpdateProfessormanagenunalbe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Professores_ProfessorManageId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_ProfessorManageId",
                table: "Departments");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessorManageId",
                table: "Departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ProfessorManageId",
                table: "Departments",
                column: "ProfessorManageId",
                unique: true,
                filter: "[ProfessorManageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Professores_ProfessorManageId",
                table: "Departments",
                column: "ProfessorManageId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Professores_ProfessorManageId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_ProfessorManageId",
                table: "Departments");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessorManageId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
