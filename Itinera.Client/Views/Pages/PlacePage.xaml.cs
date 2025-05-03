using Itinera.Client.Helpers;
using Itinera.Client.Models;
using Itinera.Client.ViewModels;

namespace Itinera.Client.Views.Pages;

public partial class PlacePage : ContentPage
{
    private readonly PlacePageViewModel _viewModel;
    private bool nextOrActualScheduleAlreadySet;

    public PlacePage(PlacePageViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadDataAsync();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        if (BindingContext is PlacePageViewModel viewModel)
        {
            viewModel.Dispose();
        }
    }


    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e) => nextOrActualScheduleAlreadySet = false;
    private void LabelSchedule_Loaded(object sender, EventArgs e)
    {
        if (sender is Label label && label.BindingContext is string schedule)
        {
            // Récupérer l'élément parent (Grid) pour obtenir la valeur de Day
            if (label.Parent is HorizontalStackLayout stackLayout && stackLayout.Parent is Grid grid)
            {
                if (grid.BindingContext is ScheduleItem scheduleItem)
                {
                    string day = scheduleItem.Day;
                    if (!nextOrActualScheduleAlreadySet)
                    {
                        bool isOpenOrNextOpenSchedule = GetPlaceScheduleStatus(day, schedule, DateTime.Now);
                        if (day == "Today")
                        {
                            if (scheduleItem.Schedules.Any(s => s == "Closed"))
                                label.TextColor = ResourceHelper.GetColor("Primary");

                            if (isOpenOrNextOpenSchedule)
                            {
                                label.TextColor = ResourceHelper.GetColor("Primary");
                                nextOrActualScheduleAlreadySet = true;
                            }
                            else
                                label.TextColor = ResourceHelper.GetColor("Tertiary");
                        }
                        else
                        {
                            label.TextColor = ResourceHelper.GetColor("Tertiary");
                        }
                    }
                    else
                    {
                        label.TextColor = ResourceHelper.GetColor("Tertiary");
                    }
                }
            }
        }
    }

    public bool GetPlaceScheduleStatus(string day, string daySchedules, DateTime actualDateTime)
    {
        try
        {
            TimeSpan currentTime = actualDateTime.TimeOfDay;
            TimeSpan? nextOpeningTime = null;

            string[] times = DateHelper.GetDaySchedules(daySchedules);
            if (times.Length != 2)
                throw new Exception("Schedule range is less or more than 2;");

            string startTimeStr = times[0].Trim();
            string endTimeStr = times[1].Trim();

            if (day == "Today")
            {
                if (TimeSpan.TryParse(startTimeStr, out TimeSpan startTime) && TimeSpan.TryParse(endTimeStr, out TimeSpan endTime))
                {
                    if (currentTime >= startTime && currentTime <= endTime)
                        return true;

                    // Check if this is the next opening time
                    if (startTime > currentTime && (nextOpeningTime == null || startTime < nextOpeningTime))
                        nextOpeningTime = startTime;

                    // Check if there is a next opening time soon
                    if (nextOpeningTime.HasValue)
                        return true;
                }
            }
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

}