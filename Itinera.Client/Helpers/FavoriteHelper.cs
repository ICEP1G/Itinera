using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.Helpers
{
    public static class FavoriteHelper
    {
        static FavoriteHelper()
        {
            var config = new ConfigurationBuilder().AddJsonFile(new EmbeddedFileProvider
                (typeof(App).Assembly, typeof(App).Namespace), "appsettings.json", false, true).Build();

            ItinerosFavoriteThreshold = int.Parse(config.GetSection("ItinerosFavoriteThreshold").Value);
            PlacelistFavoriteThreshold = int.Parse(config.GetSection("PlacelistFavoriteThreshold").Value);
            PlaceFavoriteThreshold = int.Parse(config.GetSection("PlaceFavoriteThreshold").Value);
        }

        public static int ItinerosFavoriteThreshold { get; set; }
        public static int PlacelistFavoriteThreshold { get; set; }
        public static int PlaceFavoriteThreshold { get; set; }
    }
}
