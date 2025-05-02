using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.Converters
{
    public class SelectCorrectTimeRangeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string timeRanges)
            {
                TimeSpan currentTime = DateTime.Now.TimeOfDay;
                string[] ranges = timeRanges.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string range in ranges)
                {
                    string[] times = range.Split(new[] { " – " }, StringSplitOptions.RemoveEmptyEntries);
                    if (times.Length == 2 && TimeSpan.TryParse(times[0], out var startTime) && TimeSpan.TryParse(times[1], out var endTime))
                    {
                        if (currentTime >= startTime && currentTime <= endTime)
                        {
                            return range;
                        }
                    }
                }
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
