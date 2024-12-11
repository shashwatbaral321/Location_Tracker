using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using LocationTrackerApp.Database;
using System;
using System.Collections.Generic;

namespace LocationTrackerApp
{
    public partial class MainPage : ContentPage
    {
        private DatabaseHelper _db;

        public MainPage()
        {
            InitializeComponent();
            _db = new DatabaseHelper();
            TrackLocation();
        }

        private async void TrackLocation()
        {
            try
            {
                var location = await GeolocationHelper.GetCurrentLocation();  // Get current location
                if (location != null)
                {
                    // Save the location to the database
                    _db.SaveLocation(location.Latitude, location.Longitude, "Lubbock, TX");
                    
                    // Move the map to the current location
                    locationMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(location.Latitude, location.Longitude), Distance.FromMiles(1)));
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Unable to get location: " + ex.Message, "OK");
            }

            // Generate and display the heatmap with stored locations
            List<Location> locations = _db.GetLocations();
            HeatmapLogic.GenerateHeatmap(locationMap, locations);
        }
    }
}
