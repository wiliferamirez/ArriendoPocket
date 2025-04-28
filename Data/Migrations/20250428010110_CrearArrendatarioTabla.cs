using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArriendoPocket.Data.Migrations
{
    /// <inheritdoc />
    public partial class CrearArrendatarioTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arrendatarios",
                columns: table => new
                {
                    ArrendatarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CedulaArrendatario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NombreArrendatario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoArrendatario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoArrendatario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoArrendatario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimientoArrendatario = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaRegistroArrendatario = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrendatarios", x => x.ArrendatarioID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arrendatarios");
        }
    }
}
