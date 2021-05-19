using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SWE.UI.Migrations
{
    public partial class updatePasswordHashandPasswordSaltstudentlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "StudentLog");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "StudentLog",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "StudentLog",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "StudentLog");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "StudentLog");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "StudentLog",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
