using Newtonsoft.Json;
using System.Diagnostics;
using VladOSLauncher;

namespace scaM_forPC
{
    public partial class MainForm : Form
    {
        public MainForm(string[] args)
        {
            Process[] processes = Process.GetProcessesByName("scaM-forPC");
            foreach (Process process in processes)
            {
                if (process.Id != Process.GetCurrentProcess().Id)
                {
                    MessageBox.Show("скаћ уже открыт. ѕожалуйста, используйте другое окно.");
                    Environment.Exit(1);
                    return;
                }
            }
            InitializeComponent();
            WinBlur.UI.SetBlurStyle(this, WinBlur.UI.BlurType.Acrylic, WinBlur.UI.Mode.DarkMode, true);
            if (args != null && args.Length != 0)
            {
                if (args[0] == "-autorun")
                {
                    this.Hide();
                }
            }

        }

        bool isRunning = false;

        void StateRefresh()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(StateRefresh));
                return;
            }
            WebView2Message msg = new WebView2Message("state", isRunning);
            WebView.CoreWebView2.PostWebMessageAsJson(JsonConvert.SerializeObject(msg));
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            isRunning = Properties.Settings.Default.IsRunning;
            WebView.EnsureCoreWebView2Async();// await CoreWebView2Environment.CreateAsync(Application.StartupPath + "\\BrowserExec", Application.StartupPath + "\\BrowserData"));
        }

        private async void webView21_WebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            try
            {
                Debug.WriteLine("WebView2 message received: " + e.WebMessageAsJson);
                WebView2Message msg = JsonConvert.DeserializeObject<WebView2Message>(e.WebMessageAsJson);
                Debug.WriteLine("WebView2 message received: " + msg.Key + " - " + msg.Value);
                switch (msg.Key)
                {
                    case "button_click":
                        isRunning = !isRunning;
                        StateRefresh();
                        Properties.Settings.Default.IsRunning = isRunning;
                        Properties.Settings.Default.Save();
                        MessageBox.Show("OK, скаћ " + (isRunning ? "включен!" : "отключен!"), "скаћ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "settings":
                        new SettingsForm().ShowDialog();
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error processing WebView2 message: " + ex.ToString());
            }
        }

        private void webView21_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            if (!e.IsSuccess)
            {
                MessageBox.Show(e.InitializationException.ToString() + "\nApplication will be exit.",
                    "WebView2 Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
                return;
            }
            MAXStartWatcher.RunWorkerAsync();
            //webView21.CoreWebView2.Settings.AreDevToolsEnabled = false;
            WebView.CoreWebView2.Settings.IsBuiltInErrorPageEnabled = false;
            WebView.CoreWebView2.Settings.IsPasswordAutosaveEnabled = false;
        }

        private void показать—каћToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                TrayIcon.ShowBalloonTip(3, "скаћ", "скаћ работает в фоновом режиме!", ToolTipIcon.Info);
            }
        }

        private void закрыть—каћToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                DialogResult msg = MessageBox.Show("скаћ сейчас включен! ’отите выйти?", "скаћ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.No) return;
            }
            isRunning = false;
            Application.Exit();
        }

        private async void MAXStartWatcher_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Debug.WriteLine("Work!");
            while (true)
            {
                if (isRunning)
                {
                    Process[] procs = Process.GetProcessesByName("max");
                    Process[] procs1 = Process.GetProcessesByName("max-service");
                    if (procs.Length != 0)
                    {
                        foreach (Process p in procs)
                        {
                            try
                            {
                                p.Kill();
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(ex.Message);
                            }
                        }
                    }
                    if (procs1.Length != 0)
                    {
                        foreach (Process p in procs1)
                        {
                            try
                            {
                                p.Kill();
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(ex.Message);
                            }
                        }
                    }
                    if (procs.Length != 0 || procs1.Length != 0)
                    {
                        MessageBox.Show("Ќевозможно запустить MAX, так как отсутствует файл msvcp140.dll. ѕопробуйте переустановить MAX.", "max.exe", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    }
                }
                await Task.Delay(1000);
            }
        }

        private void webView21_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            StateRefresh();
        }
    }
}
