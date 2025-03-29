using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace sysinfo
{
  public struct Weather
  {
    public int Id { get; set; }
    public string MainTemp { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string Day { get; set; } // Changed DayStatus to string
  }
  public class DayStatus
  {
    public const string AM = "AM";
    public const string PM = "PM";
    public const string NA = "NA";
  }
  public class WeatherStates
  {
    public List<Weather> WeatherCollection= [];
   

    public WeatherStates()
    {
      WeatherCollection.Add(new Weather { Id = 800, MainTemp = "Clear", Description = "clear sky", Image = "ms-appx:///Assets/weather/sun.png", Day = DayStatus.AM });
      WeatherCollection.Add(new Weather { Id = 8001, MainTemp = "Clear", Description = "clear sky", Image = "ms-appx:///Assets/weather/moon.png", Day = DayStatus.PM });
      WeatherCollection.Add(new Weather { Id = 801, MainTemp = "Clouds", Description = "few clouds", Image = "ms-appx:///Assets/weather/sun.png", Day = DayStatus.AM });
      WeatherCollection.Add(new Weather { Id = 8011, MainTemp = "Clouds", Description = "few clouds", Image = "ms-appx:///Assets/weather/moon.png", Day = DayStatus.PM });
      WeatherCollection.Add(new Weather { Id = 802, MainTemp = "Clouds", Description = "scattered clouds", Image = "ms-appx:///Assets/weather/sun.png", Day = DayStatus.AM });
      WeatherCollection.Add(new Weather { Id = 8022, MainTemp = "Clouds", Description = "scattered clouds", Image = "ms-appx:///Assets/weather/moon.png", Day = DayStatus.PM });
      WeatherCollection.Add(new Weather { Id = 803, MainTemp = "Clouds", Description = "broken clouds", Image = "ms-appx:///Assets/weather/moon.png", Day = DayStatus.PM });
      WeatherCollection.Add(new Weather { Id = 8033, MainTemp = "Clouds", Description = "broken clouds", Image = "ms-appx:///Assets/weather/sun.png", Day = DayStatus.AM });
      WeatherCollection.Add(new Weather { Id = 804, MainTemp = "Clouds", Description = "overcast clouds", Image = "ms-appx:///Assets/weather/sun_clouds.png", Day = DayStatus.AM });
      WeatherCollection.Add(new Weather { Id = 8044, MainTemp = "Clouds", Description = "overcast clouds", Image = "ms-appx:///Assets/weather/moon_clouds.png", Day = DayStatus.PM });
      WeatherCollection.Add(new Weather { Id = 500, MainTemp = "Rain", Description = "light rain", Image = "ms-appx:///Assets/weather/NA_rain.png" ,Day=DayStatus.NA });
      WeatherCollection.Add(new Weather { Id = 501, MainTemp = "Rain", Description = "moderate rain", Image = "ms-appx:///Assets/weather/NA_rain.png", Day = DayStatus.NA });
      WeatherCollection.Add(new Weather { Id = 502, MainTemp = "Rain", Description = "heavy rain", Image = "ms-appx:///Assets/weather/NA_lighting.png", Day = DayStatus.NA });
      WeatherCollection.Add(new Weather { Id = 511, MainTemp = "Rain", Description = "freezing rain", Image = "ms-appx:///Assets/weather/NA_lighting.png", Day = DayStatus.NA });
      WeatherCollection.Add(new Weather { Id = 200, MainTemp = "Thunderstorm", Description = "thunderstorm with light rain", Image = "ms-appx:///Assets/weather/NA_lighting.png", Day = DayStatus.NA });
      WeatherCollection.Add(new Weather { Id = 600, MainTemp = "Snow", Description = "light snow", Image = "ms-appx:///Assets/weather/NA_rain_snow.png", Day = DayStatus.NA });
      WeatherCollection.Add(new Weather { Id = 601, MainTemp = "Snow", Description = "snow", Image = "ms-appx:///Assets/weather/NA_rain_snow.png", Day = DayStatus.NA });
      WeatherCollection.Add(new Weather { Id = 701, MainTemp = "Mist", Description = "mist", Image = "ms-appx:///Assets/weather/fog.png", Day = DayStatus.NA });
      WeatherCollection.Add(new Weather { Id = 741, MainTemp = "Fog", Description = "fog", Image = "ms-appx:///Assets/weather/fog.png", Day = DayStatus.NA });
      WeatherCollection.Add(new Weather { Id = 761, MainTemp = "Ash", Description = "ash", Image = "ms-appx:///Assets/weather/ash.png", Day = DayStatus.NA });
          }
  }
}
