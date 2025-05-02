using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.Converters
{
    public class ScheduleListWithCommasConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable<string> schedules)
            {
                var scheduleList = new List<string>();
                var scheduleArray = schedules as string[] ?? schedules.ToArray();

                for (int i = 0; i < scheduleArray.Length; i++)
                {
                    scheduleList.Add(scheduleArray[i]);
                    if (i < scheduleArray.Length - 1)
                    {
                        scheduleList.Add(",  ");
                    }
                }
                return scheduleList;
            }
            return new List<string>();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
