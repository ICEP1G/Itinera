using Itinera.Client.Helpers;
using Itinera.Client.ViewModels.Components;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;

namespace Itinera.Client.Views.Components;

public partial class TabMenu : ContentView
{

    public TabMenu()
	{
		InitializeComponent();
    }


    protected override void OnParentChanged()
    {
        base.OnParentChanged();

        if (Parent is null)
        {
            if (BindingContext is TabMenuViewModel viewModel)
            {
                viewModel.Dispose();
            }
        }
    }

}