using Itinera.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.Converters
{
    public class BoolToColorFilterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? ResourceHelper.GetColor("Primary") : ResourceHelper.GetColor("Taupe700");
            }
            return Colors.RosyBrown; // Couleur par défaut si la valeur n'est pas un booléen
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
