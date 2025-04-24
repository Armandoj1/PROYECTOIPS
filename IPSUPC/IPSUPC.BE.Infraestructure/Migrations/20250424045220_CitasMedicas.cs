using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IPSUPC.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class CitasMedicas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dias",
                columns: table => new
                {
                    DiaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dias", x => x.DiaID);
                });

            migrationBuilder.CreateTable(
                name: "EstadoCita",
                columns: table => new
                {
                    EstadoCitaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCita", x => x.EstadoCitaID);
                });

            migrationBuilder.CreateTable(
                name: "HorasMedicas",
                schema: "dbo",
                columns: table => new
                {
                    HoraMedicaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorasMedicas", x => x.HoraMedicaID);
                });

            migrationBuilder.CreateTable(
                name: "TipoConsulta",
                schema: "dbo",
                columns: table => new
                {
                    TipoConsultaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoConsulta", x => x.TipoConsultaID);
                });

            migrationBuilder.CreateTable(
                name: "CitasMedicas",
                columns: table => new
                {
                    CitaMedicaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteID = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    MedicoID = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    HorasMedicasID = table.Column<int>(type: "int", nullable: false),
                    EstadoCitaID = table.Column<int>(type: "int", nullable: false),
                    DiaID = table.Column<int>(type: "int", nullable: false),
                    FechaCita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observaciones = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitasMedicas", x => x.CitaMedicaID);
                    table.ForeignKey(
                        name: "FK_CitasMedicas_Dias_DiaID",
                        column: x => x.DiaID,
                        principalTable: "Dias",
                        principalColumn: "DiaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CitasMedicas_EstadoCita_EstadoCitaID",
                        column: x => x.EstadoCitaID,
                        principalTable: "EstadoCita",
                        principalColumn: "EstadoCitaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CitasMedicas_HorasMedicas_HorasMedicasID",
                        column: x => x.HorasMedicasID,
                        principalSchema: "dbo",
                        principalTable: "HorasMedicas",
                        principalColumn: "HoraMedicaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CitasMedicas_Medicos_MedicoID",
                        column: x => x.MedicoID,
                        principalSchema: "dbo",
                        principalTable: "Medicos",
                        principalColumn: "NumeroDocumento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CitasMedicas_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalSchema: "dbo",
                        principalTable: "Pacientes",
                        principalColumn: "NumeroDocumento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Dias",
                columns: new[] { "DiaID", "Nombre" },
                values: new object[,]
                {
                    { 1, "LUNES" },
                    { 2, "MARTES" },
                    { 3, "MIÉRCOLES" },
                    { 4, "JUEVES" },
                    { 5, "VIERNES" },
                    { 6, "SÁBADO" },
                    { 7, "DOMINGO" }
                });

            migrationBuilder.InsertData(
                table: "EstadoCita",
                columns: new[] { "EstadoCitaID", "Code" },
                values: new object[,]
                {
                    { 1, "PENDIENTE" },
                    { 2, "COMPLETADA" },
                    { 3, "EN CURSO" },
                    { 4, "CANCELADA" },
                    { 5, "NO ASISTIO" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "HorasMedicas",
                columns: new[] { "HoraMedicaID", "Code" },
                values: new object[,]
                {
                    { 1, "6:00 AM" },
                    { 2, "6:30 AM" },
                    { 3, "7:00 AM" },
                    { 4, "7:30 AM" },
                    { 5, "8:00 AM" },
                    { 6, "8:30 AM" },
                    { 7, "9:00 AM" },
                    { 8, "9:30 AM" },
                    { 9, "10:00 AM" },
                    { 10, "10:30 AM" },
                    { 11, "11:00 AM" },
                    { 12, "11:30 AM" },
                    { 13, "12:00 PM" },
                    { 14, "12:30 PM" },
                    { 15, "1:00 PM" },
                    { 16, "1:30 PM" },
                    { 17, "2:00 PM" },
                    { 18, "2:30 PM" },
                    { 19, "3:00 PM" },
                    { 20, "3:30 PM" },
                    { 21, "4:00 PM" },
                    { 22, "4:30 PM" },
                    { 23, "5:00 PM" },
                    { 24, "5:30 PM" },
                    { 25, "6:00 PM" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TipoConsulta",
                columns: new[] { "TipoConsultaID", "Code" },
                values: new object[,]
                {
                    { 1, "ENFERMERÍA" },
                    { 2, "PSICOLOGÍA" },
                    { 3, "MEDICINA GENERAL" },
                    { 4, "ODONTOLOGÍA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CitasMedicas_DiaID",
                table: "CitasMedicas",
                column: "DiaID");

            migrationBuilder.CreateIndex(
                name: "IX_CitasMedicas_EstadoCitaID",
                table: "CitasMedicas",
                column: "EstadoCitaID");

            migrationBuilder.CreateIndex(
                name: "IX_CitasMedicas_HorasMedicasID",
                table: "CitasMedicas",
                column: "HorasMedicasID");

            migrationBuilder.CreateIndex(
                name: "IX_CitasMedicas_MedicoID",
                table: "CitasMedicas",
                column: "MedicoID");

            migrationBuilder.CreateIndex(
                name: "IX_CitasMedicas_PacienteID",
                table: "CitasMedicas",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_HorasMedicas_Code",
                schema: "dbo",
                table: "HorasMedicas",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitasMedicas");

            migrationBuilder.DropTable(
                name: "TipoConsulta",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Dias");

            migrationBuilder.DropTable(
                name: "EstadoCita");

            migrationBuilder.DropTable(
                name: "HorasMedicas",
                schema: "dbo");
        }
    }
}
