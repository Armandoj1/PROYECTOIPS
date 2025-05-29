using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IPSUPC.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Administrador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CargosAdministradores",
                columns: table => new
                {
                    CargoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargosAdministradores", x => x.CargoId);
                });

            migrationBuilder.CreateTable(
                name: "Administradores",
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
                    Cargo = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FechaSalida = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.NumeroDocumento);
                    table.ForeignKey(
                        name: "FK_Administradores_CargosAdministradores_Cargo",
                        column: x => x.Cargo,
                        principalTable: "CargosAdministradores",
                        principalColumn: "CargoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Administradores_EstadoCivil_EstadoCivil",
                        column: x => x.EstadoCivil,
                        principalSchema: "dbo",
                        principalTable: "EstadoCivil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Administradores_Generos_Genero",
                        column: x => x.Genero,
                        principalSchema: "dbo",
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Administradores_TipoDocumento_TipoDocumento",
                        column: x => x.TipoDocumento,
                        principalSchema: "dbo",
                        principalTable: "TipoDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CargosAdministradores",
                columns: new[] { "CargoId", "Nombre" },
                values: new object[,]
                {
                    { 1, "GERENTE GENERAL" },
                    { 2, "DIRECTOR DE IPS" },
                    { 3, "DIRECTOR MÉDICO" },
                    { 4, "JEFE DE RECURSOS HUMANOS" },
                    { 5, "AUXILIAR ADMINISTRATIVO" },
                    { 6, "COORDINADOR DE CITAS" },
                    { 7, "SUPERVISOR GENERAL" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_Cargo",
                schema: "dbo",
                table: "Administradores",
                column: "Cargo");

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_EstadoCivil",
                schema: "dbo",
                table: "Administradores",
                column: "EstadoCivil");

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_Genero",
                schema: "dbo",
                table: "Administradores",
                column: "Genero");

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_TipoDocumento",
                schema: "dbo",
                table: "Administradores",
                column: "TipoDocumento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CargosAdministradores");
        }
    }
}