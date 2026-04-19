using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DynamicSessionAutomation.Services
{
    public enum LogLevel
    {
        Info,
        Success,
        Warning,
        Error
    }

    public class Logger
    {
        private readonly RichTextBox _logBox;
        private readonly string _logFilePath;

        public Logger(RichTextBox logBox)
        {
            _logBox = logBox;
            string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            Directory.CreateDirectory(logDir);
            _logFilePath = Path.Combine(logDir, $"log_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
        }

        public void Log(string message, LogLevel level = LogLevel.Info)
        {
            if (_logBox.InvokeRequired)
            {
                _logBox.Invoke(new Action(() => Log(message, level)));
                return;
            }

            Color color = level switch
            {
                LogLevel.Success => Color.Green,
                LogLevel.Warning => Color.Orange,
                LogLevel.Error => Color.Red,
                _ => Color.Black
            };

            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string formattedMessage = $"[{timestamp}] [{level}] {message}";

            _logBox.SelectionStart = _logBox.TextLength;
            _logBox.SelectionLength = 0;
            _logBox.SelectionColor = color;
            _logBox.AppendText(formattedMessage + Environment.NewLine);
            _logBox.SelectionColor = _logBox.ForeColor;
            _logBox.ScrollToCaret();

            try
            {
                File.AppendAllText(_logFilePath, formattedMessage + Environment.NewLine);
            }
            catch { /* Ignore logging errors */ }
        }
    }
}
