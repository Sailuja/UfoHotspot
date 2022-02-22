using System;
using System.Linq;
using System.Text.RegularExpressions;
using UfoHotspot.Models;

namespace UfoHotspot.Services
{
    public interface ISightingTranslator
    {
        public Sighting Translate(UfoSightingDto ufoSightingDto);
    }

    public class SightingTranslator : ISightingTranslator
    {
        private readonly ApplicationDbContext _context;

        public SightingTranslator(ApplicationDbContext context)
        {
            _context = context;
        }

        public Sighting Translate(UfoSightingDto ufoSightingDto)
        {
            String LatLongPattern = @"\(([^)]*)\)[^(]*$";
            String LatLong = Regex.Matches(ufoSightingDto.Location, LatLongPattern).First().Value;
            String[] Coordinates = LatLong.Replace("(", string.Empty).Replace(")", string.Empty).Split(":");

            Sighting sighting = new Sighting
            {
                SightingDate = DateTime.TryParse(ufoSightingDto.SightingDate, out DateTime SightingDate) ? SightingDate : null,
                Shape = ufoSightingDto.Shape,
                DurationInSeconds = ufoSightingDto.DurationInSeconds,
                DurationInHours = ufoSightingDto.DurationInHours,
                Comments = ufoSightingDto.Comments,
                Address = ufoSightingDto.Location,
                Latitude = Double.TryParse(Coordinates[0], out Double Latitude) ? Latitude : null,
                Longitude = Double.TryParse(Coordinates[1], out Double Longitude) ? Longitude : null

            };

            return sighting;

        }
    }
}
