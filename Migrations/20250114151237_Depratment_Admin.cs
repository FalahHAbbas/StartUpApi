using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StartUpApi.Migrations
{
    /// <inheritdoc />
    public partial class Depratment_Admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Departements");

            migrationBuilder.AddColumn<Guid>(
                name: "AdminId",
                table: "Departements",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departements_AdminId",
                table: "Departements",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departements_Users_AdminId",
                table: "Departements",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departements_Users_AdminId",
                table: "Departements");

            migrationBuilder.DropIndex(
                name: "IX_Departements_AdminId",
                table: "Departements");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Departements");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "Departements",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
