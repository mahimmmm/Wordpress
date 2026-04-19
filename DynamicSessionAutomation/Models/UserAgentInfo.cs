namespace DynamicSessionAutomation.Models
{
    public class UserAgentInfo
    {
        public string UserAgent { get; set; } = string.Empty;
        public int Width { get; set; } = 1280;
        public int Height { get; set; } = 720;
        public bool IsMobile { get; set; }

        public static UserAgentInfo Parse(string uaString)
        {
            bool isMobile = uaString.Contains("Mobi") || uaString.Contains("Android") || uaString.Contains("iPhone");
            return new UserAgentInfo
            {
                UserAgent = uaString,
                IsMobile = isMobile,
                Width = isMobile ? 375 : 1280,
                Height = isMobile ? 812 : 720
            };
        }
    }
}
