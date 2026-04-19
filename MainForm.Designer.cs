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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.panelHeader.SuspendLayout();
            this.groupSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(800, 50);
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

            // lblProxies
            this.lblProxies.AutoSize = true;
            this.lblProxies.Location = new System.Drawing.Point(12, 63);
            this.lblProxies.Name = "lblProxies";
            this.lblProxies.Size = new System.Drawing.Size(144, 15);
            this.lblProxies.Text = "PROXIES (ip:port:user:pass)";

            // txtProxies
            this.txtProxies.Location = new System.Drawing.Point(12, 81);
            this.txtProxies.Name = "txtProxies";
            this.txtProxies.Size = new System.Drawing.Size(380, 150);
            this.txtProxies.TabIndex = 1;
            this.txtProxies.Text = "";
            this.txtProxies.AllowDrop = true;
            this.txtProxies.DragEnter += new System.Windows.Forms.DragEventHandler(this.Txt_DragEnter);
            this.txtProxies.DragDrop += new System.Windows.Forms.DragEventHandler(this.TxtProxies_DragDrop);

            // lblUserAgents
            this.lblUserAgents.AutoSize = true;
            this.lblUserAgents.Location = new System.Drawing.Point(408, 63);
            this.lblUserAgents.Name = "lblUserAgents";
            this.lblUserAgents.Size = new System.Drawing.Size(82, 15);
            this.lblUserAgents.Text = "USER AGENTS";

            // txtUserAgents
            this.txtUserAgents.Location = new System.Drawing.Point(408, 81);
            this.txtUserAgents.Name = "txtUserAgents";
            this.txtUserAgents.Size = new System.Drawing.Size(380, 150);
            this.txtUserAgents.TabIndex = 2;
            this.txtUserAgents.Text = "";
            this.txtUserAgents.AllowDrop = true;
            this.txtUserAgents.DragEnter += new System.Windows.Forms.DragEventHandler(this.Txt_DragEnter);
            this.txtUserAgents.DragDrop += new System.Windows.Forms.DragEventHandler(this.TxtUA_DragDrop);

            // btnLoadProxies
            this.btnLoadProxies.Location = new System.Drawing.Point(12, 237);
            this.btnLoadProxies.Name = "btnLoadProxies";
            this.btnLoadProxies.Size = new System.Drawing.Size(120, 23);
            this.btnLoadProxies.TabIndex = 3;
            this.btnLoadProxies.Text = "📁 Load Proxies";
            this.btnLoadProxies.Click += new System.EventHandler(this.BtnLoadProxies_Click);

            // btnLoadUA
            this.btnLoadUA.Location = new System.Drawing.Point(408, 237);
            this.btnLoadUA.Name = "btnLoadUA";
            this.btnLoadUA.Size = new System.Drawing.Size(120, 23);
            this.btnLoadUA.TabIndex = 4;
            this.btnLoadUA.Text = "📁 Load UA";
            this.btnLoadUA.Click += new System.EventHandler(this.BtnLoadUA_Click);

            // lblTargetUrl
            this.lblTargetUrl.AutoSize = true;
            this.lblTargetUrl.Location = new System.Drawing.Point(12, 275);
            this.lblTargetUrl.Name = "lblTargetUrl";
            this.lblTargetUrl.Size = new System.Drawing.Size(75, 15);
            this.lblTargetUrl.Text = "TARGET URL:";

            // txtTargetUrl
            this.txtTargetUrl.Location = new System.Drawing.Point(90, 272);
            this.txtTargetUrl.Name = "txtTargetUrl";
            this.txtTargetUrl.Size = new System.Drawing.Size(698, 23);
            this.txtTargetUrl.TabIndex = 5;
            this.txtTargetUrl.Text = "https://www.google.com";

            // groupSettings
            this.groupSettings.Controls.Add(this.chkHeadless);
            this.groupSettings.Controls.Add(this.chkSaveLogs);
            this.groupSettings.Controls.Add(this.chkAutoClean);
            this.groupSettings.Controls.Add(this.numTimeout);
            this.groupSettings.Controls.Add(this.numDelay);
            this.groupSettings.Controls.Add(this.lblTimeout);
            this.groupSettings.Controls.Add(this.lblDelay);
            this.groupSettings.Location = new System.Drawing.Point(12, 310);
            this.groupSettings.Name = "groupSettings";
            this.groupSettings.Size = new System.Drawing.Size(776, 70);
            this.groupSettings.TabIndex = 6;
            this.groupSettings.TabStop = false;
            this.groupSettings.Text = "SETTINGS";

            // chkAutoClean
            this.chkAutoClean.AutoSize = true;
            this.chkAutoClean.Checked = true;
            this.chkAutoClean.Location = new System.Drawing.Point(10, 22);
            this.chkAutoClean.Name = "chkAutoClean";
            this.chkAutoClean.Size = new System.Drawing.Size(148, 19);
            this.chkAutoClean.Text = "☑ Auto-clean temp files";

            // chkSaveLogs
            this.chkSaveLogs.AutoSize = true;
            this.chkSaveLogs.Checked = true;
            this.chkSaveLogs.Location = new System.Drawing.Point(164, 22);
            this.chkSaveLogs.Name = "chkSaveLogs";
            this.chkSaveLogs.Size = new System.Drawing.Size(89, 19);
            this.chkSaveLogs.Text = "☑ Save logs";

            // chkHeadless
            this.chkHeadless.AutoSize = true;
            this.chkHeadless.Location = new System.Drawing.Point(259, 22);
            this.chkHeadless.Name = "chkHeadless";
            this.chkHeadless.Size = new System.Drawing.Size(117, 19);
            this.chkHeadless.Text = "☐ Headless mode";

            // lblTimeout
            this.lblTimeout.AutoSize = true;
            this.lblTimeout.Location = new System.Drawing.Point(10, 47);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(54, 15);
            this.lblTimeout.Text = "Timeout:";

            // numTimeout
            this.numTimeout.Location = new System.Drawing.Point(70, 45);
            this.numTimeout.Name = "numTimeout";
            this.numTimeout.Size = new System.Drawing.Size(50, 23);
            this.numTimeout.Value = new decimal(new int[] { 30, 0, 0, 0 });

            // lblDelay
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(140, 47);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(39, 15);
            this.lblDelay.Text = "Delay:";

            // numDelay
            this.numDelay.Location = new System.Drawing.Point(185, 45);
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(50, 23);
            this.numDelay.Value = new decimal(new int[] { 3, 0, 0, 0 });

            // btnStart
            this.btnStart.BackColor = System.Drawing.Color.Green;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(12, 395);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(150, 40);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "🚀 START AUTOMATION";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);

            // btnStop
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(168, 395);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 40);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "⏹ STOP";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);

            // btnExport
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(274, 395);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 40);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "📊 EXPORT REPORT";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);

            // lblLog
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(12, 450);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(54, 15);
            this.lblLog.Text = "LIVE LOG";

            // btnClearLog
            this.btnClearLog.Location = new System.Drawing.Point(713, 446);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 10;
            this.btnClearLog.Text = "[CLEAR]";
            this.btnClearLog.Click += new System.EventHandler(this.BtnClearLog_Click);

            // txtLog
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.ForeColor = System.Drawing.Color.White;
            this.txtLog.Location = new System.Drawing.Point(12, 470);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(776, 200);
            this.txtLog.TabIndex = 11;
            this.txtLog.Text = "";

            // statusStrip
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.progressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 680);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 12;

            // lblStatus
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(300, 17);
            this.lblStatus.Text = "Ready";
            this.lblStatus.AutoSize = false;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // progressBar
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(400, 16);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 702);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupSettings);
            this.Controls.Add(this.txtTargetUrl);
            this.Controls.Add(this.lblTargetUrl);
            this.Controls.Add(this.btnLoadUA);
            this.Controls.Add(this.btnLoadProxies);
            this.Controls.Add(this.txtUserAgents);
            this.Controls.Add(this.lblUserAgents);
            this.Controls.Add(this.txtProxies);
            this.Controls.Add(this.lblProxies);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Dynamic Session Automation";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.groupSettings.ResumeLayout(false);
            this.groupSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
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
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
    }
}
