using System.Drawing;

namespace DynamicSessionAutomation.Helpers
{
    public static class WindowSizeDetector
    {
        public static Size GetSizeFromUA(string userAgent)
        {
            userAgent = userAgent.ToLower();

            if (userAgent.Contains("iphone") || userAgent.Contains("android") || userAgent.Contains("mobile"))
            {
                return new Size(375, 667);
            }
            else if (userAgent.Contains("macintosh") || userAgent.Contains("mac os x"))
            {
                return new Size(1440, 900);
            }
            else
            {
                // Default to Windows Desktop
                return new Size(1920, 1080);
            }
        }
    }
}
