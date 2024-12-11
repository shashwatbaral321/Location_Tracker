using Microsoft.Maui.Essentials;
using System.Threading.Tasks;

namespace LocationTrackerApp
{
    public class GeolocationHelper
    {
        public static async Task<Location> GetCurrentLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();  // Get last known location
                if (location != null)
                {
                    return location;  // Return the obtained location
                }
                return null;  // Return null if location couldn't be fetched
            }
            catch
            {
                return null;
            }
        }
    }
}
