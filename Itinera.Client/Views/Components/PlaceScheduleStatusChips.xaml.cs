using Itinera.Client.Helpers;
using Itinera.Client.Models;
using Itinera.Client.Services;

namespace Itinera.Client.Views.Components;

public partial class PlaceScheduleStatusChips : ContentView
{
    public static readonly BindableProperty TodaySchedulesProperty =
    BindableProperty.Create(nameof(TodaySchedules), typeof(string), typeof(PlaceScheduleStatusChips), default(string), propertyChanged: OnTodaySchedulesChanged);

    private static void OnTodaySchedulesChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is PlaceScheduleStatusChips view)
        {
            view.TodaySchedules = (string)newValue;
            view.UpdatePlaceScheduleStatus(view.TodaySchedules);
        }
    }

    private readonly IPlaceService _placeService;
    public PlaceScheduleStatusChips()
	{
		InitializeComponent();
        _placeService = ServiceProviderHelper.GetService<IPlaceService>();
    }


    public string TodaySchedules
    {
        get => (string)GetValue(TodaySchedulesProperty);
        set => SetValue(TodaySchedulesProperty, value);
    }


    /// <summary>
    /// Allow to change the style of the chips which represent if a Place is open or not
    /// </summary>
    private void UpdatePlaceScheduleStatus(string todaySchedules)
    {
        PlaceScheduleStatus placeSchedulesStatus = _placeService.GetPlaceScheduleStatus(todaySchedules, DateTime.Now);
        switch (placeSchedulesStatus)
        {
            case PlaceScheduleStatus.Open:
                Color greenColor = ResourceHelper.GetColor("Green");
                this.ChipsBorder.Stroke = new SolidColorBrush(greenColor);
                this.ChipsLabel.TextColor = greenColor;
                this.ChipsLabel.Text = "Open";
                break;
            case PlaceScheduleStatus.OpenSoon:
                Color orangeColor = ResourceHelper.GetColor("Orange");
                this.ChipsBorder.Stroke = new SolidColorBrush(orangeColor);
                this.ChipsLabel.TextColor = orangeColor;
                this.ChipsLabel.Text = "Open soon";
                break;
            case PlaceScheduleStatus.CloseSoon:
                Color orangeColorAgain = ResourceHelper.GetColor("Orange");
                this.ChipsBorder.Stroke = new SolidColorBrush(orangeColorAgain);
                this.ChipsLabel.TextColor = orangeColorAgain;
                this.ChipsLabel.Text = "Close soon";
                break;
            case PlaceScheduleStatus.Closed:
                Color redColor = ResourceHelper.GetColor("Red");
                this.ChipsBorder.Stroke = new SolidColorBrush(redColor);
                this.ChipsLabel.TextColor = redColor;
                this.ChipsLabel.Text = "Closed";
                break;
            default:
                break;
        }
    }
}