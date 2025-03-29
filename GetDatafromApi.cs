using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;
using System.Diagnostics;
using Microsoft.UI.Xaml;
using Newtonsoft.Json;


namespace sysinfo
{
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

                var dateInfo = new DateInfo
                {
                    DateText = todayNum,
                    MonthText = month,
                    DayText = todayText
                };
                return dateInfo;
            }
            catch (Exception e)
            {
                ErrorHandeling.ShowError(e.Message, "Error");
                return new DateInfo
                {
                    DateText = "00",
                    MonthText = "00",
                    DayText = "00"
                };
            }
        }

        public async Task<Weather> GetWeatherDataAsync(string cityName)
        {
            const string apiKey = "eb56f50ab7a5ef07ba1e5165eeef8da7"; // Replace with your API key
            const string baseUrl = "https://api.openweathermap.org/data/2.5/weather";
            using (HttpClient client = new HttpClient())
            {
                string url = $"{baseUrl}?q={cityName}&units=metric&appid={apiKey}";

                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var weatherResponse = JsonConvert.DeserializeObject<Weather>(json);
                    return weatherResponse;
                }
                else
                {
                    // Handle error if necessary
                    return null;
                }
            }
        }
    }

                }

