using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scaM_forPC
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SetStartup(bool value)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (value)
                rk.SetValue("scaM-forPC", Application.ExecutablePath + " -autorun");
            else
                rk.DeleteValue("scaM-forPC", false);

        }

        private bool GetStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");

            return rk.GetValue("scaM-forPC")!=null;

        }

        bool isSettingAutoRun = true;

        private void label1_Click(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.BringToFront();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            checkBox2.Checked = GetStartup();
            isSettingAutoRun = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (isSettingAutoRun) return;
            SetStartup(checkBox2.Checked);
        }
    }
}
