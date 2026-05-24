namespace DynamicSessionAutomation
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.btnMax = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnNavSetup = new System.Windows.Forms.Button();
            this.btnNavProfiles = new System.Windows.Forms.Button();
            this.btnNavLogs = new System.Windows.Forms.Button();
            this.tabContent = new System.Windows.Forms.TabControl();
            this.tabSetup = new System.Windows.Forms.TabPage();
            this.tabProfiles = new System.Windows.Forms.TabPage();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.txtProxies = new System.Windows.Forms.RichTextBox();
            this.txtUserAgents = new System.Windows.Forms.RichTextBox();
            this.txtTargetUrl = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.dgvProfiles = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimezone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnonymity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOpenProfile = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblProxies = new System.Windows.Forms.Label();
            this.lblUserAgents = new System.Windows.Forms.Label();
            this.lblTargetUrl = new System.Windows.Forms.Label();
            this.groupSettings = new System.Windows.Forms.GroupBox();
            this.chkAutoClean = new System.Windows.Forms.CheckBox();
            this.chkSaveLogs = new System.Windows.Forms.CheckBox();
            this.chkHeadless = new System.Windows.Forms.CheckBox();
            this.numTimeout = new System.Windows.Forms.NumericUpDown();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.lblDelay = new System.Windows.Forms.Label();
            this.btnLoadProxies = new System.Windows.Forms.Button();
            this.btnLoadUA = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();

            this.pnlBackground.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlTitleBar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.tabContent.SuspendLayout();
            this.tabSetup.SuspendLayout();
            this.tabProfiles.SuspendLayout();
            this.tabLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.groupSettings.SuspendLayout();
            this.SuspendLayout();

            // pnlBackground
            this.pnlBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.pnlBackground.Controls.Add(this.pnlContent);
            this.pnlBackground.Controls.Add(this.pnlSidebar);
            this.pnlBackground.Controls.Add(this.pnlTitleBar);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(1100, 750);

            // pnlTitleBar
            this.pnlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.pnlTitleBar.Controls.Add(this.lblTitle);
            this.pnlTitleBar.Controls.Add(this.btnMax);
            this.pnlTitleBar.Controls.Add(this.btnMin);
            this.pnlTitleBar.Controls.Add(this.btnExit);
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Size = new System.Drawing.Size(1100, 35);
            this.pnlTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);

            // Traffic Lights
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(255, 95, 88);
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.Location = new System.Drawing.Point(10, 10);
            this.btnExit.Size = new System.Drawing.Size(12, 12);
            this.btnExit.Click += (s, e) => Application.Exit();

            this.btnMin.BackColor = System.Drawing.Color.FromArgb(255, 189, 46);
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.Location = new System.Drawing.Point(30, 10);
            this.btnMin.Size = new System.Drawing.Size(12, 12);
            this.btnMin.Click += (s, e) => this.WindowState = System.Windows.Forms.FormWindowState.Minimized;

            this.btnMax.BackColor = System.Drawing.Color.FromArgb(40, 200, 64);
            this.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMax.FlatAppearance.BorderSize = 0;
            this.btnMax.Location = new System.Drawing.Point(50, 10);
            this.btnMax.Size = new System.Drawing.Size(12, 12);
            this.btnMax.Click += (s, e) => this.WindowState = (this.WindowState == System.Windows.Forms.FormWindowState.Maximized) ? System.Windows.Forms.FormWindowState.Normal : System.Windows.Forms.FormWindowState.Maximized;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblTitle.Location = new System.Drawing.Point(450, 10);
            this.lblTitle.Text = "CPA MAHIM - Dynamic Session Automation";

            // pnlSidebar
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.pnlSidebar.Controls.Add(this.btnNavSetup);
            this.pnlSidebar.Controls.Add(this.btnNavProfiles);
            this.pnlSidebar.Controls.Add(this.btnNavLogs);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 35);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(200, 715);

            // Nav Buttons
            this.btnNavSetup.FlatAppearance.BorderSize = 0;
            this.btnNavSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSetup.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnNavSetup.Location = new System.Drawing.Point(5, 50);
            this.btnNavSetup.Size = new System.Drawing.Size(190, 45);
            this.btnNavSetup.Text = "  🏠 Setup";
            this.btnNavSetup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavSetup.Click += new System.EventHandler(this.BtnNav_Click);

            this.btnNavProfiles.FlatAppearance.BorderSize = 0;
            this.btnNavProfiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavProfiles.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnNavProfiles.Location = new System.Drawing.Point(5, 100);
            this.btnNavProfiles.Size = new System.Drawing.Size(190, 45);
            this.btnNavProfiles.Text = "  👥 Profiles";
            this.btnNavProfiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavProfiles.Click += new System.EventHandler(this.BtnNav_Click);

            this.btnNavLogs.FlatAppearance.BorderSize = 0;
            this.btnNavLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavLogs.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnNavLogs.Location = new System.Drawing.Point(5, 150);
            this.btnNavLogs.Size = new System.Drawing.Size(190, 45);
            this.btnNavLogs.Text = "  📜 Logs";
            this.btnNavLogs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavLogs.Click += new System.EventHandler(this.BtnNav_Click);

            // pnlContent
            this.pnlContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlContent.Controls.Add(this.tabContent);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(200, 35);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(900, 715);
            this.pnlContent.Padding = new System.Windows.Forms.Padding(15);

            // tabContent
            this.tabContent.Controls.Add(this.tabSetup);
            this.tabContent.Controls.Add(this.tabProfiles);
            this.tabContent.Controls.Add(this.tabLogs);
            this.tabContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabContent.ItemSize = new System.Drawing.Size(0, 1);
            this.tabContent.Location = new System.Drawing.Point(15, 15);
            this.tabContent.Name = "tabContent";
            this.tabContent.SelectedIndex = 0;
            this.tabContent.Size = new System.Drawing.Size(870, 685);
            this.tabContent.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;

            // tabSetup
            this.tabSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.tabSetup.Controls.Add(this.lblProxies);
            this.tabSetup.Controls.Add(this.txtProxies);
            this.tabSetup.Controls.Add(this.lblUserAgents);
            this.tabSetup.Controls.Add(this.txtUserAgents);
            this.tabSetup.Controls.Add(this.lblTargetUrl);
            this.tabSetup.Controls.Add(this.txtTargetUrl);
            this.tabSetup.Controls.Add(this.btnStart);
            this.tabSetup.Controls.Add(this.btnStop);
            this.tabSetup.Controls.Add(this.groupSettings);
            this.tabSetup.Controls.Add(this.btnLoadProxies);
            this.tabSetup.Controls.Add(this.btnLoadUA);
            this.tabSetup.Location = new System.Drawing.Point(4, 5);
            this.tabSetup.Name = "tabSetup";
            this.tabSetup.Size = new System.Drawing.Size(862, 676);

            this.lblProxies.Location = new System.Drawing.Point(20, 20);
            this.lblProxies.Text = "Proxies (ip:port:user:pass)";
            this.txtProxies.Location = new System.Drawing.Point(20, 40);
            this.txtProxies.Size = new System.Drawing.Size(400, 180);
            this.txtProxies.BorderStyle = System.Windows.Forms.BorderStyle.None;

            this.lblUserAgents.Location = new System.Drawing.Point(440, 20);
            this.lblUserAgents.Text = "User Agents";
            this.txtUserAgents.Location = new System.Drawing.Point(440, 40);
            this.txtUserAgents.Size = new System.Drawing.Size(400, 180);
            this.txtUserAgents.BorderStyle = System.Windows.Forms.BorderStyle.None;

            this.btnLoadProxies.Location = new System.Drawing.Point(20, 225);
            this.btnLoadProxies.Size = new System.Drawing.Size(100, 25);
            this.btnLoadProxies.Text = "Load File";
            this.btnLoadProxies.Click += new System.EventHandler(this.BtnLoadProxies_Click);

            this.btnLoadUA.Location = new System.Drawing.Point(440, 225);
            this.btnLoadUA.Size = new System.Drawing.Size(100, 25);
            this.btnLoadUA.Text = "Load File";
            this.btnLoadUA.Click += new System.EventHandler(this.BtnLoadUA_Click);

            this.lblTargetUrl.Location = new System.Drawing.Point(20, 270);
            this.lblTargetUrl.Text = "Target URL";
            this.txtTargetUrl.Location = new System.Drawing.Point(20, 290);
            this.txtTargetUrl.Size = new System.Drawing.Size(820, 30);

            this.groupSettings.Location = new System.Drawing.Point(20, 330);
            this.groupSettings.Size = new System.Drawing.Size(820, 100);
            this.groupSettings.Text = "Configuration";
            this.chkAutoClean.Location = new System.Drawing.Point(15, 30);
            this.chkAutoClean.Text = "Auto Clean";
            this.chkAutoClean.Checked = true;
            this.chkSaveLogs.Location = new System.Drawing.Point(120, 30);
            this.chkSaveLogs.Text = "Save Logs";
            this.chkSaveLogs.Checked = true;
            this.chkHeadless.Location = new System.Drawing.Point(220, 30);
            this.chkHeadless.Text = "Headless";
            this.lblTimeout.Location = new System.Drawing.Point(15, 65);
            this.lblTimeout.Text = "Timeout (s):";
            this.numTimeout.Location = new System.Drawing.Point(90, 63);
            this.numTimeout.Value = 30;
            this.lblDelay.Location = new System.Drawing.Point(160, 65);
            this.lblDelay.Text = "Delay (s):";
            this.numDelay.Location = new System.Drawing.Point(220, 63);
            this.numDelay.Value = 3;

            this.btnStart.BackColor = System.Drawing.Color.FromArgb(0, 122, 255);
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnStart.Location = new System.Drawing.Point(20, 450);
            this.btnStart.Size = new System.Drawing.Size(250, 50);
            this.btnStart.Text = "START AUTOMATION";
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);

            this.btnStop.BackColor = System.Drawing.Color.FromArgb(255, 59, 48);
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnStop.Location = new System.Drawing.Point(280, 450);
            this.btnStop.Size = new System.Drawing.Size(150, 50);
            this.btnStop.Text = "STOP";
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);

            // tabProfiles
            this.tabProfiles.BackColor = System.Drawing.Color.White;
            this.tabProfiles.Controls.Add(this.dgvProfiles);
            this.tabProfiles.Controls.Add(this.btnOpenProfile);
            this.tabProfiles.Location = new System.Drawing.Point(4, 5);
            this.tabProfiles.Name = "tabProfiles";
            this.tabProfiles.Size = new System.Drawing.Size(862, 676);

            this.dgvProfiles.BackgroundColor = System.Drawing.Color.White;
            this.dgvProfiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProfiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colName, this.colIP, this.colMAC, this.colTimezone, this.colAnonymity
            });
            this.dgvProfiles.Location = new System.Drawing.Point(10, 10);
            this.dgvProfiles.Size = new System.Drawing.Size(840, 600);
            this.colName.HeaderText = "Name";
            this.colIP.HeaderText = "IP";
            this.colMAC.HeaderText = "MAC";
            this.colTimezone.HeaderText = "Timezone";
            this.colAnonymity.HeaderText = "Anonymity";

            this.btnOpenProfile.Location = new System.Drawing.Point(10, 620);
            this.btnOpenProfile.Size = new System.Drawing.Size(150, 40);
            this.btnOpenProfile.Text = "Open Manually";
            this.btnOpenProfile.Click += new System.EventHandler(this.BtnOpenProfile_Click);

            // tabLogs
            this.tabLogs.BackColor = System.Drawing.Color.White;
            this.tabLogs.Controls.Add(this.txtLog);
            this.tabLogs.Controls.Add(this.btnClearLog);
            this.tabLogs.Controls.Add(this.btnExport);
            this.tabLogs.Location = new System.Drawing.Point(4, 5);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Size = new System.Drawing.Size(862, 676);

            this.txtLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            this.txtLog.ForeColor = System.Drawing.Color.White;
            this.txtLog.Location = new System.Drawing.Point(10, 10);
            this.txtLog.Size = new System.Drawing.Size(840, 600);
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;

            this.btnClearLog.Location = new System.Drawing.Point(10, 620);
            this.btnClearLog.Size = new System.Drawing.Size(100, 40);
            this.btnClearLog.Text = "Clear";
            this.btnClearLog.Click += new System.EventHandler(this.BtnClearLog_Click);

            this.btnExport.Location = new System.Drawing.Point(120, 620);
            this.btnExport.Size = new System.Drawing.Size(150, 40);
            this.btnExport.Text = "Export Report";
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);

            // statusStrip
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.progressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 728);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1100, 22);
            this.lblStatus.Size = new System.Drawing.Size(500, 17);
            this.progressBar.Size = new System.Drawing.Size(400, 16);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 750);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CPA MAHIM - Dynamic Session Automation";

            this.pnlBackground.ResumeLayout(false);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlTitleBar.ResumeLayout(false);
            this.pnlTitleBar.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.tabContent.ResumeLayout(false);
            this.tabSetup.ResumeLayout(false);
            this.tabSetup.PerformLayout();
            this.tabProfiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfiles)).EndInit();
            this.tabLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupSettings.ResumeLayout(false);
            this.groupSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnNavSetup;
        private System.Windows.Forms.Button btnNavProfiles;
        private System.Windows.Forms.Button btnNavLogs;
        private System.Windows.Forms.TabControl tabContent;
        private System.Windows.Forms.TabPage tabSetup;
        private System.Windows.Forms.TabPage tabProfiles;
        private System.Windows.Forms.TabPage tabLogs;
        private System.Windows.Forms.RichTextBox txtProxies;
        private System.Windows.Forms.RichTextBox txtUserAgents;
        private System.Windows.Forms.TextBox txtTargetUrl;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.DataGridView dgvProfiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimezone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnonymity;
        private System.Windows.Forms.Button btnOpenProfile;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.Label lblProxies;
        private System.Windows.Forms.Label lblUserAgents;
        private System.Windows.Forms.Label lblTargetUrl;
        private System.Windows.Forms.GroupBox groupSettings;
        private System.Windows.Forms.CheckBox chkAutoClean;
        private System.Windows.Forms.CheckBox chkSaveLogs;
        private System.Windows.Forms.CheckBox chkHeadless;
        private System.Windows.Forms.NumericUpDown numTimeout;
        private System.Windows.Forms.NumericUpDown numDelay;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.Button btnLoadProxies;
        private System.Windows.Forms.Button btnLoadUA;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClearLog;
    }
}
