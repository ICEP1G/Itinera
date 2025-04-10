using Itinera.Client.ViewModels.Components;
using Itinera.DTOs;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Itinera.Client.Views.Components;

public partial class Recommendation : ContentView
{
    #region Variables declaration
    private RecommendationSize size;
    public enum RecommendationSize
    {
        Mini,
        Normal
    }
    #endregion

    public static readonly BindableProperty RecommendationCountProperty =
        BindableProperty.Create(nameof(RecommendationCount), typeof(int), typeof(Recommendation), default(string));

    public Recommendation()
    {
        InitializeComponent();
    }


    public int RecommendationCount
    {
        get => (int)GetValue(RecommendationCountProperty);
        set => SetValue(RecommendationCountProperty, value);
    }


    public RecommendationSize Size
    {
        get => size;
        set { size = value; UpdateSize(); }
    }

    /// <summary>
    /// Allow to change some properties in the component himself in order to look differently based on the Size property
    /// </summary>
    private void UpdateSize()
    {
        switch (Size)
        {
            case RecommendationSize.Mini:
                this.MainContainer.Margin = new Thickness(0, 0, 2, 0);
                this.AbsoluteContainer.Margin = new Thickness(-2, 0);
                this.RecommendationIcon.HeightRequest = 24;
                this.RecommendationIcon.WidthRequest = 24;
                this.FlexCountCtn.Padding = new Thickness(5, 4);
                break;
            case RecommendationSize.Normal:
                this.MainContainer.Margin = new Thickness(0, 0, 3, 0);
                this.AbsoluteContainer.Margin = new Thickness(-3, 0);
                this.RecommendationIcon.HeightRequest = 30;
                this.RecommendationIcon.WidthRequest = 30;
                this.FlexCountCtn.Padding = new Thickness(6, 5);
                break;
        }
    }


}