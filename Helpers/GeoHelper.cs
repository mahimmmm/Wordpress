using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DynamicSessionAutomation.Helpers
{
    public class GeoData
    {
        public string Ip { get; set; } = string.Empty;
        public string Timezone { get; set; } = "UTC";
        public string City { get; set; } = "Unknown";
        public string Country { get; set; } = "Unknown";
    }

    public static class GeoHelper
    {
        private static readonly HttpClient _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };

        public static async Task<GeoData> GetGeoDataAsync(string ip)
        {
            try
            {
                // Using ip-api.com (free for non-commercial, no API key needed for basic usage)
                string url = $"http://ip-api.com/json/{ip}";
                string response = await _httpClient.GetStringAsync(url);
                var json = JObject.Parse(response);

                if (json["status"]?.ToString() == "success")
                {
                    return new GeoData
                    {
                        Ip = ip,
                        Timezone = json["timezone"]?.ToString() ?? "UTC",
                        City = json["city"]?.ToString() ?? "Unknown",
                        Country = json["country"]?.ToString() ?? "Unknown"
                    };
                }
            }
            catch { }

            return new GeoData { Ip = ip };
        }
    }
}
