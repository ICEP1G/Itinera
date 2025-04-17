using CommunityToolkit.Maui.Behaviors;
using Itinera.Client.Helpers;
using Microsoft.Maui.ApplicationModel.DataTransfer;

namespace Itinera.Client.Views.Components;

public partial class GeneralSearch : ContentView
{
	public GeneralSearch()
	{
		InitializeComponent();
	}


	private bool withNoBackground;
	public bool WithNoBackground
	{
		get { return withNoBackground; }
        set
        { 
			withNoBackground = value;
            if (withNoBackground is true)
            {
                UpdateComponentStyle();
            }
        }
	}


	private void UpdateComponentStyle()
	{
		this.MainContainer.HeightRequest = 80;
		this.MainContainer.BackgroundColor = Color.FromRgba(0, 0, 0, 0);
		this.filtersIcon.Behaviors.Add(new IconTintColorBehavior() { TintColor = ResourceHelper.GetColor("Secondary") });
		this.SearchGridCtn.Shadow = new Shadow() { Radius = 8, Opacity = 0.13f, Offset = new Point(1, 2) };
    }

}