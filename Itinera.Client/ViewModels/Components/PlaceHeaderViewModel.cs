using Itinera.Client.Helpers;
using Itinera.Client.Models;
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
        private readonly IPlaceService _placeService;

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


        public PlaceHeaderViewModel(IPlaceService placeService)
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
            set { todaySchedules = value; OnPropertyChanged(nameof(TodaySchedules)); }
        }

        public string IconUri
        {
            get { return iconUri; }
            set { iconUri = value; OnPropertyChanged(nameof(IconUri)); }
        }



        private async Task NavigateToPlacePage()
        {
            await AppShell.Current.GoToAsync($"{nameof(PlacePage)}", new ShellNavigationQueryParameters { { "PlaceId", Id } });
        }

    }
}
