namespace DynamicSessionAutomation.Models
{
    public class SessionConfig
    {
        public ProxyInfo? Proxy { get; set; }
        public string UserAgent { get; set; } = string.Empty;
        public string TargetUrl { get; set; } = string.Empty;
        public int TimeoutSeconds { get; set; } = 30;
        public int DelaySeconds { get; set; } = 3;
        public bool HeadlessMode { get; set; } = false;
        public string UserDataDir { get; set; } = string.Empty;
    }
}
