using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StartUpApi.Migrations
{
    /// <inheritdoc />
    public partial class department_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DepartementId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "Departements",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartementId",
                table: "Users",
                column: "DepartementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departements_DepartementId",
                table: "Users",
                column: "DepartementId",
                principalTable: "Departements",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departements_DepartementId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DepartementId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DepartementId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Departements");
        }
    }
}
