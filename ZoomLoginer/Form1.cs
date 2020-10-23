using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;

namespace ZoomLoginer
{
    class Form1 : Form
    {
        SettingsForm SettingsForm;
        string url = @"https://us04web.zoom.us/j/9352925224?pwd=NEprWFJhc1pPQ2dJZFE2VUN1UXJBQT09";
        public Form1()
        {

            SettingsForm = new SettingsForm(this);

            Text = "ZoomLoginer Settings";
            Opacity = 0;
            Size = new System.Drawing.Size( 600, 600 );
            BackColor = Color.White;
            ControlBox = false;
            //WindowState = FormWindowState.Maximized;

            ShowInTaskbar = false;
            NotifyIcon Icon = new NotifyIcon();

            Icon.Icon = new System.Drawing.Icon( "./Image/ZoomLoginerIcon.ico" );
            Icon.Visible = true;
            Icon.Text = "ZoomLoginer";

            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            ToolStripMenuItem Login = new ToolStripMenuItem
            {
                Text = "&参加"
            };
            var Settings = new ToolStripMenuItem
            {
                Text ="&設定"
            };

            Login.Click += Login_Click;
            Settings.Click += Settings_Click;

            menu.Items.Add(Login);
            menu.Items.Add(Settings);

            menuItem.Text = "&終了";
            menuItem.Click += new EventHandler(Close_Click);
            menu.Items.Add(menuItem);
            Icon.ContextMenuStrip = menu;

        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Opacity = 1;
            SettingsForm.SetObject();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            Process.Start(url);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
