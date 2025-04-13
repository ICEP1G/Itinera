using Itinera.Client.ViewModels;

namespace Itinera.Client.Views.Pages;

public partial class PlacelistPage : ContentPage
{
	public PlacelistPage(PlacelistPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}