using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DynamicSessionAutomation.Models;
using DynamicSessionAutomation.Helpers;
using DynamicSessionAutomation.Workers;

namespace DynamicSessionAutomation
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource? _cts;

        // Borderless Window Logic
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int wmNcHitTest = 0x84;
            const int htLeft = 10;
            const int htRight = 11;
            const int htTop = 12;
            const int htTopLeft = 13;
            const int htTopRight = 14;
            const int htBottom = 15;
            const int htBottomLeft = 16;
            const int htBottomRight = 17;

            if (m.Msg == wmNcHitTest)
            {
                int x = LParamToPoint(m.LParam).X;
                int y = LParamToPoint(m.LParam).Y;
                Point p = PointToClient(new Point(x, y));

                if (p.X <= 10 && p.Y <= 10) m.Result = (IntPtr)htTopLeft;
                else if (p.X >= ClientSize.Width - 10 && p.Y <= 10) m.Result = (IntPtr)htTopRight;
                else if (p.X <= 10 && p.Y >= ClientSize.Height - 10) m.Result = (IntPtr)htBottomLeft;
                else if (p.X >= ClientSize.Width - 10 && p.Y >= ClientSize.Height - 10) m.Result = (IntPtr)htBottomRight;
                else if (p.X <= 10) m.Result = (IntPtr)htLeft;
                else if (p.X >= ClientSize.Width - 10) m.Result = (IntPtr)htRight;
                else if (p.Y <= 10) m.Result = (IntPtr)htTop;
                else if (p.Y >= ClientSize.Height - 10) m.Result = (IntPtr)htBottom;
                else m.Result = (IntPtr)0x1;
                return;
            }
            base.WndProc(ref m);
        }

        private Point LParamToPoint(IntPtr lParam)
        {
            int x = (short)(lParam.ToInt32() & 0xFFFF);
            int y = (short)((lParam.ToInt32() >> 16) & 0xFFFF);
            return new Point(x, y);
        }

        private List<ProfileInfo> _profiles = new();
        private bool _isRunning = false;
        private string[] _referrers = {
            "https://www.facebook.com/",
            "https://www.youtube.com/",
            "https://www.pinterest.com/",
            "https://t.co/",
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
            buffer[0] = (byte)(buffer[0] & 0xFE | 0x02);
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

        private async void BtnStart_Click(object sender, EventArgs e)
        {
            if (_isRunning) return;

            string proxiesText = txtProxies.Text.Trim();
            string uaText = txtUserAgents.Text.Trim();
            string targetUrl = txtTargetUrl.Text.Trim();

            var proxyLines = proxiesText.Split(new[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var uaLines = uaText.Split(new[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            var proxyList = ProxyManager.ParseProxies(proxyLines);
            var uaList = UserAgentManager.FilterUserAgents(uaLines);

            if (string.IsNullOrEmpty(targetUrl))
            {
                MessageBox.Show("Target URL (link set) is empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (proxyList.Count == 0)
            {
                MessageBox.Show($"No valid proxies found! Detected {proxyLines.Length} lines, but 0 were valid. Format: ip:port:user:pass", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (uaList.Count == 0)
            {
                MessageBox.Show("User Agent list is empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Logger.Log($"Starting Automation with {proxyList.Count} Proxies and {uaList.Count} UAs.", LogType.Info);

            _isRunning = true;
            _cts = new CancellationTokenSource();
            ToggleUI(false);

            int successCount = 0;
            int proxyIndex = 0;
            int uaIndex = 0;

            while (successCount < uaList.Count && proxyIndex < proxyList.Count)
            {
                if (_cts.Token.IsCancellationRequested) break;

                var proxy = proxyList[proxyIndex];
                var ua = uaList[uaIndex];

                Logger.Log($"🚀 Profile {successCount + 1} - Proxy: {proxy.Ip}", LogType.Info);

                var geo = await GeoHelper.GetGeoDataAsync(proxy.Ip);
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
                    var profile = new ProfileInfo
                    {
                        Name = $"Profile {successCount + 1}",
                        ProxyIp = proxy.Ip,
                        UserAgent = ua,
                        Timezone = geo.Timezone,
                        MacAddress = mac,
                        Anonymity = result.Anonymity,
                        Status = "Active",
                        UserDataDir = config.UserDataDir,
                        Config = config
                    };

                    _profiles.Add(profile);
                    UpdateDashboard(profile);
                    successCount++;
                    uaIndex++;

                    if (successCount < uaList.Count)
                        await Task.Delay(config.DelaySeconds * 1000, _cts.Token);
                }
                else
                {
                    Logger.Log($"❌ Proxy {proxy.Ip} Failed. Trying next proxy...", LogType.Warning);
                }

                proxyIndex++;
                UpdateProgress(successCount, uaList.Count);
            }

            Logger.Log("Automation Task Finished.", LogType.Progress);
            _isRunning = false;
            ToggleUI(true);
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            Logger.Log("Automation Stopped.", LogType.Warning);
        }

        private void UpdateDashboard(ProfileInfo profile)
        {
            if (dgvProfiles.InvokeRequired) { dgvProfiles.Invoke(new Action(() => UpdateDashboard(profile))); return; }
            dgvProfiles.Rows.Add(profile.Name, profile.ProxyIp, profile.MacAddress, profile.Timezone, profile.Anonymity);
        }

        private void BtnOpenProfile_Click(object sender, EventArgs e)
        {
            if (dgvProfiles.SelectedRows.Count == 0) return;
            string profileName = dgvProfiles.SelectedRows[0].Cells[0].Value.ToString()!;
            var profile = _profiles.FirstOrDefault(p => p.Name == profileName);
            if (profile != null && profile.Config != null)
            {
                var interactiveWorker = new SessionWorker(profile.Config, CancellationToken.None, true);
                _ = interactiveWorker.RunAsync();
            }
        }

        private void UpdateProgress(int current, int total)
        {
            if (statusStrip.InvokeRequired) { statusStrip.Invoke(new Action(() => UpdateProgress(current, total))); return; }
            progressBar.Maximum = total;
            progressBar.Value = Math.Min(current, total);
            lblStatus.Text = $"Profiles: {current}/{total} | Ready";
        }

        private void ToggleUI(bool enabled)
        {
            btnStart.Enabled = enabled;
            txtTargetUrl.ReadOnly = !enabled;
        }

        private void BtnExport_Click(object sender, EventArgs e) => MessageBox.Show("Report exported.");
        private void BtnClearLog_Click(object sender, EventArgs e) => txtLog.Clear();
    }
}
