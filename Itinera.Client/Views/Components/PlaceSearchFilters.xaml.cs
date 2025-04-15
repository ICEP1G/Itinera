using Itinera.Client.ViewModels.Components;

namespace Itinera.Client.Views.Components;

public partial class PlaceSearchFilters : ContentView
{

	public PlaceSearchFilters()
	{
		InitializeComponent();
	}


    protected override void OnParentChanged()
    {
        base.OnParentChanged();

        if (Parent is null)
        {
            if (BindingContext is PlaceSearchFiltersViewModel viewModel)
            {
                viewModel.Dispose();
            }
        }
    }
}