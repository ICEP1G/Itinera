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
        #region NotifyChanges declaration
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Variables declaration
        private readonly PlaceService _placeService;

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


        public PlaceHeaderViewModel(PlaceService placeService)
        {
            _placeService = placeService;

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
                IconUri = _placeService.GetCorrectPlaceIconUri(value).IconUri;
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
            PlaceScheduleStatus placeSchedulesStatus = _placeService.GetPlaceScheduleStatus(todaySchedules, DateTime.Now);
            switch (placeSchedulesStatus)
            {
                case PlaceScheduleStatus.Open:
                    Color greenColor = ResourceHelper.GetColor("Green");
                    ChipsBorderStrokeColor = new SolidColorBrush(greenColor);
                    ChipsLabelTextColor = greenColor;
                    ChipsLabelText = "Open";
                    break;
                case PlaceScheduleStatus.OpenSoon:
                    Color orangeColor = ResourceHelper.GetColor("Orange");
                    ChipsBorderStrokeColor = new SolidColorBrush((Color)orangeColor);
                    ChipsLabelTextColor = (Color)orangeColor;
                    ChipsLabelText = "Open soon";
                    break;
                case PlaceScheduleStatus.CloseSoon:
                    Color orangeColorAgain = ResourceHelper.GetColor("Orange");
                    ChipsBorderStrokeColor = new SolidColorBrush(orangeColorAgain);
                    ChipsLabelTextColor = orangeColorAgain;
                    ChipsLabelText = "Close soon";
                    break;
                case PlaceScheduleStatus.Closed:
                    Color redColor = ResourceHelper.GetColor("Red");
                    ChipsBorderStrokeColor = new SolidColorBrush(redColor);
                    ChipsLabelTextColor = redColor;
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

    }
}
