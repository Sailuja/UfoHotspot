using Microsoft.EntityFrameworkCore.Migrations;

namespace UfoHotspot.Migrations
{
    public partial class CreateHotspotDistanceView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW VwHotspotSightingDistance AS (SELECT Tbl.*, 
                (6371 * acos(cos(radians(Tbl.HotspotLat)) * cos(radians(Tbl.SightingLat))
                * cos(radians(Tbl.SightingLng) - radians(Tbl.HotspotLng)) + sin(radians(Tbl.HotspotLat)) * sin(radians(Tbl.SightingLat)))) as Distance
                 FROM(
                SELECT h.Name AS HotspotName, h.Latitude AS HotspotLat, h.Longitude AS HotspotLng,
                s.Latitude AS SightingLat, s.Longitude AS SightingLng,
                s.SightingDate, s.Shape, s.DurationInSeconds, s.DurationInHours, s.Address, s.Comments
                FROM UfoHotspot.Sighting s, UfoHotspot.Hotspot h
                ) AS Tbl)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW VwHotspotSightingDistance");
        }
    }
}
