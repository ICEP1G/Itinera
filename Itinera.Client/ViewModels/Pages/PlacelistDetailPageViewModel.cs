using CommunityToolkit.Maui.Core.Extensions;
using CSharpFunctionalExtensions;
using Itinera.Client.Helpers;
using Itinera.Client.Models;
using Itinera.Client.Services;
using Itinera.Client.ViewModels.Components;
using Itinera.Client.Views.Pages;
using Itinera.DTOs;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Itinera.Client.ViewModels.Pages
{
    [QueryProperty(nameof(PlacelistId), "PlacelistId")]
    public class PlacelistDetailPageViewModel : INotifyPropertyChanged
    {
        #region NotifyChanges declaration
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Variables declaration
        private readonly IPlacelistService _placelistService;
        private readonly IPlaceService _placeService;

        private string placelistId;
        private string name;
        private string description;
        private string imageUrl;
        private int recommendationCount;
        private bool isFavorite;
        private string itinerosOwnerId;
        private string itinerosOwnerUserName;
        private string itinerosOwnerPictureUrl;
        private bool isRecommendedByCurrentUser;
        private bool isFollowedByCurrentUser;
        private ObservableCollection<PlaceHeaderViewModel> places;
        private bool isItinerosOwnedPlacelist;

        private bool isLoadingPlacelist;
        private bool isLoadingPlaceHeaders;
        private string errorLoadingPlacelistContentPageData;
        private string errorLoadingPlaceHeadersData;
        #endregion

        #region Commands declaration
        public ICommand GoBackCommand { get; }
        public ICommand AddPlaceCommand { get; }
        public ICommand EditPlacelistCommand { get; }
        public ICommand DeletePlaceCommand { get; }
        public ICommand UpdatePlacelistRecommandationCommand { get; }
        public ICommand UpdatePlacelistFollowCommand { get; }
        public ICommand GoToOwnerItinerosPage { get; }
        #endregion

        public PlacelistDetailPageViewModel(IPlacelistService placelistService, IPlaceService placeService)
        {
            _placelistService = placelistService;
            _placeService = placeService;

            Places = new();

            GoBackCommand = new Command(async () => await AppShell.Current.GoToAsync("..", true));
            UpdatePlacelistRecommandationCommand = new Command(async () => await UpdatePlacelistRecommandation());
            UpdatePlacelistFollowCommand = new Command(async () => await UpdatePlacelistFollow());
            GoToOwnerItinerosPage = new Command(async () => await AppShell.Current.GoToAsync($"{nameof(ItinerosPage)}", true, 
                new ShellNavigationQueryParameters { { "ItinerosId", ItinerosOwnerId } }));
        }


        public string PlacelistId
        {
            get { return placelistId; }
            set { placelistId = value; OnPropertyChanged(nameof(PlacelistId)); }
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

        public string ItinerosOwnerId
        {
            get { return itinerosOwnerId; }
            set { itinerosOwnerId = value; OnPropertyChanged(nameof(ItinerosOwnerId)); }
        }

        public string ItinerosOwnerUserName
        {
            get { return itinerosOwnerUserName; }
            set { itinerosOwnerUserName = value; OnPropertyChanged(nameof(ItinerosOwnerUserName)); }
        }

        public string ItinerosOwnerPictureUrl
        {
            get { return itinerosOwnerPictureUrl; }
            set { itinerosOwnerPictureUrl = value; OnPropertyChanged(nameof(ItinerosOwnerPictureUrl)); }
        }

        public bool IsRecommendedByCurrentUser
        {
            get { return isRecommendedByCurrentUser; }
            set { isRecommendedByCurrentUser = value; OnPropertyChanged(nameof(IsRecommendedByCurrentUser)); }
        }

        public bool IsFollowedByCurrentUser
        {
            get { return isFollowedByCurrentUser; }
            set { isFollowedByCurrentUser = value; OnPropertyChanged(nameof(IsFollowedByCurrentUser)); }
        }

        public ObservableCollection<PlaceHeaderViewModel> Places
        {
            get { return places; }
            set { places = value; OnPropertyChanged(nameof(Places)); }
        }

        public bool IsItinerosOwnedPlacelist
        {
            get { return isItinerosOwnedPlacelist; }
            set { isItinerosOwnedPlacelist = value; OnPropertyChanged(nameof(IsItinerosOwnedPlacelist)); }
        }

        #region Functional properties
        public bool IsLoadingPlacelist
        {
            get { return isLoadingPlacelist; }
            set { isLoadingPlacelist = value; OnPropertyChanged(nameof(IsLoadingPlacelist)); }
        }

        public bool IsLoadingPlaceHeaders
        {
            get { return isLoadingPlaceHeaders; }
            set { isLoadingPlaceHeaders = value; OnPropertyChanged(nameof(IsLoadingPlaceHeaders)); }
        }

        public string ErrorLoadingPlacelistContentPageData
        {
            get { return errorLoadingPlacelistContentPageData; }
            set { errorLoadingPlacelistContentPageData = value; OnPropertyChanged(nameof(ErrorLoadingPlacelistContentPageData)); }
        }

        public string ErrorLoadingPlaceHeadersData
        {
            get { return errorLoadingPlaceHeadersData; }
            set { errorLoadingPlaceHeadersData = value; OnPropertyChanged(nameof(ErrorLoadingPlaceHeadersData)); }
        }

        #endregion



        private async Task UpdatePlacelistRecommandation()
        {
            bool isRecommanded = !this.IsRecommendedByCurrentUser;
            IsRecommendedByCurrentUser = isRecommanded;
            await _placelistService.UpdatePlacelistRecommandation(PlacelistId, CurrentItinerosSession.CurrentItinerosId, isRecommanded);
        }

        private async Task UpdatePlacelistFollow()
        {
            bool isFollowing = !this.IsFollowedByCurrentUser;
            IsFollowedByCurrentUser = isFollowing;
            await _placelistService.UpdatePlacelistFollow(PlacelistId, CurrentItinerosSession.CurrentItinerosId, isFollowing);
        }


        public async Task LoadDataAsync()
        {
            string? currentItinerosId = CurrentItinerosSession.CurrentItinerosId;
            if (!string.IsNullOrEmpty(currentItinerosId))
            {
                IsLoadingPlacelist = true;
                Result<PlacelistContentDto> placelistContent = await _placelistService.GetPlacelistContent(PlacelistId, currentItinerosId);
                if (placelistContent.IsFailure)
                {
                    ErrorLoadingPlacelistContentPageData = "An error occurred during the Placelist retrieval process. Please come back later.";
                    IsLoadingPlacelist = false;
                }
                else
                {
                    this.Name = placelistContent.Value.Name;
                    this.Description = placelistContent.Value.Description;
                    this.ImageUrl = placelistContent.Value.ImageUrl;
                    this.RecommendationCount = placelistContent.Value.RecommendationsCount;
                    this.ItinerosOwnerId = placelistContent.Value.ItinerosOwnerId;
                    this.ItinerosOwnerUserName = placelistContent.Value.ItinerosOwnerUsername;
                    this.ItinerosOwnerPictureUrl = placelistContent.Value.ItinerosOwnerPictureUrl;
                    this.IsRecommendedByCurrentUser = placelistContent.Value.IsRecommandedByCurrentUser;
                    this.IsFollowedByCurrentUser = placelistContent.Value.IsFollowedByCurrentUser;
                    this.IsItinerosOwnedPlacelist = CurrentItinerosSession.CurrentItinerosId == placelistContent.Value.ItinerosOwnerId ? true : false;

                    IsLoadingPlacelist = false;
                    LoadPlaceHeadersAsync(placelistContent.Value.PlaceHeaders);
                }
            }
        }

        private async Task LoadPlaceHeadersAsync(IEnumerable<PlaceHeaderDto> placeHeaders)
        {
            IsLoadingPlaceHeaders = true;
            Result<List<PlaceHeaderViewModel>> placeHeaderVMs = await _placeService.GetPlaceHeaderViewModels(placeHeaders);
            if (placeHeaderVMs.IsFailure)
            {
                ErrorLoadingPlaceHeadersData = "it's impossible to view the places for this placelist at the moment. Please come back later.";
            }
            else
            {
                Places = placeHeaderVMs.Value.ToObservableCollection();
            }
            IsLoadingPlaceHeaders = false;
        }

    }
}
