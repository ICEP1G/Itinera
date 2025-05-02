using CSharpFunctionalExtensions;
using Itinera.Client.Helpers;
using Itinera.Client.Models;
using Itinera.Client.Services;
using Itinera.Client.ViewModels.Components;
using Itinera.DTOs;
using Itinera.DTOs.Itineros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Itinera.Client.ViewModels.Pages
{
    [QueryProperty(nameof(ItinerosId), "ItinerosId")]
    public class ItinerosPageViewModel : INotifyPropertyChanged, IDisposable
    {
        #region NotifyChanges declaration
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Variables declaration
        private readonly IItinerosService _itinerosService;
        private readonly IPlacelistService _placelistService;
        private readonly IReviewService _reviewService;

        private string itinerosId;
        private string firstName;
        private string username;
        private string? country;
        private string? city;
        private string? description;
        private string? profilPictureUrl;
        private string? instagramLink;
        private int recommendationCount;
        private bool isFavorite;
        private int reviewCount;
        private bool isFollowedByCurrentUser;
        private bool isRecommendedByCurrentUser;
        private IEnumerable<PlacelistHeaderViewModel> placelistHeaders;
        private IEnumerable<ReviewViewModel> reviews;

        private TabMenuViewModel tabMenu;

        private bool isLoadingItineros;
        private bool isLoadingPlacelists;
        private bool isLoadingReviews;
        private string errorLoadingItinerosData;
        private string errorLoadingPlacelistsData;
        private string errorLoadingReviewsData;
        private bool isPlacelistsTabSelected;
        private bool isReviewsTabSelected;
        #endregion

        #region Commands declaration
        public ICommand GoBackCommand { get; }
        public ICommand UpdateItinerosRecommandationCommand { get; }
        public ICommand UpdateItinerosFollowCommand { get; }
        public ICommand OnInstagramTappedCommand { get; }
        #endregion

        public ItinerosPageViewModel(IItinerosService itinerosService, IPlacelistService placelistService, IReviewService reviewService)
        {
            _itinerosService = itinerosService;
            _placelistService = placelistService;
            _reviewService = reviewService;

            GoBackCommand = new Command(async () => await AppShell.Current.GoToAsync("..", true));
            UpdateItinerosRecommandationCommand = new Command(async () => await UpdateItinerosRecommendation());
            UpdateItinerosFollowCommand = new Command(async () => await UpdateItinerosFollow());
            OnInstagramTappedCommand = new Command(async () => await RedirectToInstagram());
        }


        public string ItinerosId
        {
            get { return itinerosId; }
            set { itinerosId = value; OnPropertyChanged(nameof(ItinerosId)); }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(nameof(Username)); }
        }

        public string? Country
        {
            get { return country; }
            set { country = value; OnPropertyChanged(nameof(Country)); }
        }

        public string? City
        {
            get { return city; }
            set { city = value; OnPropertyChanged(nameof(City)); }
        }

        public string? Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(nameof(Description)); }
        }

        public string? ProfilPictureUrl
        {
            get { return profilPictureUrl; }
            set { profilPictureUrl = value; OnPropertyChanged(nameof(ProfilPictureUrl)); }
        }

        public string? InstagramLink
        {
            get { return instagramLink; }
            set { instagramLink = value; OnPropertyChanged(nameof(InstagramLink)); }
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


        public int ReviewCount
        {
            get { return reviewCount; }
            set { reviewCount = value; OnPropertyChanged(nameof(ReviewCount)); }
        }

        public bool IsFollowedByCurrentUser
        {
            get { return isFollowedByCurrentUser; }
            set { isFollowedByCurrentUser = value; OnPropertyChanged(nameof(IsFollowedByCurrentUser));}
        }

        public bool IsRecommendedByCurrentUser
        {
            get { return isRecommendedByCurrentUser; }
            set { isRecommendedByCurrentUser = value; OnPropertyChanged(nameof(IsRecommendedByCurrentUser)); }
        }

        public IEnumerable<PlacelistHeaderViewModel> PlacelistHeaders
        {
            get { return placelistHeaders; }
            set { placelistHeaders = value; OnPropertyChanged(nameof(PlacelistHeaders)); }
        }

        public IEnumerable<ReviewViewModel> Reviews
        {
            get { return reviews; }
            set { reviews = value; OnPropertyChanged(nameof(Reviews)); }
        }


        public TabMenuViewModel TabMenu
        {
            get { return tabMenu; }
            set { tabMenu = value; OnPropertyChanged(nameof(TabMenu)); }
        }


        #region Functional properties
        public bool IsLoadingItineros
        {
            get { return isLoadingItineros; }
            set { isLoadingItineros = value; OnPropertyChanged(nameof(IsLoadingItineros)); }
        }

        public bool IsLoadingPlacelists
        {
            get { return isLoadingPlacelists; }
            set { isLoadingPlacelists = value; OnPropertyChanged(nameof(IsLoadingPlacelists)); }
        }

        public bool IsLoadingReviews
        {
            get { return isLoadingReviews; }
            set { isLoadingReviews = value; OnPropertyChanged(nameof(IsLoadingReviews)); }
        }

        public string ErrorLoadingItinerosData
        {
            get { return errorLoadingItinerosData; }
            set { errorLoadingItinerosData = value; OnPropertyChanged(nameof(ErrorLoadingItinerosData)); }
        }

        public string ErrorLoadingPlacelistsData
        {
            get { return errorLoadingPlacelistsData; }
            set { errorLoadingPlacelistsData = value; OnPropertyChanged(nameof(ErrorLoadingPlacelistsData)); }
        }

        public string ErrorLoadingReviewsData
        {
            get { return errorLoadingReviewsData; }
            set { errorLoadingReviewsData = value; OnPropertyChanged(nameof(ErrorLoadingReviewsData)); }
        }


        public bool IsPlacelistsTabSelected
        {
            get { return isPlacelistsTabSelected; }
            set { isPlacelistsTabSelected = value; OnPropertyChanged(nameof(IsPlacelistsTabSelected)); }
        }

        public bool IsReviewsTabSelected
        {
            get { return isReviewsTabSelected; }
            set { isReviewsTabSelected = value; OnPropertyChanged(nameof(IsReviewsTabSelected)); }
        }
        #endregion



        private void OnTabChanged(object sender, int selectedTabIndex)
        {
            if (selectedTabIndex == 0)
            {
                IsPlacelistsTabSelected = true;
                IsReviewsTabSelected = false;
            }
            else if (selectedTabIndex == 1)
            {
                IsReviewsTabSelected = true;
                IsPlacelistsTabSelected = false;
            }
        }


        private async Task UpdateItinerosRecommendation()
        {
            bool isRecommanded = !this.IsRecommendedByCurrentUser;
            IsRecommendedByCurrentUser = isRecommanded;
            await _itinerosService.UpdateItinerosRecommandation(ItinerosId, CurrentItinerosSession.CurrentItinerosId,  isRecommanded);
        }

        private async Task UpdateItinerosFollow()
        {
            bool isFollowing = !this.IsFollowedByCurrentUser;
            IsFollowedByCurrentUser = isFollowing;
            await _itinerosService.UpdateItinerosRecommandation(ItinerosId, CurrentItinerosSession.CurrentItinerosId, isFollowing);
        }

        private async Task RedirectToInstagram()
        {
            string instagramAppUrl = $"instagram://user?username={InstagramLink}";
            string instagramBrowserUrl = $"https://www.instagram.com/{InstagramLink}";

            try
            {
                bool canOpenLocalApp = await Launcher.CanOpenAsync(instagramAppUrl);
                if (canOpenLocalApp)
                {
                    await Launcher.OpenAsync(instagramAppUrl);
                }
                else
                {
                    await Launcher.OpenAsync(instagramBrowserUrl);
                }
            }
            catch (Exception) { return; }
        }


        public async Task LoadDataAsync()
        {
            if (string.IsNullOrEmpty(ItinerosId) || string.IsNullOrEmpty(CurrentItinerosSession.CurrentItinerosId))
                return;

            IsLoadingItineros = true;
            Result<ItinerosDto> itineros = await _itinerosService.GetItinerosById(ItinerosId, CurrentItinerosSession.CurrentItinerosId);
            if (itineros.IsFailure)
            {
                ErrorLoadingItinerosData = "An error occurred during the Itineros retrieval process. Please come back later.";
                IsLoadingItineros = false;
            }
            else
            {
                this.ItinerosId = itineros.Value.ItinerosId;
                this.FirstName = itineros.Value.FirstName;
                this.Username = itineros.Value.Username;
                this.Country = itineros.Value.Country;
                this.City = itineros.Value.City;
                this.InstagramLink = itineros.Value.InstagramLink;
                this.ProfilPictureUrl = itineros.Value.ProfilPictureUrl;
                this.Description = itineros.Value.Description;
                this.RecommendationCount = itineros.Value.RecommendationsCount;
                this.ReviewCount = itineros.Value.ReviewsCount;
                this.IsFollowedByCurrentUser = itineros.Value.IsFollowedByCurrentUser;
                this.IsRecommendedByCurrentUser = itineros.Value.IsRecommandedByCurrentUser;

                IsPlacelistsTabSelected = true;
                TabMenu = new("Placelists", null, "Reviews", this.ReviewCount);
                TabMenu.TabChanged += OnTabChanged;

                IsLoadingItineros = false;

                LoadPlacelistsAsync(itineros.Value.Placelists);
                LoadReviewsAsync(itineros.Value.Reviews);
            }
        }

        private async Task LoadPlacelistsAsync(IEnumerable<PlacelistHeaderDto> placelists)
        {
            IsLoadingPlacelists = true;
            Result<List<PlacelistHeaderViewModel>> placelistVMs = await _placelistService.GetPlacelistHeaderViewModels(placelists);
            if (placelistVMs.IsFailure)
            {
                ErrorLoadingPlacelistsData = "Sorry, it's impossible to view the placelists at the moment. Please come back later";
            }
            else
            {
                PlacelistHeaders = placelistVMs.Value;
            }
            IsLoadingPlacelists = false;
        }

        private async Task LoadReviewsAsync(IEnumerable<ReviewDto> reviews)
        {
            IsLoadingReviews = true;
            Result<List<ReviewViewModel>> reviewVMs = await _reviewService.GetReviewViewModels(reviews, ReviewViewedPage.ItinerosPage);
            if (reviewVMs.IsFailure)
            {
                ErrorLoadingReviewsData = "Sorry, it's impossible to view the reviews at the moment. Please come back later";
            }
            else
            {
                Reviews = reviewVMs.Value;
            }
            IsLoadingReviews = false;
        }



        public void Dispose()
        {
            TabMenu.TabChanged -= OnTabChanged;

            ErrorLoadingItinerosData = null;
            ErrorLoadingPlacelistsData = null;
            ErrorLoadingReviewsData = null;
        }
    }
}
