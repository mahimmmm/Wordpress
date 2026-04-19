using System.Collections.Generic;
using System.Linq;

namespace DynamicSessionAutomation.Workers
{
    public static class UserAgentManager
    {
        public static List<string> FilterUserAgents(IEnumerable<string> lines)
        {
            return lines.Where(l => !string.IsNullOrWhiteSpace(l)).Select(l => l.Trim()).ToList();
        }
    }
}
