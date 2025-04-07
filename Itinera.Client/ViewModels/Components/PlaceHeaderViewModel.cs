using Itinera.Client.Helpers;
using Itinera.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Itinera.Client.Helpers.PlaceHelper;

namespace Itinera.Client.ViewModels.Components
{
    public class PlaceHeaderViewModel : INotifyPropertyChanged
    {
        #region Variables declaration
        public event PropertyChangedEventHandler? PropertyChanged;
        private PlaceHeaderDto place;

        private SolidColorBrush chipsBorderStrokeColor;
        private Color chipsLabelTextColor;
        private string chipsLabelText;
        #endregion

        public PlaceHeaderViewModel()
        {
        }


        public PlaceHeaderDto Place
        {
            get { return place; }
            set { place = value; UpdatePlaceScheduleStatus(); OnPropertyChanged(nameof(Place)); }
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
        private void UpdatePlaceScheduleStatus()
        {
            PlaceScheduleStatus placeSchedulesStatus = GetPlaceScheduleStatus(Place.TodaySchedules);
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



        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
