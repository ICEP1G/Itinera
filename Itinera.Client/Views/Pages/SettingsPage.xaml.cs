using Itinera.Client.ViewModels.Pages;

namespace Itinera.Client;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(HomePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}