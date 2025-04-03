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
        public void PopulateDateInfo()
        {
            HollyTimes hTimeResult=Task.Run(async ()=> await GetDatafromApi.GetHollyTimesAsync()).Result;
            MorningHolyHourTb.Text = hTimeResult.MorningHollyTime.Hour.ToString();
            MorningHolyMinTb.Text = hTimeResult.MorningHollyTime.Minute.ToString();
            EveningHolyHourTb.Text = Tools.Convert24To12(hTimeResult.EveningHollyTime.Hour).ToString();
            EveningHolyMinTb.Text = hTimeResult.EveningHollyTime.Minute.ToString();
            AfterNoonHolyHourTb.Text = Tools.Convert24To12(hTimeResult.AfternoonHollyTime.Hour).ToString();
            AfterNoonHolyMinTb.Text = hTimeResult.AfternoonHollyTime.Minute.ToString();
        }
    }
}
