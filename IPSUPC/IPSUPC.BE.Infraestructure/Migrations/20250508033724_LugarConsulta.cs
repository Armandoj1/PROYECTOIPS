using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IPSUPC.BE.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class LugarConsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 🔥 Limpieza previa de la columna LugarConsultaID en CitasMedicas
            migrationBuilder.Sql(@"
                IF EXISTS (
                    SELECT * FROM sys.foreign_keys 
                    WHERE name = 'FK_CitasMedicas_LugarConsulta_LugarConsultaID'
                )
                BEGIN
                    ALTER TABLE CitasMedicas DROP CONSTRAINT FK_CitasMedicas_LugarConsulta_LugarConsultaID
                END

                IF EXISTS (
                    SELECT * FROM sys.indexes 
                    WHERE name = 'IX_CitasMedicas_LugarConsultaID'
                )
                BEGIN
                    DROP INDEX IX_CitasMedicas_LugarConsultaID ON CitasMedicas
                END

                DECLARE @sql NVARCHAR(MAX)
                SELECT @sql = (
                    SELECT 'ALTER TABLE CitasMedicas DROP CONSTRAINT [' + dc.name + ']'
                    FROM sys.default_constraints dc
                    INNER JOIN sys.columns c ON dc.parent_object_id = c.object_id AND dc.parent_column_id = c.column_id
                    WHERE dc.parent_object_id = OBJECT_ID('CitasMedicas') AND c.name = 'LugarConsultaID'
                )
                IF @sql IS NOT NULL
                BEGIN
                    EXEC sp_executesql @sql
                END

                IF EXISTS (
                    SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
                    WHERE TABLE_NAME = 'CitasMedicas' AND COLUMN_NAME = 'LugarConsultaID'
                )
                BEGIN
                    ALTER TABLE CitasMedicas DROP COLUMN LugarConsultaID
                END
            ");

            // 🔄 Borra la tabla si ya existe
            migrationBuilder.Sql(@"
                IF OBJECT_ID('dbo.LugarConsulta', 'U') IS NOT NULL
                DROP TABLE dbo.LugarConsulta
            ");

            // 🔧 Agrega la columna de nuevo
            migrationBuilder.AddColumn<int>(
                name: "LugarConsultaID",
                table: "CitasMedicas",
                type: "int",
                nullable: false,
                defaultValue: 2);

            // 🏗️ Crea tabla LugarConsulta
            migrationBuilder.CreateTable(
                name: "LugarConsulta",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LugarConsulta", x => x.Id);
                });

            // 📌 Datos semilla
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "LugarConsulta",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "CONSULTORIO 1 PRIMER PISO" },
                    { 2, "CONSULTORIO 2 PRIMER PISO" },
                    { 3, "CONSULTORIO 3 SEGUNDO PISO" },
                    { 4, "CONSULTORIO 4 SEGUNDO PISO" }
                });

            // 🔐 FK + Índices
            migrationBuilder.CreateIndex(
                name: "IX_CitasMedicas_LugarConsultaID",
                table: "CitasMedicas",
                column: "LugarConsultaID");

            migrationBuilder.CreateIndex(
                name: "IX_LugarConsulta_Name",
                schema: "dbo",
                table: "LugarConsulta",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CitasMedicas_LugarConsulta_LugarConsultaID",
                table: "CitasMedicas",
                column: "LugarConsultaID",
                principalSchema: "dbo",
                principalTable: "LugarConsulta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitasMedicas_LugarConsulta_LugarConsultaID",
                table: "CitasMedicas");

            migrationBuilder.DropTable(
                name: "LugarConsulta",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_CitasMedicas_LugarConsultaID",
                table: "CitasMedicas");

            migrationBuilder.DropColumn(
                name: "LugarConsultaID",
                table: "CitasMedicas");
        }
    }
}
