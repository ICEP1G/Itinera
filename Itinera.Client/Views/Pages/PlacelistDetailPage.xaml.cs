using Itinera.Client.ViewModels.Pages;

namespace Itinera.Client.Views.Pages;

public partial class PlacelistDetailPage : ContentPage
{
	public PlacelistDetailPage(PlacelistDetailPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}