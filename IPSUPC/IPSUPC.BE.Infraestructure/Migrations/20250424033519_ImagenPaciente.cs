using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPSUPC.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class ImagenPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagenUrl",
                schema: "dbo",
                table: "Pacientes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenUrl",
                schema: "dbo",
                table: "Pacientes");
        }
    }
}
