using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;

namespace sysinfo
{
    public sealed partial class MainWindow: Window
    {

        public static DispatcherTimer Timer { get; } = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
       
        private void TimerStart()
        {
            Timer.Tick += (sender, e) =>
            {
                Time.Hour = DateTime.Now.Hour;
                Time.Minute = DateTime.Now.Minute;
                Time.Second = DateTime.Now.Second;
                int hour = DateTime.Now.Hour % 12;
                if (hour == 0) hour = 12;

                HourTb.Text = hour.ToString();
                MinuteTb.Text = DateTime.Now.Minute.ToString();
                SecondTb.Text = DateTime.Now.ToString("ss");

                SecondAnimation.Begin();
            };
            Timer.Start();
        }
    }
    internal class Time()
    {
        public static int Hour { get; set; }
        public static int Minute { get; set; }
        public static int Second { get; set; }
    }

}
