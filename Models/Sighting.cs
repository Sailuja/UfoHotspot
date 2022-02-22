using System;
using System.ComponentModel.DataAnnotations;

namespace UfoHotspot.Models
{
    public class Sighting
    {
        [Key]
        public int Id { get; set; }

        public DateTime? SightingDate { get; set; }

        [StringLength(255)]
        public String Shape { get; set; }

        [StringLength(255)]
        public String DurationInSeconds { get; set; }

        [StringLength(255)]
        public String DurationInHours { get; set; }

        [StringLength(1024)]
        public String Comments { get; set; }

        [StringLength(255)]
        public String Address { get; set; }

        public Double? Latitude { get; set; }

        public Double? Longitude { get; set; }
    }
}
