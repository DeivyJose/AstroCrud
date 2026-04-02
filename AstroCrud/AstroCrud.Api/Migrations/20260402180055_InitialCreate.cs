using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AstroCrud.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObservacionesAstronomicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ObjetoCeleste = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FechaObservacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Ubicacion = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 300, nullable: true),
                    TelescopioUsado = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    EsVisible = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObservacionesAstronomicas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ObservacionesAstronomicas",
                columns: new[] { "Id", "Descripcion", "EsVisible", "FechaObservacion", "ObjetoCeleste", "TelescopioUsado", "Titulo", "Ubicacion" },
                values: new object[,]
                {
                    { 1, "Observación nocturna con cielo despejado.", true, new DateTime(2026, 3, 20, 20, 30, 0, 0, DateTimeKind.Unspecified), "Luna", "Celestron 130EQ", "Luna llena sobre la ciudad", "Santo Domingo" },
                    { 2, "Se pudieron observar varias lunas galileanas.", true, new DateTime(2026, 3, 24, 21, 15, 0, 0, DateTimeKind.Unspecified), "Júpiter", "Sky-Watcher 150P", "Júpiter y sus lunas", "La Vega" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObservacionesAstronomicas");
        }
    }
}
