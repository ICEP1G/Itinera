using CommunityToolkit.Maui.Core.Extensions;
using Itinera.Client.Helpers;
using Itinera.Client.Services;
using Itinera.Client.Views.Pages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Itinera.Client.ViewModels.Components
{
    public class PlacelistHeaderViewModel : INotifyPropertyChanged
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
        private string description;
        private string imageUrl;
        private HashSet<string> placesPrimaryTypes;
        private List<string> placeIconUris;
        private int recommendationCount;
        private bool isFavorite;
        #endregion

        #region Commands declaration
        public ICommand NavigateToPlacelist { get; }
        #endregion

        public PlacelistHeaderViewModel(PlaceService placeService)
        {
            _placeService = placeService;

            NavigateToPlacelist = new Command(async () => await NavigateToPlacelistPage());
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

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(nameof(Description)); }
        }

        public string ImageUrl
        {
            get { return imageUrl; }
            set { imageUrl = value; OnPropertyChanged(nameof(ImageUrl)); }
        }

        public HashSet<string> PlacesPrimaryTypes
        {
            get { return placesPrimaryTypes; }
            set 
            { 
                placesPrimaryTypes = value; 
                PlaceIconUris = _placeService.GetCorrectPlaceIconUris(value); 
                OnPropertyChanged(nameof(PlacesPrimaryTypes)); 
            }
        }

        public List<string> PlaceIconUris
        {
            get { return placeIconUris; }
            set 
            {
                placeIconUris = UpdateElementsIfNeeded(value);
                OnPropertyChanged(nameof(PlaceIconUris)); 
            }
        }


        public int RecommendationCount
        {
            get { return recommendationCount; }
            set 
            { 
                recommendationCount = value;
                if (value >= FavoriteHelper.PlacelistFavoriteThreshold)
                {
                    IsFavorite = true;
                }
                OnPropertyChanged(nameof(RecommendationCount)); 
            }
        }

        public bool IsFavorite
        {
            get { return isFavorite; }
            set { isFavorite = value; OnPropertyChanged(nameof(IsFavorite)); }
        }


        private List<string> UpdateElementsIfNeeded(List<string> iconUris)
        {
            if (iconUris.Count > 4)
            {
                List<string> updatedIconUris = iconUris.Take(4).ToList();
                updatedIconUris.Add("dots_icon.png");

                return updatedIconUris;
            }
            return iconUris;
        }


        private async Task NavigateToPlacelistPage()
        {
            await AppShell.Current.GoToAsync($"{nameof(PlacelistPage)}", new ShellNavigationQueryParameters { { "PlacelistId", Id } });
        }
    }
}
