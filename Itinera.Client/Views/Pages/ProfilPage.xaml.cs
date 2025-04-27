using Itinera.Client.ViewModels.Pages;

namespace Itinera.Client;

public partial class ProfilPage : ContentPage
{
	public ProfilPage(ProfilPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is ProfilPageViewModel vm)
        {
            vm.SetRandomGreeting();
        }
    }

}