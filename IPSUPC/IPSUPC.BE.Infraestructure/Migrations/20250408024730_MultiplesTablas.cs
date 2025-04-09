using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPSUPC.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class MultiplesTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "EstadoCivil",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCivil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.Id);
                });

            // Dentro del método Up, después de crear las tablas:

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Generos",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                { 1, "Masculino" },
                { 2, "Femenino" },
                { 3, "Otro" }
                        });

                    migrationBuilder.InsertData(
                        schema: "dbo",
                        table: "EstadoCivil",
                        columns: new[] { "Id", "Name" },
                        values: new object[,]
                        {
                { 1, "Soltero" },
                { 2, "Casado" },
                { 3, "Unión libre" },
                { 4, "Divorciado" },
                { 5, "Viudo" }
                        });

                    migrationBuilder.InsertData(
                        schema: "dbo",
                        table: "TipoDocumento",
                        columns: new[] { "Id", "Name" },
                        values: new object[,]
                        {
                { 1, "CC" },
                { 2, "TI" },
                { 3, "CE" },
                { 4, "Pasaporte" }
                        });


            migrationBuilder.CreateTable(
                name: "Medicos",
                schema: "dbo",
                columns: table => new
                {
                    NumeroDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TipoDocumento = table.Column<int>(type: "int", nullable: false),
                    PrimerNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SegundoNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrimerApellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SegundoApellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    EstadoCivil = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LugarNacimiento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MatriculaProfesional = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Universidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AnioGraduacion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    FechaIngreso = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FechaSalida = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.NumeroDocumento);
                    table.ForeignKey(
                        name: "FK_Medicos_EstadoCivil_EstadoCivil",
                        column: x => x.EstadoCivil,
                        principalSchema: "dbo",
                        principalTable: "EstadoCivil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medicos_Generos_Genero",
                        column: x => x.Genero,
                        principalSchema: "dbo",
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medicos_TipoDocumento_TipoDocumento",
                        column: x => x.TipoDocumento,
                        principalSchema: "dbo",
                        principalTable: "TipoDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                schema: "dbo",
                columns: table => new
                {
                    NumeroDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TipoDocumento = table.Column<int>(type: "int", nullable: false),
                    PrimerNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SegundoNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrimerApellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SegundoApellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    EstadoCivil = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: true),
                    LugarNacimiento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GrupoSanguineo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    TieneAlergias = table.Column<bool>(type: "bit", nullable: false),
                    Alergias = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Medicamentos = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EnfermedadesCronicas = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AntecedentesFamiliares = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.NumeroDocumento);
                    table.ForeignKey(
                        name: "FK_Pacientes_EstadoCivil_EstadoCivil",
                        column: x => x.EstadoCivil,
                        principalSchema: "dbo",
                        principalTable: "EstadoCivil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pacientes_Generos_Genero",
                        column: x => x.Genero,
                        principalSchema: "dbo",
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pacientes_TipoDocumento_TipoDocumento",
                        column: x => x.TipoDocumento,
                        principalSchema: "dbo",
                        principalTable: "TipoDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstadoCivil_Name",
                schema: "dbo",
                table: "EstadoCivil",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Generos_Code",
                schema: "dbo",
                table: "Generos",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_EstadoCivil",
                schema: "dbo",
                table: "Medicos",
                column: "EstadoCivil");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_Genero",
                schema: "dbo",
                table: "Medicos",
                column: "Genero");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_TipoDocumento",
                schema: "dbo",
                table: "Medicos",
                column: "TipoDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_EstadoCivil",
                schema: "dbo",
                table: "Pacientes",
                column: "EstadoCivil");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_Genero",
                schema: "dbo",
                table: "Pacientes",
                column: "Genero");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_TipoDocumento",
                schema: "dbo",
                table: "Pacientes",
                column: "TipoDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDocumento_Name",
                schema: "dbo",
                table: "TipoDocumento",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Pacientes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EstadoCivil",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Generos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TipoDocumento",
                schema: "dbo");
        }
    }
}
