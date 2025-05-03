using Itinera.Client.ViewModels.Pages;

namespace Itinera.Client;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}