using Itinera.Client.Services;
using Itinera.Client.ViewModels.Pages;

namespace Itinera.Client;

public partial class HomePage : ContentPage
{
    public HomePage(HomePageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is HomePageViewModel viewModel)
        {
            if(ApplicationService.IsFirstConnection is false)
            {
                await viewModel.LoadUserData();
            }
            else
            {
                await AppShell.Current.GoToAsync($"{nameof(LoginPage)}");
            }
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        if (BindingContext is HomePageViewModel viewModel)
        {
            viewModel.Dispose();
        }
    }
}