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
            WebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            TrayIcon = new NotifyIcon(components);
            TrayMenuStrip = new ContextMenuStrip(components);
            показатьСкаМToolStripMenuItem = new ToolStripMenuItem();
            закрытьСкаМToolStripMenuItem = new ToolStripMenuItem();
            MAXStartWatcher = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)WebView).BeginInit();
            TrayMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // WebView
            // 
            WebView.AllowExternalDrop = true;
            WebView.CreationProperties = null;
            WebView.DefaultBackgroundColor = Color.Transparent;
            WebView.Dock = DockStyle.Fill;
            WebView.Location = new Point(0, 0);
            WebView.Name = "WebView";
            WebView.Size = new Size(375, 541);
            WebView.Source = new Uri("https://vlados63k.github.io/scaM-forPC-ui/main.html", UriKind.Absolute);
            WebView.TabIndex = 0;
            WebView.ZoomFactor = 1D;
            WebView.CoreWebView2InitializationCompleted += webView21_CoreWebView2InitializationCompleted;
            WebView.NavigationCompleted += webView21_NavigationCompleted;
            WebView.WebMessageReceived += webView21_WebMessageReceived;
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
            Controls.Add(WebView);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "скаМ";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)WebView).EndInit();
            TrayMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 WebView;
        private NotifyIcon TrayIcon;
        private ContextMenuStrip TrayMenuStrip;
        private ToolStripMenuItem показатьСкаМToolStripMenuItem;
        private ToolStripMenuItem закрытьСкаМToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker MAXStartWatcher;
    }
}
