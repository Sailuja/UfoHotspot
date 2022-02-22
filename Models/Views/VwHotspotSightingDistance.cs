using System;
namespace UfoHotspot.Models.Views
{
    public class VwHotspotSightingDistance
    {
        public String HotspotName { get; set; }

        public DateTime? SightingDate { get; set; }

        public String Shape { get; set; }

        public String DurationInSeconds { get; set; }

        public String DurationInHours { get; set; }

        public String Comments { get; set; }

        public String Address { get; set; }

        public Double? SightingLat { get; set; }

        public Double? SightingLng { get; set; }

        public Double? HotspotLat { get; set; }

        public Double? HotspotLng { get; set; }

        public Double? Distance { get; set; }
    }
}
