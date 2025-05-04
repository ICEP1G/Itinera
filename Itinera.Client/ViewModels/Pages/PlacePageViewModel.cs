using CommunityToolkit.Maui.Core.Extensions;
using CSharpFunctionalExtensions;
using Itinera.Client.Helpers;
using Itinera.Client.Models;
using Itinera.Client.Services;
using Itinera.Client.ViewModels.Components;
using Itinera.DTOs;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;

namespace Itinera.Client.ViewModels
{
    [QueryProperty(nameof(PlaceId), "PlaceId")]
    public class PlacePageViewModel : INotifyPropertyChanged
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
        private readonly IReviewService _reviewService;

        private string placeId;
        private string name;
        private string address;
        private string? description;
        private string primaryType;
        private string iconUri;
        private string? phoneNumber;
        private string? webSiteUrl;
        private IEnumerable<string>? imageUrls;
        private Dictionary<string, string>? weekDaySchedules;
        private ObservableCollection<ScheduleItem> scheduleItems;
        private string todaySchedules;
        private IEnumerable<string>? paymentOptions;
        private string? startPrice;
        private string? endPrice;
        private string? priceRange;
        private int recommendationCount;
        private bool isFavorite;
        private int reviewCount;
        private bool isRecommendedByCurrentUser;
        private bool isReviewedByCurrentUser;
        private ObservableCollection<ReviewViewModel> reviews;
        private ButtonChipsViewModel buttonChipsRecommendation;
        private ButtonChipsViewModel buttonChipsReview;

        private bool isLoadingPlace;
        private bool isLoadingReviews;
        private string errorLoadingPlacePageData;
        private string errorLoadingReviewsData;
        private bool isOverviewTabSelected;
        private bool isReviewsTabSelected;
        private TabMenuViewModel tabMenu;
        private bool isSchedulesExpanded;
        #endregion

        #region Commands declaration
        public ICommand GoBackCommand { get; }
        public ICommand GoToPlaceWebSiteCommand { get; }
        public ICommand UpdatePlaceRecommandationCommand { get; }
        public ICommand AddOrUpdateReviewCommand { get; }
        public ICommand AddPlaceToPlacelistCommand { get; }
        public ICommand ExpandSchedulesCommand { get; }
        #endregion

        public PlacePageViewModel(IPlaceService placeService, IReviewService reviewService)
        {
            _placeService = placeService;
            _reviewService = reviewService;

            GoBackCommand = new Command(async () => await AppShell.Current.GoToAsync("..", true));
            GoToPlaceWebSiteCommand = new Command(async () => await RedirectToPlaceWebSite());
            UpdatePlaceRecommandationCommand = new Command(async () => await UpdatePlaceRecommandation());
            AddOrUpdateReviewCommand = new Command(async () => await AddOrUpdatePlaceReview());
            ExpandSchedulesCommand = new Command(ExpandSchedules);
        }

        #region Public Properties declaration
        public string PlaceId
        {
            get { return placeId; }
            set { placeId = value; OnPropertyChanged(nameof(PlaceId)); }
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

        public string? Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(nameof(Description)); }
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

        public string IconUri
        {
            get { return iconUri; }
            set { iconUri = value; OnPropertyChanged(nameof(IconUri)); }
        }

