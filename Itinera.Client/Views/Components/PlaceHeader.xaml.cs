using Itinera.Client.ViewModels.Components;
using Itinera.DTOs;
using System.Runtime.CompilerServices;

namespace Itinera.Client.Views.Components;

public partial class PlaceHeader : ContentView
{
    /// <summary>
    /// Used when passing the context from another ContentPage or ContentView
    /// </summary>
    public PlaceHeader()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Only used it if this ContentView is independant from another ContentPage or ContentView
    /// </summary>
    /// <param name="viewModel"></param>
    public PlaceHeader(PlaceHeaderViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

}