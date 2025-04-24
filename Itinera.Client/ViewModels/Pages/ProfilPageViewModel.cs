using Itinera.Client.Services;
using System.ComponentModel;

namespace Itinera.Client.ViewModels.Pages
{
    public class ProfilPageViewModel : INotifyPropertyChanged
    {
        #region Variables declaration
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly IItinerosAccountService _itinerosAccountService;
        private string _profilePictureUrl;
        private string _firstName;
        private string _userName;
        private DateTime _inscriptionDate;
        private string _profilDescription;
        private string _profilCity;
        private string _profilCountry;
        private readonly Dictionary<string, string> _helloTranslations = new()
        {
            { "fr", "Bonjour" },
            { "en", "Hello" },
            { "es", "Holã" },
            { "pt", "Olá" },
            { "de", "Hallo" },
            { "it", "Ciao" },
            { "ja", "こんにちは" },
            { "zh", "你好" },
            { "ru", "Здравствуйте" },
            { "ar", "مرحبا" }, 
        };
        private string _profilGreeting = "Hello";


        public string ProfilePictureUrl
        {
            get => _profilePictureUrl;
            set
            {
                _profilePictureUrl = value;
                OnPropertyChanged(nameof(ProfilePictureUrl));
            }
        }

        public string ProfilGretting
        {
            get => _profilGreeting;
            set
            {
                _profilGreeting = value;
                OnPropertyChanged(nameof(ProfilGretting));
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

        public string Username
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public DateTime InscriptionDate 
        {
            get => _inscriptionDate;
            set
            {
                _inscriptionDate = value;
                OnPropertyChanged(nameof(InscriptionDate));
            }
            
        }

        public string ProfilDescription
        {
            get => _profilDescription;
            set
            {
                _profilDescription = value;
                OnPropertyChanged(nameof(ProfilDescription));
            }
        }

        public string ProfilCity
        {
            get => _profilCity;
            set
            {
                _profilCity = value;
                OnPropertyChanged(nameof(ProfilCity));
            }
        }

        public string ProfilCountry
        {
            get => _profilCountry;
            set
            {
                _profilCountry = value;
                OnPropertyChanged(nameof(ProfilCountry));
            }
        }

        #endregion

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public ProfilPageViewModel(IItinerosAccountService itinerosAccountService)
        {
            _itinerosAccountService = itinerosAccountService;
            LoadUserData();
        }

        /// <summary>
        /// Method to load user data for Profil Page
        /// </summary>
        private async void LoadUserData()
        {
            var user = await _itinerosAccountService.GetCurrentUserAsync();
            FirstName = user.FirstName;
            ProfilePictureUrl = user.ProfilPictureUrl;
            ProfilDescription = user.Description;
            Username = user.Username;
            InscriptionDate = user.InscriptionDate;
            ProfilCity = user.City;
            ProfilCountry = user.Country;
            SetRandomGreeting();
        }

        public void SetRandomGreeting()
        {
            var greetings = _helloTranslations.Values.ToList();
            var random = new Random();
            int index = random.Next(greetings.Count);
            ProfilGretting = greetings[index];
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
