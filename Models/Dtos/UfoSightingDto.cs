using System;
using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace UfoHotspot.Models
{
    public class UfoSightingDto
    {
        [Index(0)]
        [StringLength(255)]
        public String SightingDate { get; set; }

        [Index(1)]
        [StringLength(255)]
        public String Shape { get; set; }

        [Index(2)]
        [StringLength(255)]
        public String DurationInSeconds { get; set; }

        [Index(3)]
        [StringLength(255)]
        public String DurationInHours { get; set; }

        [Index(4)]
        [StringLength(1024)]
        public String Comments { get; set; }

        [Index(5)]
        [StringLength(512)]
        public String Location { get; set; }
    }
}
