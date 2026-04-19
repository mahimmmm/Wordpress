using System;

namespace DynamicSessionAutomation.Models
{
    public class ProfileInfo
    {
        public string Name { get; set; } = string.Empty;
        public string ProxyIp { get; set; } = string.Empty;
        public string UserAgent { get; set; } = string.Empty;
        public string Timezone { get; set; } = "UTC";
        public string MacAddress { get; set; } = string.Empty; // Added property
        public string Anonymity { get; set; } = "0%";
        public string Status { get; set; } = "Created";
        public string UserDataDir { get; set; } = string.Empty;
        public SessionConfig? Config { get; set; }
    }
}
