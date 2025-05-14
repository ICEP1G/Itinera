using Itinera.Client.ViewModels.Pages;

namespace Itinera.Client;

public partial class HomePage : ContentPage
{
    public HomePage(HomePageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
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