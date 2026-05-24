using System;

namespace DynamicSessionAutomation.Models
{
    public class AutomationResult
    {
        public bool Success { get; set; }
        public DateTime ExecutionTime { get; set; } = DateTime.Now;
        public string Proxy { get; set; } = string.Empty;
        public string UserAgent { get; set; } = string.Empty;
        public string Anonymity { get; set; } = "0%";
        public string Status { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public TimeSpan Duration { get; set; }
    }
}
