using CommunityToolkit.Maui.Core.Extensions;
using CSharpFunctionalExtensions;
using Itinera.Client.Models;
using Itinera.Client.Services;
using Itinera.Client.ViewModels.Components;
using Itinera.Client.Views.Pages;
using Itinera.DTOs;
using Itinera.DTOs.Itineros;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Itinera.Client.ViewModels.Pages
{
    public class HomePageViewModel : INotifyPropertyChanged
    {

        #region NotifyChanges declaration
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Variables declaration
        private string _greetingMessage;
        private readonly IItinerosService _itinerosService;
        private readonly IReviewService _reviewService;
        private readonly IPlaceService _placeService;

        private string itinerosId;
        private string _firstName;
        private string _profilePictureUrl;
        private ObservableCollection<ReviewViewModel> followedItinerosLastReviews;
        private ObservableCollection<PlaceHeaderViewModel> nearPlaces;

        private bool isLoadingMainHomePageData;
        private string errorLoadingMainHomePageData;
        private bool isLoadingFollowedItinerosLastReviews;
        private string errorLoadingFollowedItinerosLastReviewsData;
        private bool isLoadingNearPlaces;
        private string errorLoadingNearPlaces;
        private bool isRefreshingView = false;
        #endregion

        #region Commands Declaration
        public ICommand GreetingsCommand { get; }
        public ICommand GoToItinerosPageCommand { get;}
        public ICommand RefreshMainContentCommand { get; }
        #endregion

        #region Public properties
        public string GreetingMessage
        {
            get => _greetingMessage;
            set
            {
                _greetingMessage = value;
                OnPropertyChanged(nameof(GreetingMessage));
            }
        }

        public string ItinerosId
        {
            get => itinerosId;
            set 
            { 
                itinerosId = value; 
                OnPropertyChanged(nameof(ItinerosId)); 
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string ProfilePictureUrl
        {
            get => _profilePictureUrl;
            set
            {
                _profilePictureUrl = value;
                OnPropertyChanged(nameof(ProfilePictureUrl));
            }
        }

        public ObservableCollection<PlaceHeaderViewModel> NearPlaces
        {
            get => nearPlaces;
            set
            {
                nearPlaces = value;
                OnPropertyChanged(nameof(NearPlaces));
            }
        }

        public ObservableCollection<ReviewViewModel> FollowedItinerosLastReviews
        {
            get => followedItinerosLastReviews;
            set 
            { 
                followedItinerosLastReviews = value; 
                OnPropertyChanged(nameof(FollowedItinerosLastReviews)); 
            }
        }
        #endregion

        #region Functional properties
        public bool IsLoadingMainHomePageData
        {
            get => isLoadingMainHomePageData;
            set
            {
                isLoadingMainHomePageData = value;
                OnPropertyChanged(nameof(IsLoadingMainHomePageData));
            }
        }

        public string ErrorLoadingMainHomePageData
        {
            get => errorLoadingMainHomePageData;
            set
            {
                errorLoadingMainHomePageData = value;
                OnPropertyChanged(nameof(ErrorLoadingMainHomePageData));
            }
        }

        public bool IsLoadingFollowedItinerosLastReviews
        {
            get => isLoadingFollowedItinerosLastReviews;
            set 
            { 
                isLoadingFollowedItinerosLastReviews = value; 
                OnPropertyChanged(nameof(IsLoadingFollowedItinerosLastReviews)); 
            }
        }

        public string ErrorLoadingFollowedItinerosLastReviewsData
        {
            get => errorLoadingFollowedItinerosLastReviewsData;
            set 
            { 
                errorLoadingFollowedItinerosLastReviewsData = value; 
                OnPropertyChanged(nameof(ErrorLoadingFollowedItinerosLastReviewsData)); 
            }
        }

        public bool IsLoadingNearPlaces
        {
            get => isLoadingNearPlaces;
            set
            {
                isLoadingNearPlaces = value;
                OnPropertyChanged(nameof(IsLoadingNearPlaces));
            }
        }

        public string ErrorLoadingNearPlaces
        {
            get => errorLoadingNearPlaces;
            set
            {
                errorLoadingNearPlaces = value;
                OnPropertyChanged(nameof(ErrorLoadingNearPlaces));
            }
        }

        public bool IsRefreshingView
        {
            get => isRefreshingView;
            set 
            { 
                isRefreshingView = value; 
                OnPropertyChanged(nameof(IsRefreshingView)); 
            }
        }
        #endregion


        /// <summary>
        /// Constructor by default.
        /// </summary>
        public HomePageViewModel(IItinerosService itinerosService, IReviewService reviewService, IPlaceService placeService)
        {
            _itinerosService = itinerosService;
            _reviewService = reviewService;
            _placeService = placeService;

            RefreshMainContentCommand = new Command(async () => await RefreshMainContent());
            GoToItinerosPageCommand = new Command(async () => await AppShell.Current.GoToAsync($"{nameof(ItinerosPage)}", true,
                new ShellNavigationQueryParameters { { "ItinerosId", ItinerosId } }));

            GreetingsCommand = new Command(Greetings);
            Greetings();
        }


        /// <summary>
        /// Method to load user data for homePage
        /// </summary>
        public async Task LoadUserData()
        {
            string? currentItinerosId = CurrentItinerosSession.CurrentItinerosId;
            if (!string.IsNullOrEmpty(currentItinerosId))
            {
                Result<ItinerosDto> currentUser = await _itinerosService.GetItinerosById(currentItinerosId, currentItinerosId);
                if (currentUser.IsFailure)
                {
                    ErrorLoadingMainHomePageData = "An error occurred during the Home page retrieval process. Please come back later.";
                    IsLoadingMainHomePageData = false;
                }
                else
                {
                    ItinerosId = currentUser.Value.ItinerosId;
                    FirstName = currentUser.Value.FirstName;
                    ProfilePictureUrl = currentUser.Value.ProfilPictureUrl;

                    LoadFollowedItinerosLastReviewsAsync(currentItinerosId);
                    LoadNearPlacesAsync();
                }
            }
            IsRefreshingView = false;
        }

        #region Followed Itineros Last Reviews methods
        private async Task LoadFollowedItinerosLastReviewsAsync(string currentItinerosId)
        {
            if (IsRefreshingView is false)
                IsLoadingFollowedItinerosLastReviews = true;

            Result<List<ReviewDto>> lastReviews = await GetFollowedItinerosLastReviewAsync(currentItinerosId);
            if (lastReviews.IsFailure)
            {
                ErrorLoadingFollowedItinerosLastReviewsData = "Sorry, it's impossible to view the last reviews at the moment. Please come back later";
                IsLoadingFollowedItinerosLastReviews = false;
            }
            else
            {
                try
                {
                    Result<List<ReviewViewModel>> lastReviewVMs = await _reviewService.GetReviewViewModels(lastReviews.Value, ReviewViewedPage.HomePage);
                    if (lastReviewVMs.IsFailure)
                    {
                        ErrorLoadingFollowedItinerosLastReviewsData = "Sorry, it's impossible to view the last reviews at the moment. Please come back later";
                        IsLoadingFollowedItinerosLastReviews = false;
                    }
                    else
                    {
                        FollowedItinerosLastReviews = lastReviewVMs.Value.ToObservableCollection();
                    }
                }
                catch (Exception ex)
                {
                    ErrorLoadingFollowedItinerosLastReviewsData = "Sorry, it's impossible to view the last reviews at the moment. Please come back later";
                }
            }
            IsLoadingFollowedItinerosLastReviews = false;
        }

        private async Task<Result<List<ReviewDto>>> GetFollowedItinerosLastReviewAsync(string currentItineros)
        {
            try
            {
                Result<List<ReviewDto>> lastReviews = await _itinerosService.GetFollowedItinerosLastReviews(currentItineros);
                if (lastReviews.IsFailure)
                {
                    return Result.Failure<List<ReviewDto>>("Sorry, it's impossible to view the last reviews at the moment. Please come back later");
                }
                else
                {
                    return Result.Success(lastReviews.Value);
                }
            }
            catch (Exception ex)
            {
                return Result.Failure<List<ReviewDto>>($"Unexpected error: {ex.Message}");
            }
        }
        #endregion

        #region Near Places methods
        private async Task LoadNearPlacesAsync()
        {
            if (IsRefreshingView is false)
                IsLoadingNearPlaces = true;

            Result<List<PlaceHeaderDto>> nearPlaces = await GetPlacesForCurrentItinerosLocation();
            if (nearPlaces.IsFailure)
            {
                ErrorLoadingNearPlaces = "Sorry, it's impossible to view the nearest places at the moment. Please come back later";
            }
            else
            {
                try
                {
                    Result<List<PlaceHeaderViewModel>> nearPlacesVMs = await _placeService.GetPlaceHeaderViewModels(nearPlaces.Value);
                    if (nearPlacesVMs.IsFailure)
                    {
                        ErrorLoadingNearPlaces = "Sorry, it's impossible to view the nearest places at the moment. Please come back later";
                    }
                    else if (nearPlacesVMs.Value is null)
                    {
                        ErrorLoadingNearPlaces = "Sorry, there is no places around you that we can show";
                    }
                    else
                    {
                        NearPlaces = nearPlacesVMs.Value.ToObservableCollection();
                    }
                }
                catch (Exception)
                {
                    ErrorLoadingNearPlaces = "Sorry, it's impossible to view the nearest places at the moment. Please come back later";
                }
            }
            IsLoadingNearPlaces = false;
        }

        public async Task<Result<List<PlaceHeaderDto>>> GetPlacesForCurrentItinerosLocation()
        {
            Result<Location> itinerosLocation = await GetCurrentItinerosLocation();
            if (itinerosLocation.IsFailure)
                return Result.Failure<List<PlaceHeaderDto>>("Impossible to find your location");

            try
            {
                Result<List<PlaceHeaderDto>> nearPlaces = await _placeService.GetPlaceHeadersByLocation(itinerosLocation.Value.Latitude, itinerosLocation.Value.Longitude);
                if (nearPlaces.IsFailure)
                    return Result.Failure<List<PlaceHeaderDto>>("Impossible to find any locations");

                return nearPlaces;
            }
            catch (Exception ex)
            {
                return Result.Failure<List<PlaceHeaderDto>>($"Unexpected error: {ex.Message}");
            }

        }

        private async Task<Result<Location>> GetCurrentItinerosLocation()
        {
            try
            {
                PermissionStatus permissionStatus = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (permissionStatus != PermissionStatus.Granted)
                    permissionStatus = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

                GeolocationRequest request = new(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                Location? location = await Geolocation.GetLocationAsync(request);
                if (location is null)
                    return Result.Failure<Location>("Impossible to find any locations");

                return Result.Success(location);
            }
            catch (FeatureNotEnabledException ex)
            {
                return Result.Failure<Location>("Localization need to be activated in order to see the places");
            }
            catch (Exception ex)
            {
                return Result.Failure<Location>($"Unexpected error: {ex.Message}");
            }
        }
        #endregion


        public async Task RefreshMainContent()
        {
            string? currentItinerosId = CurrentItinerosSession.CurrentItinerosId;
            if (!string.IsNullOrEmpty(currentItinerosId))
            {
                ErrorLoadingFollowedItinerosLastReviewsData = null;
                ErrorLoadingNearPlaces = null;

                if (FollowedItinerosLastReviews is not null && FollowedItinerosLastReviews.Count > 0)
                    FollowedItinerosLastReviews.Clear();

                if (NearPlaces is not null && NearPlaces.Count > 0)
                    NearPlaces.Clear();

                Task loadLastReview = LoadFollowedItinerosLastReviewsAsync(currentItinerosId);
                Task loadNearPlaces = LoadNearPlacesAsync();

                await Task.WhenAll(loadLastReview, loadNearPlaces);
                IsRefreshingView = false;
            }

            IsRefreshingView = false;
        }

        /// <summary>
        /// Method to set the greeting message based on the current time.
        /// </summary>
        private void Greetings()
        {
            int hour = DateTime.Now.Hour;

            switch (hour > 17)
            {
                case true:
                    GreetingMessage = "Good evening";
                    break;
                case false when hour > 12:
                    GreetingMessage = "Good afternoon";
                    break;
                case false when hour > 5:
                    GreetingMessage = "Good morning";
                    break;
                default:
                    GreetingMessage = "Good night";
                    break;
            }
        }

        /// <summary>
        /// Gestion of what is display or what is not display
        /// </summary>
        public void Dispose()
        {
            ErrorLoadingMainHomePageData = null;
            ErrorLoadingFollowedItinerosLastReviewsData = null;
            ErrorLoadingNearPlaces = null;
        }
    }
}
