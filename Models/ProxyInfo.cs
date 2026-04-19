namespace DynamicSessionAutomation.Models
{
    public class ProxyInfo
    {
        public string Ip { get; set; } = string.Empty;
        public int Port { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsValid { get; set; } = true;

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Username))
                return $"{Ip}:{Port}";
            return $"{Ip}:{Port}:{Username}:{Password}";
        }
    }
}
