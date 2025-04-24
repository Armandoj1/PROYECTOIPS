using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPSUPC.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class CitasMedicas1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoConsultaID",
                table: "CitasMedicas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CitasMedicas_TipoConsultaID",
                table: "CitasMedicas",
                column: "TipoConsultaID");

            migrationBuilder.AddForeignKey(
                name: "FK_CitasMedicas_TipoConsulta_TipoConsultaID",
                table: "CitasMedicas",
                column: "TipoConsultaID",
                principalSchema: "dbo",
                principalTable: "TipoConsulta",
                principalColumn: "TipoConsultaID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitasMedicas_TipoConsulta_TipoConsultaID",
                table: "CitasMedicas");

            migrationBuilder.DropIndex(
                name: "IX_CitasMedicas_TipoConsultaID",
                table: "CitasMedicas");

            migrationBuilder.DropColumn(
                name: "TipoConsultaID",
                table: "CitasMedicas");
        }
    }
}
