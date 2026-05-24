using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DynamicSessionAutomation.Helpers
{
    public enum LogType
    {
        Info,
        Success,
        Warning,
        Error,
        Progress
    }

    public static class Logger
    {
        private static RichTextBox? _logControl;
        private static readonly string LogDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

        public static void Initialize(RichTextBox control)
        {
            _logControl = control;
            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }
        }

        public static void Log(string message, LogType type = LogType.Info)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string formattedMessage = $"[{timestamp}] {message}";

            // Log to UI
            if (_logControl != null)
            {
                if (_logControl.InvokeRequired)
                {
                    _logControl.Invoke(new Action(() => AppendToRichTextBox(formattedMessage, type)));
                }
                else
                {
                    AppendToRichTextBox(formattedMessage, type);
                }
            }

            // Log to File
            LogToFile(formattedMessage, type);
        }

        private static void AppendToRichTextBox(string message, LogType type)
        {
            if (_logControl == null) return;

            Color color = type switch
            {
                LogType.Success => Color.Green,
                LogType.Error => Color.Red,
                LogType.Warning => Color.Orange,
                LogType.Progress => Color.Cyan,
                _ => Color.White
            };

            _logControl.SelectionStart = _logControl.TextLength;
            _logControl.SelectionLength = 0;
            _logControl.SelectionColor = color;
            _logControl.AppendText(message + Environment.NewLine);
            _logControl.SelectionColor = _logControl.ForeColor;
            _logControl.ScrollToCaret();
        }

        private static void LogToFile(string message, LogType type)
        {
            try
            {
                string fileName = $"Log_{DateTime.Now:yyyyMMdd}.txt";
                string filePath = Path.Combine(LogDirectory, fileName);
                string fileEntry = $"[{type.ToString().ToUpper()}] {message}{Environment.NewLine}";
                File.AppendAllText(filePath, fileEntry);

                // Save failed/success proxies separately if specified
                if (type == LogType.Success && message.Contains("Proxy:"))
                {
                    File.AppendAllText(Path.Combine(LogDirectory, "Success_Proxies.txt"), message + Environment.NewLine);
                }
                else if (type == LogType.Error && message.Contains("Proxy:"))
                {
                    File.AppendAllText(Path.Combine(LogDirectory, "Failed_Proxies.txt"), message + Environment.NewLine);
                }
            }
            catch { /* Ignore logging errors */ }
        }
    }
}
