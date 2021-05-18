using Microsoft.EntityFrameworkCore.Migrations;

namespace SWE.UI.Migrations
{
    public partial class AddProfessorManage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessorManageId",
                table: "Professores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professores_ProfessorManageId",
                table: "Professores",
                column: "ProfessorManageId",
                unique: true,
                filter: "[ProfessorManageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Professores_ProfessorManageId",
                table: "Professores",
                column: "ProfessorManageId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Professores_ProfessorManageId",
                table: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Professores_ProfessorManageId",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "ProfessorManageId",
                table: "Professores");
        }
    }
}
