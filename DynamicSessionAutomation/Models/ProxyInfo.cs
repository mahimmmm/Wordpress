namespace DynamicSessionAutomation.Models
{
    public class ProxyInfo
    {
        public string IP { get; set; } = string.Empty;
        public int Port { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public static ProxyInfo? Parse(string proxyString)
        {
            if (string.IsNullOrWhiteSpace(proxyString)) return null;
            var parts = proxyString.Trim().Split(':');
            if (parts.Length == 4)
            {
                if (int.TryParse(parts[1], out int port))
                {
                    return new ProxyInfo
                    {
                        IP = parts[0],
                        Port = port,
                        Username = parts[2],
                        Password = parts[3]
                    };
                }
            }
            return null;
        }

        public override string ToString() => $"{IP}:{Port}";
    }
}
