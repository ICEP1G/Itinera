using Itinera.Client.Helpers;
using Itinera.Client.ViewModels.Pages;

namespace Itinera.Client.Views.Pages;

public partial class ItinerosPage : ContentPage
{
	private readonly ItinerosPageViewModel _viewModel;
	public ItinerosPage(ItinerosPageViewModel viewModel)
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
        if (BindingContext is ItinerosPageViewModel viewModel)
        {
            viewModel.Dispose();
        }
    }
}