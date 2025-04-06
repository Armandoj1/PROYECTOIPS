using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPSUPC.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditableFieldsToUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Usuario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Usuario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Usuario",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Usuario",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Usuario");
        }
    }
}
