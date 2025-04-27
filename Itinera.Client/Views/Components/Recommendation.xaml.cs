using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Extensions;
using Itinera.Client.Helpers;
using Itinera.Client.ViewModels.Components;
using Itinera.DTOs;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Itinera.Client.Views.Components;

public partial class Recommendation : ContentView
{
    #region Variables declaration
    private bool? isDark;
    private bool? dropShadow;
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


    public bool? IsDark
    {
        get { return isDark; }
        set 
        { 
            isDark = value;
            if (isDark is not null && isDark is true)
            {
                UpdateTintColor();
            }
        }
    }

    public bool? DropShadow
    {
        get { return dropShadow; }
        set
        {
            dropShadow = value;
            if (dropShadow is not null && dropShadow is true)
            {
                AddDropShadow();
            }
        }
    }


    public RecommendationSize Size
    {
        get => size;
        set { size = value; UpdateSize(value); }
    }


    /// <summary>
    /// Allow to change some properties in the component himself in order to look differently based on the Size property
    /// </summary>
    private void UpdateSize(RecommendationSize size)
    {
        switch (size)
        {
            case RecommendationSize.Mini:
                this.MainContainer.HeightRequest = 24;
                this.MainContainer.Margin = new Thickness(0, 0, 5, 0);
                this.RecommendationIcon.HeightRequest = 24;
                this.RecommendationIcon.WidthRequest = 24;
                this.BorderContainer.Margin = new Thickness(-5, 0);
                this.LabelCount.Margin = new Thickness(4, 0, 4, 1);
                break;
            case RecommendationSize.Normal:
                this.MainContainer.HeightRequest = 30;
                this.MainContainer.Margin = new Thickness(0, 0, 5, 0);
                this.RecommendationIcon.HeightRequest = 30;
                this.RecommendationIcon.WidthRequest = 30;
                this.BorderContainer.Margin = new Thickness(-5, 0);
                this.LabelCount.Margin = new Thickness(4, 0, 4, 1);
                break;
        }
    }

    private void UpdateTintColor()
    {
        this.RecommendationIcon.Behaviors.Add(new IconTintColorBehavior() { TintColor = ResourceHelper.GetColor("Taupe500") });
    }

    private void AddDropShadow()
    {
        this.MainContainer.Shadow = new Shadow() { Radius = 4, Opacity = 0.5f, Offset = new Point(0, 4) };
    }


}