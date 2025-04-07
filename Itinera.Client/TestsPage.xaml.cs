using Itinera.Client.ViewModels.Components;

namespace Itinera.Client;

public partial class TestsPage : ContentPage
{
    public TestsPage()
	{
		InitializeComponent();
		BindingContext = new TestsPageViewModel();
	}

}