using Aspose.Zip;
using Octokit;
using System.Diagnostics;
using System.IO.Compression;
using System.Net;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text.Json;

namespace Updater
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        Octokit.GitHubClient client;
        Octokit.Release release;

        private async void MainForm_Load(object sender, EventArgs e)
        {
            LabelStatus.Text = "Получаю URL загрузки последней версии...";
            this.Refresh();
            client = new Octokit.GitHubClient(new Octokit.ProductHeaderValue("VladOS63K"));
            release = await client.Repository.Release.GetLatest("VladOS63K", "scaM-forPC");
            HttpClient hcl = new HttpClient();
            string downloadurl = $"https://github.com/VladOS63K/scaM-forPC/releases/download/{release.TagName}/scaM-forPC-{release.TagName}.zip";
            LabelStatus.Text = "URL получен! Начинаю загрузку...";
            ProgressBar.Value = 33;
            Stream archiveStream = await hcl.GetStreamAsync(downloadurl);
            LabelStatus.Text = "Загружен, начинаю распаковку...";
            this.Refresh();
            await Task.Delay(100);
            foreach (Process p in Process.GetProcessesByName("scaM-forPC"))
            {
                LabelStatus.Text = $"Завершен {p.ProcessName} (PID: {p.Id})";
                p.Kill();
                await Task.Delay(100);
            }
            await Task.Delay(100);
            ProgressBar.Value = 50;
            string unpackPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath)));
            FileStream fs = File.Create(System.Windows.Forms.Application.StartupPath + "\\Updater_Temp.zip");
            await archiveStream.CopyToAsync(fs);
            fs.Close();
            archiveStream.Close();
            Archive arc = new Archive(System.Windows.Forms.Application.StartupPath + "\\Updater_Temp.zip");
            ArchiveEntry ae = null;
            foreach (ArchiveEntry ee in arc.Entries)
            {
                if (ee.Name == "Updater/")
                {
                    ae = ee;
                    break;
                }
                else
                {
                    ae = null;
                }
            }
            if (ae != null) arc.DeleteEntry(ae);
            arc.Save(System.Windows.Forms.Application.StartupPath + "\\Updater_Temp.zip");
            arc.Dispose();
            arc = new Archive(System.Windows.Forms.Application.StartupPath + "\\Updater_Temp.zip");
            arc.ExtractToDirectory(unpackPath);
            await Task.Delay(500);
            arc.Dispose();
            ProgressBar.Value = 100;
            LabelStatus.Text = $"Обновление завершено! скаМ был запущен.";
            Process.Start(unpackPath + "\\scaM-forPC.exe");
            await Task.Delay(3000);
            System.Windows.Forms.Application.Exit();
        }
    }
}
