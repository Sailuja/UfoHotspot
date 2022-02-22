using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UfoHotspot.Migrations.Seeders;
using UfoHotspot.Models;
using UfoHotspot.Models.Views;
using UfoHotspot.Services;

namespace UfoHotspot
{
    class Program
    {
        private static ApplicationDbContext _context;
        private static ISightingTranslator _sightingTranslator;

        private const double HOTSPOT_JSON_DISTANCE_THRESHOLD = 1500;

        static void Main(string[] args)
        {
            bool showMenu = true;
            InitDependencies();
            //Seed all the hotspot details 
            (new BaseSeeder(_context)).Seed();


            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static void InitDependencies()
        {
            _context = new ApplicationDbContext();
            _sightingTranslator = new SightingTranslator(_context);

        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Import CSV into Db");
            Console.WriteLine("2) Download JSON file with hotspot around 1500 km of sighting");
            Console.WriteLine("Press any other key to exit");
            Console.Write("\r\nPlease select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    return ImportCsv();
                case "2":
                    return DownloadJsonFile();
                default:
                    return false;
            }
        }

        private static bool ImportCsv()
        {
            Console.Clear();
            Console.WriteLine("Please enter the file name (must be in the same folder):");

            String FileName = Console.ReadLine();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };

            List<UfoSightingDto> SightingList;
            using (var fs = new StreamReader(FileName))
            {
                using (var csv = new CsvReader(fs, config))
                {
                    SightingList = csv.GetRecords<UfoSightingDto>().ToList();
                }
            }

            //Now import everything into the database
            foreach (UfoSightingDto ufoSightingDto in SightingList)
            {
                Sighting sighting = _sightingTranslator.Translate(ufoSightingDto);
                _context.Sighting.Add(sighting);


            }

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateException ex)
            {
                Console.WriteLine($"Unable to upload document because of - {ex.Message}");
                return false;
            }
           
            Console.WriteLine("Document was uploaded successfully.");
            return true;
        }

        private static bool DownloadJsonFile()
        {
            Console.Clear();
            Console.WriteLine("Please enter the file name with extension:");

            List<VwHotspotSightingDistance> sightingDistances = _context.VwHotspotSightingDistance.Where(h => h.Distance > HOTSPOT_JSON_DISTANCE_THRESHOLD).ToList();

            string json = JsonConvert.SerializeObject(sightingDistances);

            using (FileStream fs = File.Create(Console.ReadLine()))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(json);

                fs.Write(bytes, 0, bytes.Length);
            }

            Console.WriteLine("JSON file was downloaded successfully.");
            return true;
        }
    }
}
