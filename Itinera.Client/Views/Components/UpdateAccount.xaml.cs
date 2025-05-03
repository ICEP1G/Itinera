using Itinera.Client.ViewModels.Pages;

namespace Itinera.Client.Views.Components;

public partial class UpdateAccount : ContentView
{
	public UpdateAccount(UpdateAccountViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}