using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZoomLoginer
{
    class SettingsForm
    {
        Form form;
        SetWeekMeeting weekMeeting;
        public SettingsForm(Form f)
        {
            form = f;
        }

        public void SetObject()
        {
            Button classMeeting = new Button
            {
                Size = new System.Drawing.Size( 200, 40 ),
                Location = new System.Drawing.Point( 30, 75 ),
                Text = "定期ミーティング"
            };

            Button free = new Button
            {
                Size = new System.Drawing.Size(200, 40),
                Location = new System.Drawing.Point(30, 155),
                Text = "休み"
            };

            Button events = new Button
            {
                Size = new System.Drawing.Size(200, 40),
                Location = new System.Drawing.Point(30, 235),
                Text = "特殊ミーティング"
            };

            Button shortcut = new Button
            {
                Size = new System.Drawing.Size(200, 40),
                Location = new System.Drawing.Point(30, 315),
                Text = "ショートカット"
            };

            Button settings = new Button
            {
                Size = new System.Drawing.Size(200, 40),
                Location = new System.Drawing.Point(30, 395),
                Text = "設定"
            };

            Button returnForm = new Button
            {
                Size = new System.Drawing.Size(200, 40),
                Location = new System.Drawing.Point(350, 500),
                Text = "戻る"
            };

            classMeeting.Click += ClassMeeting_Click;
            returnForm.Click += ReturnForm_Click;

            form.Controls.Add(classMeeting);
            form.Controls.Add(free);
            form.Controls.Add(events);
            form.Controls.Add(shortcut);
            form.Controls.Add(settings);
            form.Controls.Add(returnForm);
        }

        private void ClassMeeting_Click(object sender, EventArgs e)
        {
            weekMeeting = new SetWeekMeeting(form);
        }

        private void ReturnForm_Click(object sender, EventArgs e)
        {
            if (weekMeeting != null) weekMeeting.Save();
            form.Controls.Clear();
            form.Opacity = 0f;
            weekMeeting = null;
            
        }
    }
}
