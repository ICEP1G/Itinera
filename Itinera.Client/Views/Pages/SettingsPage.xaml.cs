using Itinera.Client.Services;
using Itinera.Client.ViewModels.Pages;
using Itinera.Client.Views.Components;

namespace Itinera.Client;

public partial class SettingsPage : ContentPage
{
    private readonly IItinerosService _itinerosService;

    public SettingsPage(SettingsPageViewModel viewModel, IItinerosService itinerosService)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _itinerosService = itinerosService;

        var updateProfilViewModel = new ProfilPageViewModel(_itinerosService);
        UpdateProfilContainer.Content = new UpdateProfil(updateProfilViewModel);

        var updateAccountViewModel = new UpdateAccountViewModel();
        UpdateAccountContainer.Content = new UpdateAccount(updateAccountViewModel);
    }
}
