using Itinera.Client.ViewModels.Pages;

namespace Itinera.Client.Views.Pages;

public partial class ItinerosPage : ContentPage
{
	public ItinerosPage(ItinerosPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}