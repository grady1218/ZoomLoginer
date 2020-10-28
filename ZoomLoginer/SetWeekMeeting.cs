using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ZoomLoginer
{
    class SetWeekMeeting
    {
        Dictionary<int, InputDate> InputDates = new Dictionary<int, InputDate>();
        Form form;
        string[] _datas;
        public SetWeekMeeting(Form f)
        {
            form = f;
            if (File.Exists(@"./WeekMeetingInfo.zlo")) Load();
            else
            {
                for (int i = 0; i < _datas.Length; i++)
                {
                    InputDates[i] = new InputDate(i.ToString(), 350, 75 + 80 * i, 200, 40);
                    InputDates[i].GenerateInputDate(form);
                }
            }
        }
        public void Save()
        {
            StreamWriter writer = new StreamWriter(@"./WeekMeetingInfo.zlo",false);
            foreach(var ID in InputDates)
            {
                writer.WriteLine(ID.Value.GetDateInfo());
            }
            writer.Close();
        }

        public void Load()
        {
            _datas = File.ReadAllLines(@"./WeekMeetingInfo.zlo");
            for (int i = 0; i < _datas.Length; i++)
            {
                string text = _datas[i];
                if (text != null) InputDates[i].Load(text);
            }
        }
    }
}
