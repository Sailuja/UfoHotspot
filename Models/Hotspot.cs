using System;
using System.ComponentModel.DataAnnotations;

namespace UfoHotspot.Models
{
    public class Hotspot
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public String Name { get; set; }

        public Double? Latitude { get; set; }

        public Double? Longitude { get; set; }
    }
}
