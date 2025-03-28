using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sysinfo
{
    public class WeatherResponse
    {
        public required MainWeather Main { get; set; }
        public required Weather[] Weather { get; set; }
    }

    public class MainWeather
    {
        public required double Temp { get; set; }
    }

    public class Weather
    {
        public required string Description { get; set; }
        public required string Icon { get; set; }
    }
}