        public string? PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); }
        }

        public string? WebSiteUrl
        {
            get { return webSiteUrl; }
            set { webSiteUrl = value; OnPropertyChanged(nameof(WebSiteUrl)); }
        }

        public IEnumerable<string>? ImageUrls
        {
            get { return imageUrls; }
            set { imageUrls = value; OnPropertyChanged(nameof(ImageUrls)); }
        }

        public Dictionary<string, string>? WeekDaySchedules
        {
            get { return weekDaySchedules; }
            set 
            { 
                weekDaySchedules = value; 
                if (value is not null)
                {
                    Result<string> todaySchedule = _placeService.GetTodayScheduleStatus(value);
                    if (todaySchedule.IsSuccess)
                    {
                        TodaySchedules = todaySchedule.Value;
                    }
                    ScheduleItems = GetSortedSchedules(value);
                }

                OnPropertyChanged(nameof(WeekDaySchedules)); 
            }
        }

        public ObservableCollection<ScheduleItem> ScheduleItems
        {
            get { return scheduleItems; }
            set { scheduleItems = value; OnPropertyChanged(nameof(ScheduleItems)); }
        }

        public string TodaySchedules
        {
            get { return todaySchedules; }
            set { todaySchedules = value; OnPropertyChanged(nameof(TodaySchedules)); }
        }

        public IEnumerable<string>? PaymentOptions
        {
            get { return paymentOptions; }
            set { paymentOptions = value; OnPropertyChanged(nameof(PaymentOptions)); }
        }

        public string? StartPrice
        {
            get { return startPrice; }
            set { startPrice = value; OnPropertyChanged(nameof(StartPrice)); }
        }

        public string? EndPrice
        {
            get { return endPrice; }
            set { endPrice = value; OnPropertyChanged(nameof(EndPrice)); }
        }

        public string? PriceRange
        {
            get { return priceRange; }
            set { priceRange = value; OnPropertyChanged(nameof(PriceRange)); }
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
            set { reviewCount = value; }
        }

        public bool IsRecommendedByCurrentUser
        {
            get { return isRecommendedByCurrentUser; }
            set { isRecommendedByCurrentUser = value; OnPropertyChanged(nameof(IsRecommendedByCurrentUser)); }
        }

        public bool IsReviewedByCurrentUser
        {
            get { return isReviewedByCurrentUser; }
            set { isReviewedByCurrentUser = value; OnPropertyChanged(nameof(IsReviewedByCurrentUser)); }
        }

        public ObservableCollection<ReviewViewModel> Reviews
        {
            get { return reviews; }
            set { reviews = value; OnPropertyChanged(nameof(Reviews)); }
        }

        public TabMenuViewModel TabMenu
        {
            get { return tabMenu; }
            set { tabMenu = value; OnPropertyChanged(nameof(TabMenu)); }
        }

        public ButtonChipsViewModel ButtonChipsRecommendation
        {
            get { return buttonChipsRecommendation; }
            set { buttonChipsRecommendation = value; OnPropertyChanged(nameof(ButtonChipsRecommendation)); }
        }

        public ButtonChipsViewModel ButtonChipsReview
        {
            get { return buttonChipsReview; }
            set { buttonChipsReview = value; OnPropertyChanged(nameof(ButtonChipsReview)); }
        }
        #endregion

        #region Functional properties
        public bool IsLoadingPlace
        {
            get { return isLoadingPlace; }
            set { isLoadingPlace = value; OnPropertyChanged(nameof(IsLoadingPlace)); }
        }

        public bool IsLoadingReviews
        {
            get { return isLoadingReviews; }
            set { isLoadingReviews = value; OnPropertyChanged(nameof(IsLoadingReviews)); }
        }

        public string ErrorLoadingPlacePageData
        {
            get { return errorLoadingPlacePageData; }
            set { errorLoadingPlacePageData = value; OnPropertyChanged(nameof(ErrorLoadingPlacePageData)); }
        }

        public string ErrorLoadingReviewsData
        {
            get { return errorLoadingReviewsData; }
            set { errorLoadingReviewsData = value; OnPropertyChanged(nameof(ErrorLoadingReviewsData)); }
        }


        public bool IsOverviewTabSelected
        {
            get { return isOverviewTabSelected; }
            set { isOverviewTabSelected = value; OnPropertyChanged(nameof(IsOverviewTabSelected)); }
        }

        public bool IsReviewsTabSelected
        {
            get { return isReviewsTabSelected; }
            set { isReviewsTabSelected = value; OnPropertyChanged(nameof(IsReviewsTabSelected)); }
        }


        public bool IsSchedulesExpanded
        {
            get { return isSchedulesExpanded; }
            set { isSchedulesExpanded = value; OnPropertyChanged(nameof(IsSchedulesExpanded)); }
        }
        #endregion


        private void OnTabChanged(object sender, int selectedTabIndex)
        {
            if (selectedTabIndex == 0)
            {
                IsOverviewTabSelected = true;
                IsReviewsTabSelected = false;
            }
            else if (selectedTabIndex == 1)
            {
                IsReviewsTabSelected = true;
                IsOverviewTabSelected = false;
            }
        }

        private void ExpandSchedules()
        {
            IsSchedulesExpanded = !IsSchedulesExpanded;
            ScheduleItems = GetSortedSchedules(WeekDaySchedules);
        }

        private async Task RedirectToPlaceWebSite()
        {
            try
            {
                if (!string.IsNullOrEmpty(WebSiteUrl))
                    await Launcher.OpenAsync(WebSiteUrl);
            }
            catch (Exception) { return; }
        }

        private ObservableCollection<ScheduleItem> GetSortedSchedules(Dictionary<string, string> originalSchedules)
        {
            var actualDayName = DateTime.Now.ToString("dddd", CultureInfo.InvariantCulture);
            ObservableCollection<ScheduleItem> scheduleItems = new();
            int index = 0;
            foreach (var schedule in originalSchedules)
            {
                ObservableCollection<string> scheduleRanges = GetScheduleSeparated(schedule.Value).ToObservableCollection();
                if (schedule.Key == actualDayName)
                {
                    ScheduleItem scheduleItem = new("Today", scheduleRanges, 0);
                    scheduleItems.Insert(0, scheduleItem);
                }
                else
                {
                    if (IsSchedulesExpanded)
                    {
                        index += 1;
                        ScheduleItem scheduleItem = new(schedule.Key, scheduleRanges, index);
                        scheduleItems.Add(scheduleItem);
                    }
                }
            }
            return scheduleItems;
        }

        private List<string> GetScheduleSeparated(string schedule)
        {
            List<string> scheduleRanges = schedule.Split(',').ToList();

            char[] trimChars = { ' ', '\u2009' };
            for (int i = 0; i < scheduleRanges.Count; i++)
            {
                scheduleRanges[i] = scheduleRanges[i].Trim(trimChars);
            }
            return scheduleRanges;
        }

        private async Task UpdatePlaceRecommandation()
        {
            ButtonChipsRecommendation.IsLoading = true;
            bool isRecommanded = !this.IsRecommendedByCurrentUser;
            Result<bool> result = await _placeService.UpdatePlaceRecommandation(PlaceId, CurrentItinerosSession.CurrentItinerosId, isRecommanded);
            if (result.IsSuccess)
            {
                IsRecommendedByCurrentUser = isRecommanded;
            }
            ButtonChipsRecommendation.IsToggleState = IsRecommendedByCurrentUser;
            ButtonChipsRecommendation.IsLoading = false;
        }

        private async Task AddOrUpdatePlaceReview()
        {

        }


        public async Task LoadDataAsync()
        {
            string? currentItinerosId = CurrentItinerosSession.CurrentItinerosId;
            if (!string.IsNullOrEmpty(currentItinerosId))
            {
                IsLoadingPlace = true;
                Result<PlaceContentDto> placeContent = await _placeService.GetPlaceContent(PlaceId, currentItinerosId);
                if (placeContent.IsFailure)
                {
                    ErrorLoadingPlacePageData = "An error occurred during the Place retrieval process. Please come back later.";
                    IsLoadingPlace = false;
                }
                else
                {
                    this.Name = placeContent.Value.Name;
                    this.Address = placeContent.Value.Address;
                    this.Description = placeContent.Value.Description;
                    this.PrimaryType = placeContent.Value.PlacePrimaryType;
                    this.PhoneNumber = placeContent.Value.PhoneNumber;
                    this.ImageUrls = placeContent.Value.ImageUrls;
                    this.WebSiteUrl = placeContent.Value.WebSiteUrl;
                    this.WeekDaySchedules = placeContent.Value.WeekDaySchedules;
                    this.PaymentOptions = placeContent.Value.PaymentOptions;
                    this.StartPrice = placeContent.Value.StartPrice;
                    this.EndPrice = placeContent.Value.EndPrice;
                    this.RecommendationCount = placeContent.Value.RecommendationsCount;
                    this.IsRecommendedByCurrentUser = placeContent.Value.IsRecommandedByCurrentUser;
                    this.IsReviewedByCurrentUser = placeContent.Value.IsReviewedByCurrentUser;
                    this.ReviewCount = placeContent.Value.ReviewsCount;
                    if (!string.IsNullOrEmpty(StartPrice) && !string.IsNullOrWhiteSpace(EndPrice))
                        PriceRange = $"{StartPrice} - {EndPrice}";

                    IsLoadingPlace = false;

                    IsOverviewTabSelected = true;
                    TabMenu = new("Overview", null, "Reviews", this.ReviewCount);
                    TabMenu.TabChanged += OnTabChanged;

                    ButtonChipsRecommendation = new(IsRecommendedByCurrentUser, "Like", "Liked", "like_icon.png", 12, -1);
                    ButtonChipsReview = new(IsReviewedByCurrentUser, "Review", "Reviewed", "review_icon.png", 12, 0.5);

                    LoadReviewsAsync(placeContent.Value.Reviews);
                }
            }
        }

        private async Task LoadReviewsAsync(IEnumerable<ReviewDto> reviews)
        {
            IsLoadingReviews = true;
            Result<List<ReviewViewModel>> reviewVMs = await _reviewService.GetReviewViewModels(reviews, ReviewViewedPage.PlacePage);
            if (reviewVMs.IsFailure)
            {
                ErrorLoadingReviewsData = "Sorry, it's impossible to view the reviews at the moment. Please come back later";
            }
            else
            {
                Reviews = reviewVMs.Value.ToObservableCollection();
            }
            IsLoadingReviews = false;
        }


        public void Dispose()
        {
            if (TabMenu is not null)
                TabMenu.TabChanged -= OnTabChanged;

            ErrorLoadingPlacePageData = null;
            ErrorLoadingReviewsData = null;
        }
    }

    public record ScheduleItem(string Day, ObservableCollection<string> Schedules, int Index);
}
