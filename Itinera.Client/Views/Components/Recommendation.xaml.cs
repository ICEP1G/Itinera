using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Itinera.Client.Views.Components;

public partial class Recommendation : ContentView, INotifyPropertyChanged
{
    #region Variables declaration
    public event PropertyChangedEventHandler? PropertyChanged;
    private int recommendationCount;
    private RecommendationSize size;
    public enum RecommendationSize
    {
        Mini,
        Normal
    }
    #endregion

    public Recommendation()
	{
		InitializeComponent();
        BindingContext = this;
	}


    public int RecommendationCount
	{
		get { return recommendationCount; }
		set { recommendationCount = value; OnPropertyChanged(nameof(RecommendationCount)); }
	}

    public RecommendationSize Size
    {
        get => size;
        set { size = value; UpdateSize(); OnPropertyChanged(nameof(Size)); }
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
                this.FlexCountCtn.Padding = new Thickness(6, 3);
                break;
            case RecommendationSize.Normal:
                this.MainContainer.Margin = new Thickness(0, 0, 3, 0);
                this.AbsoluteContainer.Margin = new Thickness(-3, 0);
                this.RecommendationIcon.HeightRequest = 30;
                this.RecommendationIcon.WidthRequest = 30;
                this.FlexCountCtn.Padding = new Thickness(7, 4);
                break;
        }
    }



    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}