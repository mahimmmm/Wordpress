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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblAppName = new System.Windows.Forms.Label();
            this.btnNavSetup = new System.Windows.Forms.Button();
            this.btnNavProfiles = new System.Windows.Forms.Button();
            this.btnNavLogs = new System.Windows.Forms.Button();
            this.lblSupport = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tabContent = new System.Windows.Forms.TabControl();
            this.tabSetup = new System.Windows.Forms.TabPage();
            this.tabProfiles = new System.Windows.Forms.TabPage();
            this.tabLogs = new System.Windows.Forms.TabPage();

            // Setup Tab Controls
            this.lblProxies = new System.Windows.Forms.Label();
            this.txtProxies = new System.Windows.Forms.RichTextBox();
            this.lblUserAgents = new System.Windows.Forms.Label();
            this.txtUserAgents = new System.Windows.Forms.RichTextBox();
            this.btnLoadProxies = new System.Windows.Forms.Button();
            this.btnLoadUA = new System.Windows.Forms.Button();
            this.lblTargetUrl = new System.Windows.Forms.Label();
            this.txtTargetUrl = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupSettings = new System.Windows.Forms.GroupBox();
            this.chkAutoClean = new System.Windows.Forms.CheckBox();
            this.chkSaveLogs = new System.Windows.Forms.CheckBox();
            this.chkHeadless = new System.Windows.Forms.CheckBox();
            this.numTimeout = new System.Windows.Forms.NumericUpDown();
            this.numDelay = new System.Windows.Forms.NumericUpDown();

            // Profile Tab Controls
            this.dgvProfiles = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimezone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnonymity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOpenProfile = new System.Windows.Forms.Button();

            // Log Tab Controls
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();

            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();

            this.pnlSidebar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.tabContent.SuspendLayout();
            this.tabSetup.SuspendLayout();
            this.tabProfiles.SuspendLayout();
            this.tabLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfiles)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // pnlSidebar
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(92)))), ((int)(((byte)(246))))); // Purple color from image
            this.pnlSidebar.Controls.Add(this.lblAppName);
            this.pnlSidebar.Controls.Add(this.btnNavSetup);
            this.pnlSidebar.Controls.Add(this.btnNavProfiles);
            this.pnlSidebar.Controls.Add(this.btnNavLogs);
            this.pnlSidebar.Controls.Add(this.lblSupport);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(220, 750);
            this.pnlSidebar.TabIndex = 0;

            // lblAppName
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAppName.ForeColor = System.Drawing.Color.Black;
            this.lblAppName.Location = new System.Drawing.Point(20, 30);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(150, 32);
            this.lblAppName.Text = "CPA MAHIM";

            // btnNavSetup
            this.btnNavSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68))))); // Red/Orange from image
            this.btnNavSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSetup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnNavSetup.ForeColor = System.Drawing.Color.Black;
            this.btnNavSetup.Location = new System.Drawing.Point(10, 100);
            this.btnNavSetup.Name = "btnNavSetup";
            this.btnNavSetup.Size = new System.Drawing.Size(200, 60);
            this.btnNavSetup.Text = "Automation\r\nSetup";
            this.btnNavSetup.UseVisualStyleBackColor = false;
            this.btnNavSetup.Click += new System.EventHandler(this.BtnNav_Click);

            // btnNavProfiles
            this.btnNavProfiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnNavProfiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavProfiles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnNavProfiles.ForeColor = System.Drawing.Color.Black;
            this.btnNavProfiles.Location = new System.Drawing.Point(10, 200);
            this.btnNavProfiles.Name = "btnNavProfiles";
            this.btnNavProfiles.Size = new System.Drawing.Size(200, 60);
            this.btnNavProfiles.Text = "Profile List";
            this.btnNavProfiles.UseVisualStyleBackColor = false;
            this.btnNavProfiles.Click += new System.EventHandler(this.BtnNav_Click);

            // btnNavLogs
            this.btnNavLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnNavLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavLogs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnNavLogs.ForeColor = System.Drawing.Color.Black;
            this.btnNavLogs.Location = new System.Drawing.Point(10, 300);
            this.btnNavLogs.Name = "btnNavLogs";
            this.btnNavLogs.Size = new System.Drawing.Size(200, 60);
            this.btnNavLogs.Text = "Show Log";
            this.btnNavLogs.UseVisualStyleBackColor = false;
            this.btnNavLogs.Click += new System.EventHandler(this.BtnNav_Click);

            // lblSupport
            this.lblSupport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSupport.AutoSize = true;
            this.lblSupport.ForeColor = System.Drawing.Color.Black;
            this.lblSupport.Location = new System.Drawing.Point(10, 715);
            this.lblSupport.Name = "lblSupport";
            this.lblSupport.Size = new System.Drawing.Size(104, 15);
            this.lblSupport.Text = "Contact & Support";

            // pnlMain
            this.pnlMain.Controls.Add(this.tabContent);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(220, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(780, 750);
            this.pnlMain.TabIndex = 1;

            // tabContent
            this.tabContent.Controls.Add(this.tabSetup);
            this.tabContent.Controls.Add(this.tabProfiles);
            this.tabContent.Controls.Add(this.tabLogs);
            this.tabContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabContent.ItemSize = new System.Drawing.Size(0, 1); // Hide tab headers
            this.tabContent.Location = new System.Drawing.Point(0, 0);
            this.tabContent.Name = "tabContent";
            this.tabContent.SelectedIndex = 0;
            this.tabContent.Size = new System.Drawing.Size(780, 750);
            this.tabContent.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabContent.TabIndex = 0;

            // tabSetup
            this.tabSetup.BackColor = System.Drawing.Color.White;
            this.tabSetup.Controls.Add(this.lblProxies);
            this.tabSetup.Controls.Add(this.txtProxies);
            this.tabSetup.Controls.Add(this.lblUserAgents);
            this.tabSetup.Controls.Add(this.txtUserAgents);
            this.tabSetup.Controls.Add(this.btnLoadProxies);
            this.tabSetup.Controls.Add(this.btnLoadUA);
            this.tabSetup.Controls.Add(this.lblTargetUrl);
            this.tabSetup.Controls.Add(this.txtTargetUrl);
            this.tabSetup.Controls.Add(this.btnStart);
            this.tabSetup.Controls.Add(this.btnStop);
            this.tabSetup.Controls.Add(this.groupSettings);
            this.tabSetup.Location = new System.Drawing.Point(4, 5);
            this.tabSetup.Name = "tabSetup";
            this.tabSetup.Size = new System.Drawing.Size(772, 741);
            this.tabSetup.Text = "Setup";

            this.lblProxies.Location = new System.Drawing.Point(20, 20);
            this.lblProxies.Text = "Proxies Load (ip:port:user:pass)";
            this.txtProxies.Location = new System.Drawing.Point(20, 40);
            this.txtProxies.Size = new System.Drawing.Size(350, 200);
            this.txtProxies.AllowDrop = true;

            this.lblUserAgents.Location = new System.Drawing.Point(400, 20);
            this.lblUserAgents.Text = "UA Load";
            this.txtUserAgents.Location = new System.Drawing.Point(400, 40);
            this.txtUserAgents.Size = new System.Drawing.Size(350, 200);
            this.txtUserAgents.AllowDrop = true;

            this.btnLoadProxies.Location = new System.Drawing.Point(20, 245);
            this.btnLoadProxies.Size = new System.Drawing.Size(120, 30);
            this.btnLoadProxies.Text = "📁 Load Proxies";
            this.btnLoadProxies.Click += new System.EventHandler(this.BtnLoadProxies_Click);

            this.btnLoadUA.Location = new System.Drawing.Point(400, 245);
            this.btnLoadUA.Size = new System.Drawing.Size(120, 30);
            this.btnLoadUA.Text = "📁 Load UA";
            this.btnLoadUA.Click += new System.EventHandler(this.BtnLoadUA_Click);

            this.lblTargetUrl.Location = new System.Drawing.Point(20, 300);
            this.lblTargetUrl.Text = "link set (Target URL):";
            this.txtTargetUrl.Location = new System.Drawing.Point(20, 320);
            this.txtTargetUrl.Size = new System.Drawing.Size(730, 23);

            this.groupSettings.Location = new System.Drawing.Point(20, 360);
            this.groupSettings.Size = new System.Drawing.Size(730, 100);
            this.groupSettings.Text = "Settings";
            this.chkAutoClean.Location = new System.Drawing.Point(10, 30);
            this.chkAutoClean.Text = "Auto-clean temp files";
            this.chkAutoClean.Checked = true;
            this.chkSaveLogs.Location = new System.Drawing.Point(180, 30);
            this.chkSaveLogs.Text = "Save logs";
            this.chkSaveLogs.Checked = true;
            this.chkHeadless.Location = new System.Drawing.Point(280, 30);
            this.chkHeadless.Text = "Headless mode";

            this.btnStart.Location = new System.Drawing.Point(20, 480);
            this.btnStart.Size = new System.Drawing.Size(200, 50);
            this.btnStart.BackColor = System.Drawing.Color.Green;
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnStart.Text = "START AUTOMATION";
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);

            this.btnStop.Location = new System.Drawing.Point(240, 480);
            this.btnStop.Size = new System.Drawing.Size(150, 50);
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnStop.Text = "STOP";
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);

            // tabProfiles
            this.tabProfiles.BackColor = System.Drawing.Color.White;
            this.tabProfiles.Controls.Add(this.dgvProfiles);
            this.tabProfiles.Controls.Add(this.btnOpenProfile);
            this.tabProfiles.Location = new System.Drawing.Point(4, 5);
            this.tabProfiles.Name = "tabProfiles";
            this.tabProfiles.Size = new System.Drawing.Size(772, 741);
            this.tabProfiles.Text = "Profiles";

            this.dgvProfiles.Location = new System.Drawing.Point(10, 10);
            this.dgvProfiles.Size = new System.Drawing.Size(750, 650);
            this.dgvProfiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colName, this.colIP, this.colMAC, this.colTimezone, this.colAnonymity
            });
            this.colName.HeaderText = "Profile Name";
            this.colIP.HeaderText = "Proxy IP";
            this.colMAC.HeaderText = "MAC Address";
            this.colTimezone.HeaderText = "Timezone";
            this.colAnonymity.HeaderText = "Anonymity %";

            this.btnOpenProfile.Location = new System.Drawing.Point(10, 670);
            this.btnOpenProfile.Size = new System.Drawing.Size(200, 40);
            this.btnOpenProfile.Text = "🌐 OPEN MANUALLY";
            this.btnOpenProfile.Click += new System.EventHandler(this.BtnOpenProfile_Click);

            // tabLogs
            this.tabLogs.BackColor = System.Drawing.Color.White;
            this.tabLogs.Controls.Add(this.txtLog);
            this.tabLogs.Controls.Add(this.btnClearLog);
            this.tabLogs.Controls.Add(this.btnExport);
            this.tabLogs.Location = new System.Drawing.Point(4, 5);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Size = new System.Drawing.Size(772, 741);
            this.tabLogs.Text = "Logs";

            this.txtLog.Location = new System.Drawing.Point(10, 10);
            this.txtLog.Size = new System.Drawing.Size(750, 650);
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.ForeColor = System.Drawing.Color.White;

            this.btnClearLog.Location = new System.Drawing.Point(10, 670);
            this.btnClearLog.Size = new System.Drawing.Size(100, 40);
            this.btnClearLog.Text = "Clear";
            this.btnClearLog.Click += new System.EventHandler(this.BtnClearLog_Click);

            this.btnExport.Location = new System.Drawing.Point(120, 670);
            this.btnExport.Size = new System.Drawing.Size(150, 40);
            this.btnExport.Text = "Export Report";
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);

            // statusStrip
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.progressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 728);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1000, 22);
            this.lblStatus.Size = new System.Drawing.Size(400, 17);
            this.lblStatus.AutoSize = false;
            this.progressBar.Size = new System.Drawing.Size(450, 16);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 750);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.statusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "CPA MAHIM - Dynamic Session Automation";
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlMain.ResumeLayout(false);
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
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Button btnNavSetup;
        private System.Windows.Forms.Button btnNavProfiles;
        private System.Windows.Forms.Button btnNavLogs;
        private System.Windows.Forms.Label lblSupport;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TabControl tabContent;
        private System.Windows.Forms.TabPage tabSetup;
        private System.Windows.Forms.TabPage tabProfiles;
        private System.Windows.Forms.TabPage tabLogs;

        private System.Windows.Forms.Label lblProxies;
        private System.Windows.Forms.RichTextBox txtProxies;
        private System.Windows.Forms.Label lblUserAgents;
        private System.Windows.Forms.RichTextBox txtUserAgents;
        private System.Windows.Forms.Button btnLoadProxies;
        private System.Windows.Forms.Button btnLoadUA;
        private System.Windows.Forms.Label lblTargetUrl;
        private System.Windows.Forms.TextBox txtTargetUrl;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox groupSettings;
        private System.Windows.Forms.CheckBox chkAutoClean;
        private System.Windows.Forms.CheckBox chkSaveLogs;
        private System.Windows.Forms.CheckBox chkHeadless;
        private System.Windows.Forms.NumericUpDown numTimeout;
        private System.Windows.Forms.NumericUpDown numDelay;

        private System.Windows.Forms.DataGridView dgvProfiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimezone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnonymity;
        private System.Windows.Forms.Button btnOpenProfile;

        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnExport;

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
    }
}
