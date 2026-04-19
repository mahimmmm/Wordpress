using System;
using System.Collections.Generic;
using DynamicSessionAutomation.Models;

namespace DynamicSessionAutomation.Workers
{
    public static class ProxyManager
    {
        public static List<ProxyInfo> ParseProxies(IEnumerable<string> lines)
        {
            var proxies = new List<ProxyInfo>();
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(':');
                if (parts.Length >= 2)
                {
                    var proxy = new ProxyInfo
                    {
                        Ip = parts[0].Trim(),
                        Port = int.TryParse(parts[1].Trim(), out int port) ? port : 80
                    };

                    if (parts.Length >= 4)
                    {
                        proxy.Username = parts[2].Trim();
                        proxy.Password = parts[3].Trim();
                    }

                    proxies.Add(proxy);
                }
            }
            return proxies;
        }
    }
}
