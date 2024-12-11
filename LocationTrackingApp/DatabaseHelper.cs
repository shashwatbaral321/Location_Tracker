using SQLite;
using System.IO;
using System.Collections.Generic;
using Microsoft.Maui.Storage;

namespace LocationTrackerApp.Database
{
    public class DatabaseHelper
    {
        private SQLiteConnection _db;

        public DatabaseHelper()
        {
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "locations.db");
            _db = new SQLiteConnection(databasePath);
            _db.CreateTable<Location>();  // Create the locations table if not exists
        }

        public void SaveLocation(double latitude, double longitude, string address)
        {
            var location = new Location { Latitude = latitude, Longitude = longitude, Address = address, Timestamp = DateTime.Now };
            _db.Insert(location);
        }

        public List<Location> GetLocations()
        {
            return _db.Table<Location>().ToList();  // Retrieve all saved locations
        }
    }

    public class Location
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
