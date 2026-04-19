using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DynamicSessionAutomation.Models;
using DynamicSessionAutomation.Services;

namespace DynamicSessionAutomation
{
    public partial class Form1 : Form
    {
        private Logger? _logger;
        private CancellationTokenSource? _cts;
        private List<AutomationResult> _results = new List<AutomationResult>();

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _logger = new Logger(rtbLogs);
            _logger.Log("Application started. Ready for input.", LogLevel.Info);
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            string[] proxyLines = txtProxies.Lines;
            string[] uaLines = txtUAs.Lines;
            string targetUrl = txtTargetUrl.Text.Trim();

            if (proxyLines.Length == 0 || uaLines.Length == 0 || string.IsNullOrEmpty(targetUrl))
            {
                MessageBox.Show("Please provide proxies, user agents, and a target URL.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var proxies = proxyLines.Select(p => ProxyInfo.Parse(p)).Where(p => p != null).Cast<ProxyInfo>().ToList();
            var uas = uaLines.Where(ua => !string.IsNullOrWhiteSpace(ua)).Select(ua => UserAgentInfo.Parse(ua)).ToList();

            if (proxies.Count == 0)
            {
                MessageBox.Show("No valid proxies found. Format: ip:port:user:pass", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ToggleUI(true);
            _results.Clear();
            _cts = new CancellationTokenSource();
            _logger?.Log($"Starting automation for {proxies.Count} proxy-UA pairs...", LogLevel.Info);

            progressBar.Maximum = proxies.Count;
            progressBar.Value = 0;

            SessionManager sessionManager = new SessionManager(_logger!, targetUrl);

            try
            {
                for (int i = 0; i < proxies.Count; i++)
                {
                    if (_cts.Token.IsCancellationRequested) break;

                    var proxy = proxies[i];
                    // Use UA in rotation or first one if fewer UAs than proxies
                    var ua = uas[i % uas.Count];

                    lblStatus.Text = $"Processing session {i + 1}/{proxies.Count}...";

                    var result = await sessionManager.RunSessionAsync(proxy, ua, this);
                    _results.Add(result);

                    progressBar.Value = i + 1;
                }

                _logger?.Log("Automation completed.", LogLevel.Success);
                lblStatus.Text = "Completed";
            }
            catch (OperationCanceledException)
            {
                _logger?.Log("Automation stopped by user.", LogLevel.Warning);
                lblStatus.Text = "Stopped";
            }
            catch (Exception ex)
            {
                _logger?.Log($"Fatal error: {ex.Message}", LogLevel.Error);
                lblStatus.Text = "Error occurred";
            }
            finally
            {
                ToggleUI(false);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            btnStop.Enabled = false;
            _logger?.Log("Stop requested...", LogLevel.Warning);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_results.Count == 0)
            {
                MessageBox.Show("No results to export.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.FileName = $"Results_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("Timestamp,Proxy,UserAgent,Anonymity,Status");
                        foreach (var res in _results)
                        {
                            sb.AppendLine($"{res.Timestamp},{res.Proxy},\"{res.UserAgent.Replace("\"", "\"\"")}\",{res.Anonymity},{res.Status}");
                        }
                        File.WriteAllText(sfd.FileName, sb.ToString());
                        MessageBox.Show($"Results exported to {sfd.FileName}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Export failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ToggleUI(bool running)
        {
            btnStart.Enabled = !running;
            btnStop.Enabled = running;
            txtProxies.Enabled = !running;
            txtUAs.Enabled = !running;
            txtTargetUrl.Enabled = !running;
            btnExport.Enabled = !running;
        }
    }
}
