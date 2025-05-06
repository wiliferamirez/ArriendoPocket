using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArriendoPocket.Data.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaUsariosNet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApellidoArrendatario",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ArrendatarioID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CedulaArrendatario",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CorreoArrendatario",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FechaNacimientoArrendatario",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FechaRegistroArrendatario",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NombreArrendatario",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TelefonoArrendatario",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Arrendatarios",
                columns: table => new
                {
                    ArrendatarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApellidoArrendatario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CedulaArrendatario = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CorreoArrendatario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimientoArrendatario = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaRegistroArrendatario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombreArrendatario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoArrendatario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrendatarios", x => x.ArrendatarioID);
                });
        }
    }
}
