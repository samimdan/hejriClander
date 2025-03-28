using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sysinfo
{
    internal class PersianTools
    {
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
    }
}

