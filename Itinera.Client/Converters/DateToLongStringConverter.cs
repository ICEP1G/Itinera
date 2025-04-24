using System.Globalization;

namespace Itinera.Client.Converters
{
    public class DateToLongStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                string daySuffix = GetDaySuffix(date.Day);
                return $"{date.ToString("MMMM", CultureInfo.InvariantCulture)} {date.Day}{daySuffix}, {date.Year}";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static string GetDaySuffix(int day)
        {
            if (day >= 11 && day <= 13) return "th";

            return (day % 10) switch
            {
                1 => "st",
                2 => "nd",
                3 => "rd",
                _ => "th"
            };
        }
    }
}
