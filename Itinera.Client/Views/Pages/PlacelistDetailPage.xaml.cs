using Itinera.Client.ViewModels.Pages;

namespace Itinera.Client.Views.Pages;

public partial class PlacelistDetailPage : ContentPage
{
    private readonly PlacelistDetailPageViewModel _viewModel;
    public PlacelistDetailPage(PlacelistDetailPageViewModel viewModel)
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

}