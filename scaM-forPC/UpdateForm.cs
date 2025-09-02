using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scaM_forPC
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
            DescriptionWebView.EnsureCoreWebView2Async();
        }

        Release release;
        HttpListener server;

        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        private async void UpdateForm_Load(object sender, EventArgs e)
        {
            try
            {
                server = new HttpListener();
                server.Prefixes.Add("http://127.0.0.1:7290/");
                server.Start();
                Task.Run(Server);
                GitHubClient client = new GitHubClient(new ProductHeaderValue("VladOS63K"));
                release = await client.Repository.Release.GetLatest("VladOS63K", "scaM-forPC");
                TitleLabel.Text = release.Name.Replace("DirectUpdate", "");
                DescriptionWebView.Source = new Uri("http://127.0.0.1:7290");
                if (!release.Name.Contains("DirectUpdate")) UpdateBtn.Enabled = true;
                else linkLabel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при получении данных...\n\n" + ex.ToString());
                this.Close();
            }
        }

        async void Server()
        {
            var context = await server.GetContextAsync();
            var request = context.Request;
            var response = context.Response;

            if (release != null)
            {
                response.StatusCode = 200;
                byte[] text = Encoding.UTF8.GetBytes("<meta charset=\"utf8\">\n<style>body{font-family:Segoe UI,sans-serif;font-size:10pt;}</style>" + Markdig.Markdown.ToHtml(release.Body));
                response.ContentLength64 = text.Length;
                response.ContentType = "text/html";
                await response.OutputStream.WriteAsync(text, 0, text.Length);
            }
            else
            {
                response.StatusCode = 404;
                byte[] text = Encoding.UTF8.GetBytes("Release is not available at this time!");
                response.ContentLength64 = text.Length;
                response.ContentType = "text/plain";
                await response.OutputStream.WriteAsync(text, 0, text.Length);
            }
            response.ContentEncoding = Encoding.UTF8;
            await response.OutputStream.FlushAsync();
            server.Stop();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            Process.Start(System.Windows.Forms.Application.StartupPath + "\\Updater\\net8.0-windows\\Updater.exe");
            this.Close();
        }

        private void CancelBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl("https://github.com/VladOS63K/scaM-forPC/releases/tag/" + release.TagName);
        }

        private void UpdateForm_Shown(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
    }
}
