using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MZExtensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts a DateTime into a Human Readable relative date. For example: 1/Feb/2011 => "1 month ago".
        /// Also see http://timeago.yarp.com/ for a clientside way to do this
        /// </summary>
        /// <seealso cref="http://timeago.yarp.com/"/>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToTimeAgo(this DateTime input)
        {
            TimeSpan span = DateTime.Now.Subtract(input);
            double totalMinutes = span.TotalMinutes;
            string suffix = " ago";

            if (totalMinutes < 0.0)
            {
                totalMinutes = Math.Abs(totalMinutes);
                suffix = " from now";
            }

            var aValue = new Dictionary<double, Func<string>>();
            aValue.Add(0.75, () => "less than a minute");
            aValue.Add(1.5, () => "about a minute");
            aValue.Add(45, () => string.Format("{0} minutes", Math.Round(totalMinutes)));
            aValue.Add(90, () => "about an hour");
            aValue.Add(1440, () => string.Format("about {0} hours", Math.Round(Math.Abs(span.TotalHours)))); // 60 * 24
            aValue.Add(2880, () => "a day"); // 60 * 48
            aValue.Add(43200, () => string.Format("{0} days", Math.Floor(Math.Abs(span.TotalDays)))); // 60 * 24 * 30
            aValue.Add(86400, () => "about a month"); // 60 * 24 * 60
            aValue.Add(525600, () => string.Format("{0} months", Math.Floor(Math.Abs(span.TotalDays / 30)))); // 60 * 24 * 365 
            aValue.Add(1051200, () => "about a year"); // 60 * 24 * 365 * 2
            aValue.Add(double.MaxValue, () => string.Format("{0} years", Math.Floor(Math.Abs(span.TotalDays / 365))));

            return aValue.First(n => totalMinutes < n.Key).Value.Invoke() + suffix;
        }
    }
}
