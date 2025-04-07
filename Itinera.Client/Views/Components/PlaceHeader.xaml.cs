using Itinera.Client.Helpers;
using Itinera.Client.ViewModels.Components;
using Itinera.DTOs;
using System.ComponentModel;
using static Itinera.Client.Helpers.PlaceHelper;

namespace Itinera.Client.Views.Components;

public partial class PlaceHeader : ContentView
{
    #region Bindables Properties
    public static readonly BindableProperty PlaceHeaderVMProperty =
        BindableProperty.Create(nameof(PlaceHeaderVM), typeof(PlaceHeaderViewModel), typeof(PlaceHeader), null, propertyChanged: OnViewModelChanged);
    #endregion

    public PlaceHeader()
	{
		InitializeComponent();
        BindingContext = new PlaceHeaderViewModel();
    }


    public PlaceHeaderViewModel PlaceHeaderVM
    {
        get => (PlaceHeaderViewModel)GetValue(PlaceHeaderVMProperty);
        set { SetValue(PlaceHeaderVMProperty, value); }
    }


    private static void OnViewModelChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = (PlaceHeader)bindable;
        view.BindingContext = (PlaceHeaderViewModel)newValue;
    }
}