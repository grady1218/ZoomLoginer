using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZoomLoginer
{
    class InputDate
    {
        public string DayName { get; set; }
        public string Url{ get; set; }

        int _x;
        int _y;
        int _width;
        int _height;

        Label _nameLabel;
        TextBox _hour;
        TextBox _minute;
        TextBox _url;

        public InputDate(string Day, int x, int y, int width, int height)
        {
            DayName = Day;
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        public InputDate(string Info) : base()
        {
            GenerateInputDate();
            Load(Info);
        }

        public void GenerateInputDate(Form form = null)
        {
            int xSize = _width / 4;
            int ySize = _height / 2;
            _nameLabel = new Label
            {
                Location = new Point(_x, _y),
                Size = new Size(xSize, ySize),
                Text = DayName
            };
            _hour = new TextBox
            {
                Location = new Point(_x + xSize + xSize / 2, _y),
                Size = new Size(xSize, ySize),
            };
            _minute = new TextBox
            {
                Location = new Point(_x + xSize * 3, _y),
                Size = new Size(xSize, ySize),
            };
            _url = new TextBox
            {
                Location = new Point(_x, _y + ySize),
                Size = new Size(_width, ySize),
            };

            if (form != null) AddInputDate(form);

        }
        public void AddInputDate(Form f)
        {
            f.Controls.Add(_nameLabel);
            f.Controls.Add(_hour);
            f.Controls.Add(_minute);
            f.Controls.Add(_url);
        }

        public void RemoveInputDate(Form f)
        {
            f.Controls.Remove(_nameLabel);
            f.Controls.Remove(_hour);
            f.Controls.Remove(_minute);
            f.Controls.Remove(_url);
        }

        public string GetDateInfo()
        {
            return $"{DayName},{_hour.Text},{_minute.Text},{_url.Text}";
        }

        public void Load(string dateInfo)
        {
            string[] info = dateInfo.Split(',');

            if(info.Length == 4)
            {
                _nameLabel.Text = info[0];
                _hour.Text = info[1];
                _minute.Text = info[2];
                _url.Text = info[3];
            }

        }
    }
}
