using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArriendoPocket.Data.Migrations
{
    /// <inheritdoc />
    public partial class PropiedadMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Propiedades",
                columns: table => new
                {
                    PropiedadID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrendatarioID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreInquilino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AliasPropiedad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionPropiedad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroHabitaciones = table.Column<int>(type: "int", nullable: false),
                    CanonArrendatario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    MesesGarantia = table.Column<int>(type: "int", nullable: false),
                    NumeroPisos = table.Column<int>(type: "int", nullable: false),
                    AreaConstruccion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CiudadUbicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaConstruccion = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propiedades", x => x.PropiedadID);
                    table.ForeignKey(
                        name: "FK_Propiedades_AspNetUsers_ArrendatarioID",
                        column: x => x.ArrendatarioID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Propiedades_ArrendatarioID",
                table: "Propiedades",
                column: "ArrendatarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Propiedades");
        }
    }
}
