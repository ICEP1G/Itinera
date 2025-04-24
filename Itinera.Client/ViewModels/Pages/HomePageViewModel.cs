using Itinera.Client.Services;
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
            LoadUserData();
        }

        /// <summary>
        /// Method to load user data for homePage
        /// </summary>
        private async void LoadUserData()
        {
            var user = await _itinerosAccountService.GetCurrentUserAsync();
            FirstName = user.FirstName;
            ProfilePictureUrl = user.ProfilPictureUrl;
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
}
