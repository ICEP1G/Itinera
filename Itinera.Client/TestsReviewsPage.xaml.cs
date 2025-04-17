namespace Itinera.Client;

public partial class TestsReviewsPage : ContentPage
{
	public TestsReviewsPage(TestsReviewsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}