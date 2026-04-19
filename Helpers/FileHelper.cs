using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicSessionAutomation.Helpers
{
    public static class FileHelper
    {
        public static async Task<List<string>> ReadLinesAsync(string filePath)
        {
            if (!File.Exists(filePath)) return new List<string>();
            var lines = await File.ReadAllLinesAsync(filePath);
            return new List<string>(lines);
        }

        public static async Task WriteLinesAsync(string filePath, IEnumerable<string> lines)
        {
            await File.WriteAllLinesAsync(filePath, lines);
        }

        public static void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void DeleteDirectory(string path)
        {
            // Retry mechanism for directory deletion as WebView2 might hold locks
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    if (Directory.Exists(path))
                    {
                        Directory.Delete(path, true);
                    }
                    return;
                }
                catch
                {
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
