using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;

namespace sysinfo
{
    public sealed partial class MainWindow : Window
    {



        public void PopulateWeatherInfo()
        {
            OpenWeatherResponse weatherResponse = Task.Run(async () => await GetDatafromApi.GetWeatherDataAsync("Hamedan")).Result;
            if (weatherResponse.Main.Temp != null) TempTb.Text = weatherResponse.Main.Temp?.ToString("0.0") + "°";
            if (weatherResponse.Main.Humidity != null) HumidityTb.Text = weatherResponse.Main.Humidity?.ToString() ;
            if (weatherResponse.Wind.Speed != null) WindTb.Text = Math.Round(Tools.MileToKm(weatherResponse.Wind.Speed.Value), 1).ToString(CultureInfo.CurrentCulture) ;
            int uvIndex=Task.Run(async () => await GetDatafromApi.GetUvIndex("Hamedan")).Result;
            if (uvIndex != 0) UvTb.Text = uvIndex.ToString();
        }
    }
}
