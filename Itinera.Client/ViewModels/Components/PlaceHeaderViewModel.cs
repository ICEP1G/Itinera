using Itinera.Client.Helpers;
using Itinera.Client.Services;
using Itinera.Client.Views.Pages;
using Itinera.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Itinera.Client.Services.PlaceService;

namespace Itinera.Client.ViewModels.Components
{
    public class PlaceHeaderViewModel : INotifyPropertyChanged
    {
        #region Variables declaration
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly PlaceService _placeHelper;

        private string id;
        private string name;
        private string address;
        private string primaryType;
        private string primaryImageUrl;
        private string? todaySchedules;
        private string iconUri;

        private SolidColorBrush chipsBorderStrokeColor;
        private Color chipsLabelTextColor;
        private string chipsLabelText;
        #endregion

        #region Commands declaration
        public ICommand NavigateToPlace { get; }
        #endregion


        public PlaceHeaderViewModel(PlaceService placeHelper)
        {
            _placeHelper = placeHelper;

            NavigateToPlace = new Command(async () => await NavigateToPlacePage());
        }


        public string Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(nameof(Id)); }
        }


        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged(nameof(Address)); }
        }

        public string PrimaryType
        {
            get { return primaryType; }
            set 
            { 
                primaryType = value;
                IconUri = _placeHelper.GetCorrectPlaceIconUri(value).IconUri;
                OnPropertyChanged(nameof(PrimaryType)); 
            }
        }

        public string PrimaryImageUrl
        {
            get { return primaryImageUrl; }
            set { primaryImageUrl = value; OnPropertyChanged(nameof(PrimaryImageUrl)); }
        }

        public string? TodaySchedules
        {
            get { return todaySchedules; }
            set { todaySchedules = value; UpdatePlaceScheduleStatus(value); }
        }


        public string IconUri
        {
            get { return iconUri; }
            set { iconUri = value; OnPropertyChanged(nameof(IconUri)); }
        }


        #region UI elements properties
        public SolidColorBrush ChipsBorderStrokeColor
        {
            get => chipsBorderStrokeColor;
            set { chipsBorderStrokeColor = value; OnPropertyChanged(nameof(ChipsBorderStrokeColor)); }
        }

        public Color ChipsLabelTextColor
        {
            get => chipsLabelTextColor;
            set { chipsLabelTextColor = value; OnPropertyChanged(nameof(ChipsLabelTextColor)); }
        }

        public string ChipsLabelText
        {
            get => chipsLabelText;
            set { chipsLabelText = value; OnPropertyChanged(nameof(ChipsLabelText)); }
        }
        #endregion


        /// <summary>
        /// Allow to change the style of the chips which is the representation if a Place is open or not
        /// </summary>
        private void UpdatePlaceScheduleStatus(string todaySchedules)
        {
            PlaceScheduleStatus placeSchedulesStatus = _placeHelper.GetPlaceScheduleStatus(todaySchedules, DateTime.Now);
            switch (placeSchedulesStatus)
            {
                case PlaceScheduleStatus.Open:
                    if (Application.Current.Resources.TryGetValue("Green", out var greenColor))
                    {
                        ChipsBorderStrokeColor = new SolidColorBrush((Color)greenColor);
                        ChipsLabelTextColor = (Color)greenColor;
                    }
                    ChipsLabelText = "Open";
                    break;
                case PlaceScheduleStatus.OpenSoon:
                    if (Application.Current.Resources.TryGetValue("Orange", out var orangeColor))
                    {
                        ChipsBorderStrokeColor = new SolidColorBrush((Color)orangeColor);
                        ChipsLabelTextColor = (Color)orangeColor;
                    }
                    ChipsLabelText = "Open soon";
                    break;
                case PlaceScheduleStatus.CloseSoon:
                    if (Application.Current.Resources.TryGetValue("Orange", out var orangeAgainColor))
                    {
                        ChipsBorderStrokeColor = new SolidColorBrush((Color)orangeAgainColor);
                        ChipsLabelTextColor = (Color)orangeAgainColor;
                    }
                    ChipsLabelText = "Close soon";
                    break;
                case PlaceScheduleStatus.Closed:
                    if (Application.Current.Resources.TryGetValue("Red", out var redColor))
                    {
                        ChipsBorderStrokeColor = new SolidColorBrush((Color)redColor);
                        ChipsLabelTextColor = (Color)redColor;
                    }
                    ChipsLabelText = "Closed";
                    break;
                default:
                    break;
            }
        }


        private async Task NavigateToPlacePage()
        {
            await AppShell.Current.GoToAsync($"{nameof(PlacePage)}", new ShellNavigationQueryParameters { { "PlaceId", Id } });
        }



        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
