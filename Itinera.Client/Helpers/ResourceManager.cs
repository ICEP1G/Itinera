using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.Helpers
{
    public static class ResourceManager
    {
        public static Color GetColor(string key)
        {
            if (Application.Current.Resources.TryGetValue(key, out var value) && value is Color color)
            {
                return color;
            }

            // Return a fushia color if not found in order to detect the issue in the app
            return Color.FromRgba("E700F7");

            //throw new KeyNotFoundException($"Resource for the key '{key}' was not found.");
        }
    }
}
