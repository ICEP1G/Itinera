using Itinera.Client.ViewModels;

namespace Itinera.Client.Views.Pages;

public partial class PlacePage : ContentPage
{
    private readonly PlacePageViewModel _viewModel;
    public PlacePage(PlacePageViewModel viewModel)
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
        if (BindingContext is PlacePageViewModel viewModel)
        {
            viewModel.Dispose();
        }
    }
}