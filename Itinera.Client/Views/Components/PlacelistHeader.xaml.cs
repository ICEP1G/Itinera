using Itinera.Client.ViewModels.Components;

namespace Itinera.Client.Views.Components;

public partial class PlacelistHeader : ContentView
{
	public PlacelistHeader()
	{
		InitializeComponent();
	}

    public PlacelistHeader(PlacelistHeaderViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}