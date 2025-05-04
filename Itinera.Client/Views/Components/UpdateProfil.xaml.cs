using Itinera.Client.ViewModels.Pages;

namespace Itinera.Client.Views.Components;

public partial class UpdateProfil : ContentView
{
	public UpdateProfil(ProfilPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}