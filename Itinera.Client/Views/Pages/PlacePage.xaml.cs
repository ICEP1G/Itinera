using Itinera.Client.ViewModels;

namespace Itinera.Client.Views.Pages;

public partial class PlacePage : ContentPage
{
	public PlacePage(PlacePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}