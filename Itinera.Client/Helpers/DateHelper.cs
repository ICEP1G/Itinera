using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.Helpers
{
    public static class DateHelper
    {
        public static string GetRelativeDate(DateTime date)
        {
            TimeSpan span = DateTime.Now - date;
            int days = span.Days;

            switch (days)
            {
                case 0:
                    return "Today";
                case 1:
                    return "Yesterday";
                case < 7:
                    return $"{days} days ago";
                case < 30:
                    int weeks = days / 7;
                    return $"{weeks} week{(weeks > 1 ? "s" : "")} ago";
                case < 365:
                    int months = days / 30;
                    return $"{months} month{(months > 1 ? "s" : "")} ago";
                default:
                    int years = days / 365;
                    return $"{years} year{(years > 1 ? "s" : "")} ago";
            }
        }
    }
}
