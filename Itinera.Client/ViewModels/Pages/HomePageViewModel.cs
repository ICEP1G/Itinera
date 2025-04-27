using Itinera.Client.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Itinera.Client.ViewModels.Pages
{
    public class HomePageViewModel : INotifyPropertyChanged
    {

        #region Variables declaration
        public event PropertyChangedEventHandler? PropertyChanged;
        private string _greetingMessage;
        private readonly IItinerosAccountService _itinerosAccountService;
        private string _firstName;
        private string _profilePictureUrl;
        private ObservableCollection<VisitedPlaces> _visitedPlaces;
        public string GreetingMessage
        {
            get => _greetingMessage;
            set
            {
                _greetingMessage = value;
                OnPropertyChanged(nameof(GreetingMessage));
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

        public ObservableCollection<VisitedPlaces> VisitedPlaces
        {
            get => _visitedPlaces;
            set
            {
                _visitedPlaces = value;
                OnPropertyChanged(nameof(VisitedPlaces));
            }
        }
        #endregion


        #region Commands Declaration
        public ICommand GreetingsCommand { get; }
        #endregion

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public HomePageViewModel(IItinerosAccountService itinerosAccountService)
        {
            _itinerosAccountService = itinerosAccountService;
            GreetingsCommand = new Command(Greetings);
            Greetings();
            _ = LoadUserData();
        }

        /// <summary>
        /// Method to load user data for homePage
        /// </summary>
        private async Task LoadUserData()
        {
            var user = await _itinerosAccountService.GetCurrentUserAsync();
            FirstName = user.FirstName;
            ProfilePictureUrl = user.ProfilPictureUrl;

            var groupedVisits = user.Reviews
                .GroupBy(r => r.PlaceCity ?? "Unknown City")
                .Select(group => new VisitedPlaces
                {
                    CityName = group.Key,
                    PlacesCount = group.Count(),
                    PlaceImages = group
                    .Select(x => x.PlaceFirstPictureUrl)
                    .Where(url => !string.IsNullOrEmpty(url))
                    .ToList()
                }).ToList();
            
            VisitedPlaces = new ObservableCollection<VisitedPlaces>(groupedVisits);

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

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    public class VisitedPlaces
    {
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public int PlacesCount { get; set; }
        public List<String> PlaceImages { get; set; }
    }
}
