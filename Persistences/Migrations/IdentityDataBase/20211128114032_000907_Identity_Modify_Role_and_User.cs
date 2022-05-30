using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace  Persistences.Migrations.IdentityDataBase
{
    public partial class _000907_Identity_Modify_Role_and_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DisableDate",
                table: "Users",
                type: "TIMESTAMP(7)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisable",
                table: "Users",
                type: "NUMBER(1)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Roles",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DisableDate",
                table: "Roles",
                type: "TIMESTAMP(7)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisable",
                table: "Roles",
                type: "NUMBER(1)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisableDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDisable",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DisableDate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsDisable",
                table: "Roles");
        }
    }
}
