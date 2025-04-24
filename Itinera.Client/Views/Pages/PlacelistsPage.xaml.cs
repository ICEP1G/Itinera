using Itinera.Client.ViewModels;
using Itinera.Client.ViewModels.Pages;

namespace Itinera.Client.Views.Pages;

public partial class PlacelistsPage : ContentPage
{
    private readonly PlacelistsPageViewModel _viewModel;
    public PlacelistsPage(PlacelistsPageViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadDataAsync();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        if (BindingContext is PlacelistsPageViewModel viewModel)
        {
            viewModel.Dispose();
        }
    }
}