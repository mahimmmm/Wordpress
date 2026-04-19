using System;
using System.Windows.Forms;
using DynamicSessionAutomation.Helpers;

namespace DynamicSessionAutomation
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Global Error Handling
            Application.ThreadException += (s, e) => {
                Logger.Log($"Unhandled Thread Exception: {e.Exception.Message}", LogType.Error);
                MessageBox.Show($"A critical error occurred: {e.Exception.Message}", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            AppDomain.CurrentDomain.UnhandledException += (s, e) => {
                var ex = e.ExceptionObject as Exception;
                Logger.Log($"Unhandled Domain Exception: {ex?.Message}", LogType.Error);
            };

            Application.Run(new MainForm());
        }
    }
}
