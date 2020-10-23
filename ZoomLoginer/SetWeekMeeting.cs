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
        string[] _days = {"月曜日", "火曜日", "水曜日", "木曜日", "金曜日"};
        InputDate[] InputDates = new InputDate[5];
        Form form;
        public SetWeekMeeting(Form f)
        {
            form = f;

            for(int i = 0; i < InputDates.Length; i++)
            {
                InputDates[i] = new InputDate(_days[i], 350, 75 + 80 * i, 200, 40 );
                InputDates[i].GenerateInputDate(form);
            }
            if (File.Exists(@"./WeekMeetingInfo.zlo")) Load();
        }
        public void Save()
        {
            StreamWriter writer = new StreamWriter(@"./WeekMeetingInfo.zlo",false);
            foreach(var ID in InputDates)
            {
                writer.WriteLine(ID.GetDateInfo());
            }
            writer.Close();
        }

        public void Load()
        {
            StreamReader reader = new StreamReader(@"./WeekMeetingInfo.zlo");
            for (int i = 0; i < InputDates.Length; i++)
            {
                string text = reader.ReadLine();
                if (text != null) InputDates[i].Load(text);
            }
            reader.Dispose();
        }
    }
}
