using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using LocationTrackerApp.Database;
using System.Collections.Generic;

namespace LocationTrackerApp
{
    public class HeatmapLogic
    {
        public static void GenerateHeatmap(Map map, List<Location> locations)
        {
            foreach (var loc in locations)
            {
                var position = new Location(loc.Latitude, loc.Longitude);
                map.Pins.Add(new Pin
                {
                    Label = "Location",
                    Position = position,
                    Type = PinType.Place
                });
            }
        }
    }
}
