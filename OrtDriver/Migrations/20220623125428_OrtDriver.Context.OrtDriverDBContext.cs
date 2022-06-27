using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrtDriver.Migrations
{
    public partial class OrtDriverContextOrtDriverDBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conductores",
                columns: table => new
                {
                    ConductorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConductorName = table.Column<string>(maxLength: 30, nullable: false),
                    ConductorSurname = table.Column<string>(maxLength: 30, nullable: false),
                    Dni = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    FechaInscripto = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductores", x => x.ConductorId);
                });

            migrationBuilder.CreateTable(
                name: "Viajes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConductorId = table.Column<int>(nullable: false),
                    Origen = table.Column<string>(nullable: false),
                    Destino = table.Column<string>(nullable: false),
                    FechaInscripto = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Viajes_Conductores_ConductorId",
                        column: x => x.ConductorId,
                        principalTable: "Conductores",
                        principalColumn: "ConductorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_ConductorId",
                table: "Viajes",
                column: "ConductorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Viajes");

            migrationBuilder.DropTable(
                name: "Conductores");
        }
    }
}
