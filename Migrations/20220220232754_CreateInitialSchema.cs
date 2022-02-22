using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace UfoHotspot.Migrations
{
    public partial class CreateInitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotspot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Latitude = table.Column<double>(type: "double", nullable: true),
                    Longitude = table.Column<double>(type: "double", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotspot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sighting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SightingDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Shape = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    DurationInSeconds = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    DurationInHours = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Comments = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true),
                    Address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Latitude = table.Column<double>(type: "double", nullable: true),
                    Longitude = table.Column<double>(type: "double", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sighting", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotspot");

            migrationBuilder.DropTable(
                name: "Sighting");
        }
    }
}
