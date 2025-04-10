using Itinera.Client.Views.Pages;

namespace Itinera.Client
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PlacePage), typeof(PlacePage));
        }
    }
}
