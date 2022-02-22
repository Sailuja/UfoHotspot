using System;
using Microsoft.EntityFrameworkCore;
using UfoHotspot.Models.Views;

namespace UfoHotspot.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Sighting> Sighting { get; set; }
        public DbSet<Hotspot> Hotspot { get; set; }


        //views
        public DbSet<VwHotspotSightingDistance> VwHotspotSightingDistance { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"Server=127.0.0.1;Port=33060;Database=UfoHotspot;Uid=root;Pwd=test;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<VwHotspotSightingDistance>()
                .ToView(nameof(VwHotspotSightingDistance))
                .HasNoKey();
        }
    }
}
