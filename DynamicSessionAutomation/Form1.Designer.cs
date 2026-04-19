namespace DynamicSessionAutomation
{
    partial class Form1
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

        private void InitializeComponent()
        {
            this.labelProxies = new System.Windows.Forms.Label();
            this.txtProxies = new System.Windows.Forms.TextBox();
            this.labelUAs = new System.Windows.Forms.Label();
            this.txtUAs = new System.Windows.Forms.TextBox();
            this.labelTarget = new System.Windows.Forms.Label();
            this.txtTargetUrl = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.rtbLogs = new System.Windows.Forms.RichTextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // labelProxies
            this.labelProxies.Location = new System.Drawing.Point(12, 9);
            this.labelProxies.Name = "labelProxies";
            this.labelProxies.Size = new System.Drawing.Size(150, 23);
            this.labelProxies.Text = "Proxies (ip:port:user:pass):";

            // txtProxies
            this.txtProxies.Location = new System.Drawing.Point(12, 35);
            this.txtProxies.Multiline = true;
            this.txtProxies.Name = "txtProxies";
            this.txtProxies.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProxies.Size = new System.Drawing.Size(380, 100);

            // labelUAs
            this.labelUAs.Location = new System.Drawing.Point(408, 9);
            this.labelUAs.Name = "labelUAs";
            this.labelUAs.Size = new System.Drawing.Size(150, 23);
            this.labelUAs.Text = "User Agents:";

            // txtUAs
            this.txtUAs.Location = new System.Drawing.Point(408, 35);
            this.txtUAs.Multiline = true;
            this.txtUAs.Name = "txtUAs";
            this.txtUAs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUAs.Size = new System.Drawing.Size(380, 100);

            // labelTarget
            this.labelTarget.Location = new System.Drawing.Point(12, 145);
            this.labelTarget.Name = "labelTarget";
            this.labelTarget.Size = new System.Drawing.Size(100, 23);
            this.labelTarget.Text = "Target URL:";

            // txtTargetUrl
            this.txtTargetUrl.Location = new System.Drawing.Point(12, 171);
            this.txtTargetUrl.Name = "txtTargetUrl";
            this.txtTargetUrl.Size = new System.Drawing.Size(776, 23);
            this.txtTargetUrl.Text = "https://www.google.com";

            // btnStart
            this.btnStart.Location = new System.Drawing.Point(12, 210);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 35);
            this.btnStart.Text = "Start Automation";
            this.btnStart.BackColor = System.Drawing.Color.LightBlue;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);

            // btnStop
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(118, 210);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 35);
            this.btnStop.Text = "Stop";
            this.btnStop.BackColor = System.Drawing.Color.LightPink;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);

            // btnExport
            this.btnExport.Location = new System.Drawing.Point(688, 210);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 35);
            this.btnExport.Text = "Export CSV";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

            // progressBar
            this.progressBar.Location = new System.Drawing.Point(12, 260);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(776, 23);

            // rtbLogs
            this.rtbLogs.Location = new System.Drawing.Point(12, 300);
            this.rtbLogs.Name = "rtbLogs";
            this.rtbLogs.ReadOnly = true;
            this.rtbLogs.Size = new System.Drawing.Size(776, 248);
            this.rtbLogs.Text = "";

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 560);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 15);
            this.lblStatus.Text = "Ready";

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 590);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.rtbLogs);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtTargetUrl);
            this.Controls.Add(this.labelTarget);
            this.Controls.Add(this.txtUAs);
            this.Controls.Add(this.labelUAs);
            this.Controls.Add(this.txtProxies);
            this.Controls.Add(this.labelProxies);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Dynamic Session Automation";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label labelProxies;
        private System.Windows.Forms.TextBox txtProxies;
        private System.Windows.Forms.Label labelUAs;
        private System.Windows.Forms.TextBox txtUAs;
        private System.Windows.Forms.Label labelTarget;
        private System.Windows.Forms.TextBox txtTargetUrl;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.RichTextBox rtbLogs;
        private System.Windows.Forms.Label lblStatus;
    }
}
