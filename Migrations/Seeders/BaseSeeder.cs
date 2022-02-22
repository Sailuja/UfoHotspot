using System;
using System.Collections.Generic;
using System.Linq;
using UfoHotspot.Models;

namespace UfoHotspot.Migrations.Seeders
{
    public class BaseSeeder
    {
        private readonly ApplicationDbContext _context;

        public BaseSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            List<Hotspot> hotspotlist = new List<Hotspot>
            {
                new Hotspot{ Name="The White House", Latitude = 38.897663, Longitude=-77.036575},
                new Hotspot{ Name="World’s Tallest Thermometer", Latitude = 35.26644, Longitude=-116.07275},
                new Hotspot{ Name="Area 51", Latitude = 37.233333, Longitude=-115.808333},
                new Hotspot{ Name="Disney World’s Magic Kingdom", Latitude = 28.404010, Longitude=-81.576900},
                new Hotspot{ Name="Pop's Soda Bottle", Latitude = 35.658340, Longitude=-97.335490}
            };

            foreach(Hotspot hotspot in hotspotlist)
            {
                if (_context.Hotspot.FirstOrDefault(h => h.Name == hotspot.Name) == null)
                {
                    _context.Hotspot.Add(hotspot);
                }
            }

            _context.SaveChanges();
            
        }
    }
}
