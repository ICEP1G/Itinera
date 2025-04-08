using Itinera.Client.ViewModels.Components;
using Itinera.DTOs;
using System.Runtime.CompilerServices;

namespace Itinera.Client.Views.Components;

public partial class PlaceHeader : ContentView
{
    public PlaceHeader()
	{
		InitializeComponent();
        BindingContext = new PlaceHeaderViewModel();
    }

}