using Itinera.Client.Helpers;
using Itinera.Client.ViewModels.Components;

namespace Itinera.Client;

public partial class TestsPage : ContentPage
{
    public TestsPage(TestsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}