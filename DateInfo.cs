using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sysinfo
{
    struct MorningHollyTime
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
    
    }
    struct EveningHollyTime
    {
        public int Hour { get; set; }
        public int Minute { get; set; }

    }
    struct AfternoonHollyTime
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
    }
   
    internal class DateInfo
    {
        /// <summary>
        /// Gets or sets the date text.
        /// </summary>
        public required string DateText { get; set; }

        /// <summary>
        /// Gets or sets the month text.
        /// </summary>
        public required string MonthText { get; set; }

        /// <summary>
        /// Gets or sets the day text.
        /// </summary>
        public required string DayText { get; set; }

        public MorningHollyTime morningHollyTime { get; set; }
        public EveningHollyTime eveningHollyTime { get; set; }
        public AfternoonHollyTime afternoonHollyTime { get; set; }


    }
    // Existing code...

    internal class ChrisitianDate
    {
        public static int ChDay { get; set; }
        public static int ChMonth { get; set; }
        public static string ChMonthName { get; set; }

        static ChrisitianDate()
        {
            var today = DateTime.Now;
            ChDay = today.Day;
            ChMonth = today.Month;
            ChMonthName = GetMonthName(ChMonth);
        }

        private static string GetMonthName(int month)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        }
    }
    internal class SunPosition
    {
        public const string AM = "AM";
        public const string PM = "PM";
        public const string NA = "NA";
    }
}
