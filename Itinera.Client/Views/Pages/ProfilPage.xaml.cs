using Itinera.Client.ViewModels.Pages;

namespace Itinera.Client;

public partial class ProfilPage : ContentPage
{
	public ProfilPage(ProfilPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}