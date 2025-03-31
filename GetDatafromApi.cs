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
<<<<<<< HEAD
            const string url = "https://www.bahesab.ir/time/hamedan/";
            try
=======
            HttpClient httpClient = new HttpClient();
            string html = await httpClient.GetStringAsync(url);
            Doc = new HtmlDocument();
            Doc.LoadHtml(html);
            HtmlNode node = Doc.DocumentNode.SelectSingleNode("//span[@id='date']");
            if (node == null)
                throw new Exception("Failed to get date.");
            string todayNum = node.SelectSingleNode(".//span").InnerText;
            if (todayNum == null) throw new Exception("Failed to get today.");
            string month = node.InnerHtml.Split("</span>")[1].Split("<br>")[0];

            Debug.WriteLine(month);
            if (month == null) throw new Exception("Failed to get month.");
            string todayText = node.InnerHtml.Split("<span>")[0].Split(" ")[1];
            string morningHolyTime = Doc.DocumentNode.SelectSingleNode("//div[@class='timer']").ChildNodes[0].InnerText.Split("--")[0];
            string noonHolyTime = Doc.DocumentNode.SelectSingleNode("//span[@id='azan-time3']").InnerText;
            string afternoonHolyTime = Doc.DocumentNode.SelectSingleNode("//span[@id='azan-time5']").InnerText;
            
            DateInfo dateInfo = new DateInfo
>>>>>>> parent of d65b2f1 (almost done 🥳🥳🥳🥳)
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

<<<<<<< HEAD
                Debug.WriteLine(month);
                if (month == null) throw new Exception("Failed to get month.");
                var todayText = node.InnerHtml.Split("<span>")[0].Split(" ")[1];

                var dateInfo = new DateInfo
                {
                    DateText = todayNum,
                    MonthText = month,
                    DayText = todayText
=======
                },
                Noon = new Noon
                {
                    Hour = int.Parse(Tools.ConvertPersianToEnglish( noonHolyTime.Split(":")[0])),
                    Minute = int.Parse(Tools.ConvertPersianToEnglish(noonHolyTime.Split(":")[1])),
                },
                AfterNoon = new AfterNoon
                {
                    Hour = int.Parse(Tools.ConvertPersianToEnglish(afternoonHolyTime.Split(":")[0])),
                    Minute = int.Parse(Tools.ConvertPersianToEnglish(afternoonHolyTime.Split(":")[1])),
                }

            };
            return dateInfo;
        }
<<<<<<< HEAD
        catch (Exception e)
=======

        public async Task<Weather> GetWeatherDataAsync(string cityName)
>>>>>>> main
        {
            ErrorHandeling.ShowError(e.Message, "Error");
            return new DateInfo
            {
                DateText = "00",
                MonthText = "00",
                DayText = "00",
                Morning = new Morning
                {
                    Hour = 0,
                    Minute = 0,
                },
                Noon = new Noon
                {
                    Hour = 0,
                    Minute = 0,
                },
                AfterNoon = new AfterNoon
                {
                    Hour = 0,
                    Minute = 0,
                }

<<<<<<< HEAD
            };
=======
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
>>>>>>> main
        }
    }

    public static async Task<Weather> GetWeatherDataAsync(string cityName)
    {
        const string apiKey = "eb56f50ab7a5ef07ba1e5165eeef8da7";
        const string baseUrl = "https://api.openweathermap.org/data/2.5/weather";

        using HttpClient client = new HttpClient();
        try
        {
            var url = $"{baseUrl}?q={cityName}&units=metric&appid={apiKey}";
            Debug.WriteLine(url);
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return new Weather
                {
                    CurrentSunPosition = SunPosition.NA,
                    CurrentDescription = "NA",
                    Id = 0,
                    Temp = 0,
                    Wind = 0,
                    Humidity = 0,
                   
>>>>>>> parent of d65b2f1 (almost done 🥳🥳🥳🥳)
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

