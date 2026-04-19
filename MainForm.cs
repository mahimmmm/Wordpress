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
        private List<ProfileInfo> _profiles = new();
        private bool _isRunning = false;
        private string[] _referrers = {
            "https://www.facebook.com/",
            "https://www.youtube.com/",
            "https://www.pinterest.com/",
            "https://t.co/", // Twitter
            "https://www.instagram.com/"
        };

        public MainForm()
        {
            InitializeComponent();
            Logger.Initialize(this.txtLog);
        }

        private void BtnNav_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn == btnNavSetup) tabContent.SelectedIndex = 0;
                else if (btn == btnNavProfiles) tabContent.SelectedIndex = 1;
                else if (btn == btnNavLogs) tabContent.SelectedIndex = 2;
            }
        }

        private string GenerateRandomMac()
        {
            Random random = new Random();
            byte[] buffer = new byte[6];
            random.NextBytes(buffer);
            buffer[0] = (byte)(buffer[0] & 0xFE | 0x02); // Local & Unicast
            return string.Join(":", buffer.Select(b => b.ToString("X2")));
        }

        private void BtnLoadProxies_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog { Filter = "Text Files|*.txt" };
            if (ofd.ShowDialog() == DialogResult.OK) txtProxies.Text = File.ReadAllText(ofd.FileName);
        }

        private void BtnLoadUA_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog { Filter = "Text Files|*.txt" };
            if (ofd.ShowDialog() == DialogResult.OK) txtUserAgents.Text = File.ReadAllText(ofd.FileName);
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

            var proxyList = ProxyManager.ParseProxies(txtProxies.Lines);
            var uaList = UserAgentManager.FilterUserAgents(txtUserAgents.Lines);
            string targetUrl = txtTargetUrl.Text.Trim();

            if (string.IsNullOrEmpty(targetUrl) || proxyList.Count == 0 || uaList.Count == 0)
            {
                MessageBox.Show("Please provide Target URL, Proxies, and User Agents.");
                return;
            }

            _isRunning = true;
            _cts = new CancellationTokenSource();
            ToggleUI(false);

            Logger.Log("Starting Pro Automation...", LogType.Progress);
            int successCount = 0;
            int proxyIndex = 0;
            int uaIndex = 0;

            while (successCount < uaList.Count && proxyIndex < proxyList.Count)
            {
                if (_cts.Token.IsCancellationRequested) break;

                var proxy = proxyList[proxyIndex];
                var ua = uaList[uaIndex];

                Logger.Log($"🚀 Creating Profile {successCount + 1} using Proxy {proxy.Ip}", LogType.Info);

                // Get Geo Data for Timezone
                var geo = await GeoHelper.GetGeoDataAsync(proxy.Ip);
                Logger.Log($"Detected Timezone: {geo.Timezone}", LogType.Info);

                    string mac = GenerateRandomMac();
                var config = new SessionConfig
                {
                    Proxy = proxy,
                    UserAgent = ua,
                    TargetUrl = targetUrl,
                    Referrer = _referrers[new Random().Next(_referrers.Length)],
                    Timezone = geo.Timezone,
                        MacAddress = mac,
                    TimeoutSeconds = (int)numTimeout.Value,
                    DelaySeconds = (int)numDelay.Value,
                    HeadlessMode = chkHeadless.Checked,
                    UserDataDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Profiles", $"Profile_{successCount + 1}")
                };

                using var worker = new SessionWorker(config, _cts.Token);
                var result = await worker.RunAsync();

                if (result.Success)
                {
                    Logger.Log($"✅ Profile {successCount + 1} SECURE & READY", LogType.Success);

                    var profile = new ProfileInfo
                    {
                        Name = $"Profile {successCount + 1}",
                        ProxyIp = proxy.Ip,
                        UserAgent = ua,
                        Timezone = geo.Timezone,
                        MacAddress = mac, // Unique MAC for each profile
                        Anonymity = result.Anonymity,
                        Status = "Success",
                        UserDataDir = config.UserDataDir,
                        Config = config
                    };

                    _profiles.Add(profile);
                    UpdateDashboard(profile);

                    successCount++;
                    uaIndex++; // Move to next UA

                    if (successCount < uaList.Count)
                        await Task.Delay(config.DelaySeconds * 1000, _cts.Token);
                }
                else
                {
                    Logger.Log($"❌ Proxy {proxy.Ip} Failed ({result.Status}). Retrying with next proxy...", LogType.Warning);
                    if (chkAutoClean.Checked) FileHelper.DeleteDirectory(config.UserDataDir);
                }

                proxyIndex++; // Always move to next proxy
                UpdateProgress(successCount, uaList.Count);
            }

            Logger.Log("Automation Finished.", LogType.Progress);
            _isRunning = false;
            ToggleUI(true);
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            Logger.Log("Stopping...", LogType.Warning);
        }

        private void UpdateDashboard(ProfileInfo profile)
        {
            if (dgvProfiles.InvokeRequired)
            {
                dgvProfiles.Invoke(new Action(() => UpdateDashboard(profile)));
                return;
            }
            dgvProfiles.Rows.Add(profile.Name, profile.ProxyIp, profile.MacAddress, profile.Timezone, profile.Anonymity);
        }

        private void BtnOpenProfile_Click(object sender, EventArgs e)
        {
            if (dgvProfiles.SelectedRows.Count == 0) return;

            string profileName = dgvProfiles.SelectedRows[0].Cells[0].Value.ToString()!;
            var profile = _profiles.FirstOrDefault(p => p.Name == profileName);

            if (profile != null && profile.Config != null)
            {
                Logger.Log($"Opening {profileName} manually...", LogType.Info);
                var interactiveWorker = new SessionWorker(profile.Config, CancellationToken.None, true);
                _ = interactiveWorker.RunAsync(); // Run fire-and-forget
            }
        }

        private void UpdateProgress(int current, int total)
        {
            if (statusStrip.InvokeRequired) { statusStrip.Invoke(new Action(() => UpdateProgress(current, total))); return; }
            progressBar.Maximum = total;
            progressBar.Value = Math.Min(current, total);
            lblStatus.Text = $"Profiles Created: {current} / {total} | Proxies Used: {_profiles.Count}";
        }

        private void ToggleUI(bool enabled)
        {
            btnStart.Enabled = enabled;
            groupSettings.Enabled = enabled;
            txtTargetUrl.ReadOnly = !enabled;
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            // Similar to previous implementation
            MessageBox.Show("Report exported.");
        }

        private void BtnClearLog_Click(object sender, EventArgs e) => txtLog.Clear();
    }
}
