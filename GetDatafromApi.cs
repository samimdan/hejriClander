#region

using System;
using System.Diagnostics;
using System.Dynamic;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace sysinfo;

internal class GetDatafromApi
{
    public async Task<DateInfo> FetchDataContentAsync()
    {
        const string url = "https://www.bahesab.ir/time/hamedan/";
        try
        {
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var node = doc.DocumentNode.SelectSingleNode("//span[@id='date']");
            if (node == null)
                throw new Exception("Failed to get date.");
            var todayNum = node.SelectSingleNode(".//span").InnerText;
            if (todayNum == null) throw new Exception("Failed to get today.");
            var month = node.InnerHtml.Split("</span>")[1].Split("<br>")[0];

            Debug.WriteLine(month);
            if (month == null) throw new Exception("Failed to get month.");
            var todayText = node.InnerHtml.Split("<span>")[0].Split(" ")[1];
            var morningHolyTime = doc.DocumentNode.SelectSingleNode("//div[@class='timer']").ChildNodes[0].InnerText
                .Split("--")[0];
            var noonHolyTime = doc.DocumentNode.SelectSingleNode("//span[@id='azan-time3']").InnerText;
            var afternoonHolyTime = doc.DocumentNode.SelectSingleNode("//span[@id='azan-time5']").InnerText;


            Debug.WriteLine(month);
            if (month == null) throw new Exception("Failed to get month.");


            var dateInfo = new DateInfo
            {
                DateText = todayNum,
                MonthText = month,
                DayText = todayText,
                morningHollyTime = new MorningHollyTime
                {
                    Hour = int.Parse(Tools.ConvertPersianToEnglish(morningHolyTime.Split(":")[0])),
                    Minute = int.Parse(Tools.ConvertPersianToEnglish(morningHolyTime.Split(":")[1]))
                },
                eveningHollyTime = new EveningHollyTime
                {
                    Hour = int.Parse(Tools.ConvertPersianToEnglish(noonHolyTime.Split(":")[0])),
                    Minute = int.Parse(Tools.ConvertPersianToEnglish(noonHolyTime.Split(":")[1]))
                },
                afternoonHollyTime = new AfternoonHollyTime
                {
                    Hour = int.Parse(Tools.ConvertPersianToEnglish(afternoonHolyTime.Split(":")[0])),
                    Minute = int.Parse(Tools.ConvertPersianToEnglish(afternoonHolyTime.Split(":")[1]))
                }
            };
            return dateInfo;
        }

        catch
        {
            return new DateInfo
                {
                    DateText = "00",
                    MonthText = "00",
                    DayText = "00",
                    morningHollyTime = new MorningHollyTime
                    {
                        Hour = 0,
                        Minute = 0
                    },
                    eveningHollyTime = new EveningHollyTime
                    {
                        Hour = 0,
                        Minute = 0
                    },
                    afternoonHollyTime = new AfternoonHollyTime
                    {
                        Hour = 0,
                        Minute = 0
                    }
                }
                ;
        }
    }


    public static async Task<OpenWeatherResponse> GetWeatherDataAsync(string cityName)
    {
        const string apiKey = "eb56f50ab7a5ef07ba1e5165eeef8da7"; // Replace with your API key
        const string baseUrl = "https://api.openweathermap.org/data/2.5/weather";
        using var client = new HttpClient();
        var url = $"{baseUrl}?q={cityName}&units=metric&appid={apiKey}";
        var weatherResponse = new OpenWeatherResponse();
        try
        {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var deserializedWeather = JsonConvert.DeserializeObject<OpenWeatherResponse>(json);

                weatherResponse = deserializedWeather ?? throw new Exception("Failed to get weather.");
            }
        }
        catch (Exception ex)
        {
            return new OpenWeatherResponse
            {
                Id = 0,
                Main = new Main(), // Initialize Main object properly

                Wind = new Wind()
            };
        }

        const string uVApiKey = "S8VLXMD9R3FE7FRCHFQN396RU"; // Replace with your API key
        var uVUrl =
            $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{cityName}?unitGroup=us&key={uVApiKey}&contentType=json";

        using var uVClient = new HttpClient();
        try
        {
            var response = await client.GetAsync(uVUrl);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                dynamic? uVObject = JsonConvert.DeserializeObject<ExpandoObject>(json, new ExpandoObjectConverter());
                var uVIndexNode = uVObject?.days?[0]?.uvindex;

                if (uVIndexNode != null)
                {
                    //
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching UV index: {ex.Message}");
        }

        return weatherResponse;
    }
}