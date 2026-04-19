using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DynamicSessionAutomation.Models;
using DynamicSessionAutomation.Helpers;
using DynamicSessionAutomation.Workers;

namespace DynamicSessionAutomation
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource? _cts;
        private List<AutomationResult> _results = new();
        private bool _isRunning = false;

        public MainForm()
        {
            InitializeComponent();
            Logger.Initialize(this.txtLog);
        }

        private void BtnLoadProxies_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog { Filter = "Text Files|*.txt" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtProxies.Text = File.ReadAllText(ofd.FileName);
            }
        }

        private void BtnLoadUA_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog { Filter = "Text Files|*.txt" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtUserAgents.Text = File.ReadAllText(ofd.FileName);
            }
        }

        private void Txt_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data!.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void TxtProxies_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data!.GetData(DataFormats.FileDrop)!;
            if (files.Length > 0) txtProxies.Text = File.ReadAllText(files[0]);
        }

        private void TxtUA_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data!.GetData(DataFormats.FileDrop)!;
            if (files.Length > 0) txtUserAgents.Text = File.ReadAllText(files[0]);
        }

        private async void BtnStart_Click(object sender, EventArgs e)
        {
            if (_isRunning) return;

            var proxies = ProxyManager.ParseProxies(txtProxies.Lines);
            var userAgents = UserAgentManager.FilterUserAgents(txtUserAgents.Lines);
            string targetUrl = txtTargetUrl.Text.Trim();

            if (string.IsNullOrEmpty(targetUrl))
            {
                MessageBox.Show("Please enter a Target URL.");
                return;
            }

            if (proxies.Count == 0 || userAgents.Count == 0)
            {
                MessageBox.Show("Please provide both Proxies and User Agents.");
                return;
            }

            int taskCount = Math.Min(proxies.Count, userAgents.Count);
            _results.Clear();
            _isRunning = true;
            _cts = new CancellationTokenSource();
            ToggleUI(false);

            Logger.Log($"Starting automation for {taskCount} tasks...", LogType.Progress);
            progressBar.Maximum = taskCount;
            progressBar.Value = 0;

            for (int i = 0; i < taskCount; i++)
            {
                if (_cts.Token.IsCancellationRequested) break;

                UpdateStatus(i + 1, taskCount);
                Logger.Log($"🚀 Starting Task #{i + 1}/{taskCount}", LogType.Info);
                Logger.Log($"📍 Proxy: {proxies[i]}", LogType.Info);

                var config = new SessionConfig
                {
                    Proxy = proxies[i],
                    UserAgent = userAgents[i],
                    TargetUrl = targetUrl,
                    TimeoutSeconds = (int)numTimeout.Value,
                    DelaySeconds = (int)numDelay.Value,
                    HeadlessMode = chkHeadless.Checked,
                    UserDataDir = Path.Combine(Path.GetTempPath(), "DSA_Sessions", $"Session_{i}")
                };

                using var worker = new SessionWorker(config, _cts.Token);
                var result = await worker.RunAsync();
                _results.Add(result);

                if (result.Success)
                {
                    Logger.Log($"✅ Task #{i + 1} COMPLETED", LogType.Success);
                }
                else
                {
                    Logger.Log($"❌ Task #{i + 1} FAILED: {result.ErrorMessage}", LogType.Error);
                }

                progressBar.Value = i + 1;

                if (chkAutoClean.Checked)
                {
                    FileHelper.DeleteDirectory(config.UserDataDir);
                }

                // Explicit GC Collect to manage memory as requested
                GC.Collect();
                GC.WaitForPendingFinalizers();

                if (i < taskCount - 1)
                {
                    await Task.Delay(config.DelaySeconds * 1000, _cts.Token);
                }
            }

            Logger.Log("Automation Finished.", LogType.Progress);
            ShowFinalReport();
            _isRunning = false;
            ToggleUI(true);
            UpdateStatus(progressBar.Value, taskCount, true);
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            Logger.Log("Stopping automation...", LogType.Warning);
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (_results.Count == 0)
            {
                MessageBox.Show("No results to export.");
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV Files|*.csv", FileName = "Report.csv" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var lines = new List<string> { "Proxy,UserAgent,Anonymity,Status,Duration,Error" };
                foreach (var res in _results)
                {
                    lines.Add($"\"{res.Proxy}\",\"{res.UserAgent}\",\"{res.Anonymity}\",\"{res.Status}\",\"{res.Duration}\",\"{res.ErrorMessage}\"");
                }
                File.WriteAllLines(sfd.FileName, lines);
                MessageBox.Show("Report exported successfully.");
            }
        }

        private void BtnClearLog_Click(object sender, EventArgs e) => txtLog.Clear();

        private void ToggleUI(bool enabled)
        {
            btnStart.Enabled = enabled;
            btnLoadProxies.Enabled = enabled;
            btnLoadUA.Enabled = enabled;
            txtProxies.ReadOnly = !enabled;
            txtUserAgents.ReadOnly = !enabled;
            txtTargetUrl.ReadOnly = !enabled;
            groupSettings.Enabled = enabled;
        }

        private void UpdateStatus(int current, int total, bool finished = false)
        {
            int success = _results.Count(r => r.Success);
            int failed = _results.Count(r => !r.Success && r.Status != "Running");
            int remaining = total - current;

            lblStatus.Text = finished
                ? $"✅ Completed: {success} | ❌ Failed: {failed} | Status: Finished"
                : $"✅ Completed: {success} | ❌ Failed: {failed} | ⏳ Remaining: {remaining} | Progress: {(int)((double)current/total*100)}%";
        }

        private void ShowFinalReport()
        {
            int total = _results.Count;
            int success = _results.Count(r => r.Success);
            int failed = total - success;
            double rate = total > 0 ? (double)success / total * 100 : 0;

            string report = $"Automation Report\n" +
                            $"-----------------\n" +
                            $"Total Tasks: {total}\n" +
                            $"Success: {success}\n" +
                            $"Failed: {failed}\n" +
                            $"Success Rate: {rate:F2}%\n";

            MessageBox.Show(report, "Automation Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
