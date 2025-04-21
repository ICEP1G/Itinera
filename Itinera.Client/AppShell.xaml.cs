using Itinera.Client.Views.Pages;

namespace Itinera.Client
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            #region Register route
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(PlacePage), typeof(PlacePage));
            Routing.RegisterRoute(nameof(PlacelistPage), typeof(PlacelistPage));
            Routing.RegisterRoute(nameof(ItinerosPage), typeof(ItinerosPage));
        }
    }
}
