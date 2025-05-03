using Itinera.Client.ViewModels.Pages;
using Itinera.Client.Views.Components;

namespace Itinera.Client;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

        var updateAccountViewModel = new UpdateAccountViewModel();
        UpdateAccountContainer.Content = new UpdateAccount(updateAccountViewModel);
    }
}