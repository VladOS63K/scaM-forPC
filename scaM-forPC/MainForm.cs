using HtmlAgilityPack;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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

        HttpListener server;

        bool isRunning = false;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0005)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.Hide();
                }
            }

            base.WndProc(ref m);
        }

        void StateRefresh()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(StateRefresh));
                return;
            }
            WebView2Message msg = new WebView2Message("state", isRunning);
            webView21.CoreWebView2.PostWebMessageAsJson(JsonConvert.SerializeObject(msg));
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            server = new HttpListener();
            server.Prefixes.Add("http://127.0.0.1:9378/files/");

            server.Start();

            isRunning = Properties.Settings.Default.IsRunning;

            HTTPServer.RunWorkerAsync();
            

            webView21.EnsureCoreWebView2Async();// await CoreWebView2Environment.CreateAsync(Application.StartupPath + "\\BrowserExec", Application.StartupPath + "\\BrowserData"));
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
            webView21.CoreWebView2.Settings.IsBuiltInErrorPageEnabled = false;
            webView21.CoreWebView2.Settings.IsPasswordAutosaveEnabled = false;
        }

        private async void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                HttpListenerContext context = await server.GetContextAsync();

                var request = context.Request;
                var response = context.Response;
                var userAgent = request.UserAgent;
                try
                {
                    response.ContentEncoding = Encoding.UTF8;
                    if (request.RawUrl.StartsWith("/files/"))
                    {
                        string filePath = "files\\" + request.RawUrl.Substring(1).Replace("files/", "").Replace('/', '\\');
                        Debug.Write($"Sending file {filePath}... ");
                        if (File.Exists(filePath))
                        {
                            response.StatusCode = 200;
                            byte[] respBytes = File.ReadAllBytes(filePath);
                            response.ContentLength64 = respBytes.Length;
                            await response.OutputStream.WriteAsync(respBytes, 0, respBytes.Length);
                            await response.OutputStream.FlushAsync();
                            Debug.WriteLine("done");
                        }
                        else
                        {
                            response.StatusCode = 404;
                            byte[] respBytes = new byte[2048];
                            respBytes = Encoding.UTF8.GetBytes("404 Not Found");
                            response.ContentLength64 = respBytes.Length;
                            await response.OutputStream.WriteAsync(respBytes, 0, respBytes.Length);
                            await response.OutputStream.FlushAsync();
                            Debug.WriteLine("file not found");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error:" + ex.Message);
                    response.StatusCode = 500;
                    byte[] respBytes = new byte[2048];
                    respBytes = Encoding.UTF8.GetBytes("500 Internal Server Error\n\n" + ex.ToString());
                    await response.OutputStream.WriteAsync(respBytes, 0, respBytes.Length);
                    await response.OutputStream.FlushAsync();
                }
            }
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
                DialogResult msg = MessageBox.Show("скаћ включен! ’отите отключить блокировку и выйти?", "скаћ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                        MessageBox.Show("Ќевозможно запустить MAX, так как отсутствует файл msvcp140.dll. ѕопробуйте переустановить MAX.", "max.exe", MessageBoxButtons.OK, MessageBoxIcon.Error,MessageBoxDefaultButton.Button1,MessageBoxOptions.ServiceNotification);
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
