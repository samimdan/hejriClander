using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;

namespace sysinfo
{
    public sealed partial class MainWindow:Window
    {
        public static HollyTimes HollyTime { get; set; }
        public void PopulateDateInfo()
        {
            HollyTime=Task.Run(async ()=> await GetDatafromApi.GetHollyTimesAsync()).Result;
            MorningHolyHourTb.Text = "0" + hTimeResult.MorningHollyTime.Hour.ToString();
            MorningHolyMinTb.Text = hTimeResult.MorningHollyTime.Minute.ToString();
            EveningHolyHourTb.Text = Tools.Convert24To12(hTimeResult.EveningHollyTime.Hour).ToString();
            EveningHolyMinTb.Text = hTimeResult.EveningHollyTime.Minute.ToString();
            AfterNoonHolyHourTb.Text = "0"+Tools.Convert24To12(hTimeResult.AfternoonHollyTime.Hour).ToString();
            AfterNoonHolyMinTb.Text = hTimeResult.AfternoonHollyTime.Minute.ToString();
            TodayChDateTb.Text = ChrisitianDate.ChDay.ToString();
            MonthChDateTb.Text = ChrisitianDate.ChMonth.ToString();
            MonthChDateTextTb.Text = ChrisitianDate.ChMonthName;
        }
    }
}
