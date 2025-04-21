using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.Converters
{
    public class BoolOrBoolConverter
    {
        public class BoolAndBoolConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                if (values.Length == 2 && values[0] is bool boolValue1 && values[1] is bool boolValue2)
                {
                    return boolValue1 || boolValue2;
                }
                return false;
            }

            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}
