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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabAutomation = new System.Windows.Forms.TabPage();
            this.txtProxies = new System.Windows.Forms.RichTextBox();
            this.txtUserAgents = new System.Windows.Forms.RichTextBox();
            this.lblProxies = new System.Windows.Forms.Label();
            this.lblUserAgents = new System.Windows.Forms.Label();
            this.btnLoadProxies = new System.Windows.Forms.Button();
            this.btnLoadUA = new System.Windows.Forms.Button();
            this.txtTargetUrl = new System.Windows.Forms.TextBox();
            this.lblTargetUrl = new System.Windows.Forms.Label();
            this.groupSettings = new System.Windows.Forms.GroupBox();
            this.chkHeadless = new System.Windows.Forms.CheckBox();
            this.chkSaveLogs = new System.Windows.Forms.CheckBox();
            this.chkAutoClean = new System.Windows.Forms.CheckBox();
            this.numTimeout = new System.Windows.Forms.NumericUpDown();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.lblDelay = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.tabDashboard = new System.Windows.Forms.TabPage();
            this.dgvProfiles = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnonymity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimezone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOpenProfile = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();

            this.panelHeader.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabAutomation.SuspendLayout();
            this.groupSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            this.tabDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfiles)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(900, 50);
            this.panelHeader.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(320, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dynamic Session Automation";

            // tabControl
            this.tabControl.Controls.Add(this.tabAutomation);
            this.tabControl.Controls.Add(this.tabDashboard);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 50);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(900, 750);
            this.tabControl.TabIndex = 1;

            // tabAutomation
            this.tabAutomation.BackColor = System.Drawing.SystemColors.Control;
            this.tabAutomation.Controls.Add(this.txtProxies);
            this.tabAutomation.Controls.Add(this.txtUserAgents);
            this.tabAutomation.Controls.Add(this.lblProxies);
            this.tabAutomation.Controls.Add(this.lblUserAgents);
            this.tabAutomation.Controls.Add(this.btnLoadProxies);
            this.tabAutomation.Controls.Add(this.btnLoadUA);
            this.tabAutomation.Controls.Add(this.txtTargetUrl);
            this.tabAutomation.Controls.Add(this.lblTargetUrl);
            this.tabAutomation.Controls.Add(this.groupSettings);
            this.tabAutomation.Controls.Add(this.btnStart);
            this.tabAutomation.Controls.Add(this.btnStop);
            this.tabAutomation.Controls.Add(this.btnExport);
            this.tabAutomation.Controls.Add(this.txtLog);
            this.tabAutomation.Controls.Add(this.lblLog);
            this.tabAutomation.Controls.Add(this.btnClearLog);
            this.tabAutomation.Location = new System.Drawing.Point(4, 24);
            this.tabAutomation.Name = "tabAutomation";
            this.tabAutomation.Padding = new System.Windows.Forms.Padding(3);
            this.tabAutomation.Size = new System.Drawing.Size(892, 722);
            this.tabAutomation.TabIndex = 0;
            this.tabAutomation.Text = "Automation Setup";

            // (Controls inside tabAutomation - adjusted positions)
            this.lblProxies.Location = new System.Drawing.Point(10, 10);
            this.txtProxies.Location = new System.Drawing.Point(10, 30);
            this.txtProxies.Size = new System.Drawing.Size(430, 150);
            this.txtProxies.AllowDrop = true;
            this.txtProxies.DragEnter += new System.Windows.Forms.DragEventHandler(this.Txt_DragEnter);
            this.txtProxies.DragDrop += new System.Windows.Forms.DragEventHandler(this.TxtProxies_DragDrop);

            this.lblUserAgents.Location = new System.Drawing.Point(450, 10);
            this.txtUserAgents.Location = new System.Drawing.Point(450, 30);
            this.txtUserAgents.Size = new System.Drawing.Size(430, 150);
            this.txtUserAgents.AllowDrop = true;
            this.txtUserAgents.DragEnter += new System.Windows.Forms.DragEventHandler(this.Txt_DragEnter);
            this.txtUserAgents.DragDrop += new System.Windows.Forms.DragEventHandler(this.TxtUA_DragDrop);

            this.btnLoadProxies.Location = new System.Drawing.Point(10, 185);
            this.btnLoadProxies.Size = new System.Drawing.Size(120, 23);
            this.btnLoadProxies.Text = "📁 Load Proxies";
            this.btnLoadProxies.Click += new System.EventHandler(this.BtnLoadProxies_Click);

            this.btnLoadUA.Location = new System.Drawing.Point(450, 185);
            this.btnLoadUA.Size = new System.Drawing.Size(120, 23);
            this.btnLoadUA.Text = "📁 Load UA";
            this.btnLoadUA.Click += new System.EventHandler(this.BtnLoadUA_Click);

            this.lblTargetUrl.Location = new System.Drawing.Point(10, 220);
            this.txtTargetUrl.Location = new System.Drawing.Point(90, 217);
            this.txtTargetUrl.Size = new System.Drawing.Size(790, 23);
            this.txtTargetUrl.Text = "https://www.google.com";

            this.groupSettings.Location = new System.Drawing.Point(10, 250);
            this.groupSettings.Size = new System.Drawing.Size(870, 70);
            this.chkAutoClean.Location = new System.Drawing.Point(10, 22);
            this.chkSaveLogs.Location = new System.Drawing.Point(170, 22);
            this.chkHeadless.Location = new System.Drawing.Point(270, 22);
            this.lblTimeout.Location = new System.Drawing.Point(10, 47);
            this.numTimeout.Location = new System.Drawing.Point(70, 45);
            this.numTimeout.Value = 30;
            this.lblDelay.Location = new System.Drawing.Point(140, 47);
            this.numDelay.Location = new System.Drawing.Point(185, 45);
            this.numDelay.Value = 3;

            this.btnStart.Location = new System.Drawing.Point(10, 330);
            this.btnStart.Size = new System.Drawing.Size(160, 40);
            this.btnStart.BackColor = System.Drawing.Color.Green;
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Text = "🚀 START AUTOMATION";
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);

            this.btnStop.Location = new System.Drawing.Point(180, 330);
            this.btnStop.Size = new System.Drawing.Size(100, 40);
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Text = "⏹ STOP";
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);

            this.btnExport.Location = new System.Drawing.Point(290, 330);
            this.btnExport.Size = new System.Drawing.Size(150, 40);
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Text = "📊 EXPORT REPORT";
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);

            this.lblLog.Location = new System.Drawing.Point(10, 385);
            this.btnClearLog.Location = new System.Drawing.Point(805, 380);
            this.txtLog.Location = new System.Drawing.Point(10, 405);
            this.txtLog.Size = new System.Drawing.Size(870, 300);
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.ForeColor = System.Drawing.Color.White;

            // tabDashboard
            this.tabDashboard.Controls.Add(this.dgvProfiles);
            this.tabDashboard.Controls.Add(this.btnOpenProfile);
            this.tabDashboard.Location = new System.Drawing.Point(4, 24);
            this.tabDashboard.Name = "tabDashboard";
            this.tabDashboard.Padding = new System.Windows.Forms.Padding(3);
            this.tabDashboard.Size = new System.Drawing.Size(892, 722);
            this.tabDashboard.TabIndex = 1;
            this.tabDashboard.Text = "Profiles Dashboard";

            // dgvProfiles
            this.dgvProfiles.AllowUserToAddRows = false;
            this.dgvProfiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProfiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colIP,
            this.colStatus,
            this.colAnonymity,
            this.colTimezone});
            this.dgvProfiles.Location = new System.Drawing.Point(10, 10);
            this.dgvProfiles.Name = "dgvProfiles";
            this.dgvProfiles.RowTemplate.Height = 25;
            this.dgvProfiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProfiles.Size = new System.Drawing.Size(870, 650);
            this.dgvProfiles.TabIndex = 0;

            this.colName.HeaderText = "Profile Name";
            this.colIP.HeaderText = "Proxy IP";
            this.colStatus.HeaderText = "Status";
            this.colAnonymity.HeaderText = "Anonymity";
            this.colTimezone.HeaderText = "Timezone";

            // btnOpenProfile
            this.btnOpenProfile.Location = new System.Drawing.Point(10, 670);
            this.btnOpenProfile.Name = "btnOpenProfile";
            this.btnOpenProfile.Size = new System.Drawing.Size(150, 40);
            this.btnOpenProfile.TabIndex = 1;
            this.btnOpenProfile.Text = "🌐 OPEN MANUALLY";
            this.btnOpenProfile.UseVisualStyleBackColor = true;
            this.btnOpenProfile.Click += new System.EventHandler(this.BtnOpenProfile_Click);

            // statusStrip
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.progressBar});
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusStrip.Location = new System.Drawing.Point(0, 800);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(900, 22);

            this.lblStatus.Size = new System.Drawing.Size(400, 17);
            this.lblStatus.AutoSize = false;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.progressBar.Size = new System.Drawing.Size(450, 16);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 822);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Dynamic Session Automation - Pro";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabAutomation.ResumeLayout(false);
            this.tabAutomation.PerformLayout();
            this.groupSettings.ResumeLayout(false);
            this.groupSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            this.tabDashboard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfiles)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabAutomation;
        private System.Windows.Forms.TabPage tabDashboard;
        private System.Windows.Forms.RichTextBox txtProxies;
        private System.Windows.Forms.RichTextBox txtUserAgents;
        private System.Windows.Forms.Label lblProxies;
        private System.Windows.Forms.Label lblUserAgents;
        private System.Windows.Forms.Button btnLoadProxies;
        private System.Windows.Forms.Button btnLoadUA;
        private System.Windows.Forms.TextBox txtTargetUrl;
        private System.Windows.Forms.Label lblTargetUrl;
        private System.Windows.Forms.GroupBox groupSettings;
        private System.Windows.Forms.CheckBox chkHeadless;
        private System.Windows.Forms.CheckBox chkSaveLogs;
        private System.Windows.Forms.CheckBox chkAutoClean;
        private System.Windows.Forms.NumericUpDown numTimeout;
        private System.Windows.Forms.NumericUpDown numDelay;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.DataGridView dgvProfiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnonymity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimezone;
        private System.Windows.Forms.Button btnOpenProfile;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
    }
}
