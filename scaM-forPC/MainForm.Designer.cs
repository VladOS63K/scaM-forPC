namespace scaM_forPC
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            HTTPServer = new System.ComponentModel.BackgroundWorker();
            TrayIcon = new NotifyIcon(components);
            TrayMenuStrip = new ContextMenuStrip(components);
            показатьСкаМToolStripMenuItem = new ToolStripMenuItem();
            закрытьСкаМToolStripMenuItem = new ToolStripMenuItem();
            MAXStartWatcher = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            TrayMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.Transparent;
            webView21.Dock = DockStyle.Fill;
            webView21.Location = new Point(0, 0);
            webView21.Name = "webView21";
            webView21.Size = new Size(375, 541);
            webView21.Source = new Uri("http://127.0.0.1:9378/files/main.html", UriKind.Absolute);
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            webView21.CoreWebView2InitializationCompleted += webView21_CoreWebView2InitializationCompleted;
            webView21.NavigationCompleted += webView21_NavigationCompleted;
            webView21.WebMessageReceived += webView21_WebMessageReceived;
            // 
            // HTTPServer
            // 
            HTTPServer.WorkerSupportsCancellation = true;
            HTTPServer.DoWork += backgroundWorker1_DoWork;
            // 
            // TrayIcon
            // 
            TrayIcon.ContextMenuStrip = TrayMenuStrip;
            TrayIcon.Icon = (Icon)resources.GetObject("TrayIcon.Icon");
            TrayIcon.Text = "скаМ";
            TrayIcon.Visible = true;
            // 
            // TrayMenuStrip
            // 
            TrayMenuStrip.Items.AddRange(new ToolStripItem[] { показатьСкаМToolStripMenuItem, закрытьСкаМToolStripMenuItem });
            TrayMenuStrip.Name = "contextMenuStrip1";
            TrayMenuStrip.Size = new Size(157, 48);
            // 
            // показатьСкаМToolStripMenuItem
            // 
            показатьСкаМToolStripMenuItem.Name = "показатьСкаМToolStripMenuItem";
            показатьСкаМToolStripMenuItem.Size = new Size(156, 22);
            показатьСкаМToolStripMenuItem.Text = "Показать скаМ";
            показатьСкаМToolStripMenuItem.Click += показатьСкаМToolStripMenuItem_Click;
            // 
            // закрытьСкаМToolStripMenuItem
            // 
            закрытьСкаМToolStripMenuItem.Name = "закрытьСкаМToolStripMenuItem";
            закрытьСкаМToolStripMenuItem.Size = new Size(156, 22);
            закрытьСкаМToolStripMenuItem.Text = "Закрыть скаМ";
            закрытьСкаМToolStripMenuItem.Click += закрытьСкаМToolStripMenuItem_Click;
            // 
            // MAXStartWatcher
            // 
            MAXStartWatcher.DoWork += MAXStartWatcher_DoWork;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(375, 541);
            Controls.Add(webView21);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "скаМ";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            TrayMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.ComponentModel.BackgroundWorker HTTPServer;
        private NotifyIcon TrayIcon;
        private ContextMenuStrip TrayMenuStrip;
        private ToolStripMenuItem показатьСкаМToolStripMenuItem;
        private ToolStripMenuItem закрытьСкаМToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker MAXStartWatcher;
    }
}
