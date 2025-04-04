using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;

namespace sysinfo
{
    internal class Tools
    {
        private static readonly Windows.Storage.StorageFolder Storage = Windows.Storage.ApplicationData.Current.LocalFolder;

        public static string ConvertPersianToEnglish(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var persianDigits = new[] { '۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹' };

            for (var i = 0; i < persianDigits.Length; i++)
            {
                input = input.Replace(persianDigits[i], i.ToString()[0]);
            }

            return input;
        }
        public static double MileToKm(double mile)
        {
            return (mile * 1.60934);
        }
        //conver 24 hour to 12 hour return int 
        public static int Convert24To12(int hour)
        {
            return hour switch
            {
                0 => 12,
                > 12 => hour - 12,
                _ => hour
            };
        }

        public static async Task SaveTextToFile(string text)
        {
            var path = Path.Combine(Storage.Path, "Idea.txt");
            

            try
            {
                await File.WriteAllTextAsync(path, text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error saving file: " + ex.Message);
            }
        }

        public static async Task<string> ReadFromIdea()
        {
            var path = Path.Combine(Storage.Path, "Idea.txt");
            try
            {
                return await File.ReadAllTextAsync(path);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error reading file: " + ex.Message);
                return string.Empty;
            }
        }
    }
}

