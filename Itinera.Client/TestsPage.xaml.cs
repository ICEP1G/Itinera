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


    protected override void OnDisappearing()
    {
        base.OnDisappearing();

		if (BindingContext is TestsPageViewModel viewModel)
        {
            viewModel.Dispose();
		}
    }
}