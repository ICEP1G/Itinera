using Itinera.Client.ViewModels.Pages;

namespace Itinera.Client;

public partial class ProfilPage : ContentPage
{
	public ProfilPage()
	{
		InitializeComponent();
        BindingContext = new ProfilPageViewModel();
    }
}