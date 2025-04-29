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
            migrationBuilder.DropTable(
                name: "Arrendatarios");

            migrationBuilder.AddColumn<string>(
                name: "ApellidoArrendatario",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ArrendatarioID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CedulaArrendatario",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CorreoArrendatario",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "FechaNacimientoArrendatario",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistroArrendatario",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NombreArrendatario",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TelefonoArrendatario",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
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
