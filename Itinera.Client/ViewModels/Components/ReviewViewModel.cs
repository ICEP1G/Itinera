using Itinera.Client.Services;
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
    public class ReviewViewModel : INotifyPropertyChanged
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

        private string reviewId;
        private string message;
        private string? imageUrl;
        private DateTime lastModificationDate;
        private string itinerosId;
        private string itinerosFirstName;
        private string? itinerosCity;
        private string? itinerosProfilPictureUrl;
        private string placeId;
        private string placeName;
        private string placeType;
        private string placeIconUri;
        private string placeCity;
        private string? placeFirstPictureUrl;
        private bool isViewedFromItinerosPage;
        private bool isViewedFromPlacePage;
        private bool isEven;
        private bool isBackgroundDarker;
        #endregion

        #region Commands declaration
        #endregion

        public ReviewViewModel(PlaceService placeService)
        {
            _placeService = placeService;
        }


        public string ReviewId
        {
            get { return reviewId; }
            set { reviewId = value; OnPropertyChanged(nameof(reviewId)); }
        }

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged(nameof(Message)); }
        }

        public string? ImageUrl
        {
            get { return imageUrl; }
            set { imageUrl = value; OnPropertyChanged(nameof(ImageUrl)); }
        }

        public DateTime LastModificationDate
        {
            get { return lastModificationDate; }
            set { lastModificationDate = value; OnPropertyChanged(nameof(LastModificationDate)); }
        }

        public string ItinerosId
        {
            get { return itinerosId; }
            set { itinerosId = value; OnPropertyChanged(nameof(ItinerosId)); }
        }

        public string ItinerosFirstName
        {
            get { return itinerosFirstName; }
            set { itinerosFirstName = value; OnPropertyChanged(nameof(ItinerosFirstName)); }
        }

        public string? ItinerosCity
        {
            get { return itinerosCity; }
            set { itinerosCity = value; OnPropertyChanged(nameof(ItinerosCity)); }
        }

        public string? ItinerosProfilPictureUrl
        {
            get { return itinerosProfilPictureUrl; }
            set { itinerosProfilPictureUrl = value; OnPropertyChanged(nameof(ItinerosProfilPictureUrl)); }
        }

        public string PlaceId
        {
            get { return placeId; }
            set { placeId = value; OnPropertyChanged(nameof(PlaceId)); }
        }

        public string PlaceName
        {
            get { return placeName; }
            set { placeName = value; OnPropertyChanged(nameof(PlaceName)); }
        }

        public string PlaceType
        {
            get { return placeType; }
            set 
            { 
                placeType = value;
                PlaceIconUri = _placeService.GetCorrectPlaceIconUri(value).IconUri;
                OnPropertyChanged(nameof(PlaceType)); 
            }
        }

        public string PlaceIconUri
        {
            get { return placeIconUri; }
            set { placeIconUri = value; OnPropertyChanged(nameof(PlaceIconUri)); }
        }

        public string PlaceCity
        {
            get { return placeCity; }
            set { placeCity = value; OnPropertyChanged(nameof(PlaceCity)); }
        }

        public string? PlaceFirstPictureUrl
        {
            get { return placeFirstPictureUrl; }
            set { placeFirstPictureUrl = value; OnPropertyChanged(nameof(PlaceFirstPictureUrl)); }
        }


        #region Style trigger properties
        public bool IsViewedFromItinerosPage
        {
            get { return isViewedFromItinerosPage; }
            set { isViewedFromItinerosPage = value; OnPropertyChanged(nameof(IsViewedFromItinerosPage)); }
        }

        public bool IsViewedFromPlacePage
        {
            get { return isViewedFromPlacePage; }
            set { isViewedFromPlacePage = value; OnPropertyChanged(nameof(IsViewedFromPlacePage)); }
        }

        public bool IsEven
        {
            get { return isEven; }
            set { isEven = value; OnPropertyChanged(nameof(IsEven)); }
        }

        public bool IsBackgroundDarker
        {
            get { return isBackgroundDarker; }
            set { isBackgroundDarker = value; OnPropertyChanged(nameof(IsBackgroundDarker)); }
        }
        #endregion

    }
}
