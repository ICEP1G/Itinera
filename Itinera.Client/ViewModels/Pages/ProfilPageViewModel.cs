using CSharpFunctionalExtensions;
using Itinera.Client.Models;
using Itinera.Client.Services;
using Itinera.DTOs.Itineros;
using System.ComponentModel;
using System.Windows.Input;

namespace Itinera.Client.ViewModels.Pages
{
    public class ProfilPageViewModel : INotifyPropertyChanged
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
        private string _profilePictureUrl;
        private ImageSource _uploadedImageSource;
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
        private int _visitedPlacesCount;

        public string ProfilePictureUrl
        {
            get => _profilePictureUrl;
            set
            {
                _profilePictureUrl = value;
                OnPropertyChanged(nameof(ProfilePictureUrl));
            }
        }



        public string ProfilGreeting
        {
            get => _profilGreeting;
            set
            {
                _profilGreeting = value;
                OnPropertyChanged(nameof(ProfilGreeting));
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

        public int VisitedPlacesCount
        {
            get => _visitedPlacesCount;
            set
            {
                _visitedPlacesCount = value;
                OnPropertyChanged(nameof(VisitedPlacesCount));
            }
        }
        #endregion

        #region Commands Declaration
        public ICommand SettingsCommand { get; }
        public ICommand UploadPhotoCommand { get; }
        public ICommand GoBackCommand { get; }
        #endregion

        /// <summary>
        /// Constructor by default.
        /// </summary>
        public ProfilPageViewModel(IItinerosService itinerosService)
        {
            _itinerosService = itinerosService;
            SettingsCommand = new Command(ShowSettingPage);
            UploadPhotoCommand = new Command(async () => await UploadPhotoAsync());
            UploadedImageSource = null;
            GoBackCommand = new Command(GetBackToProfilPage);
            _ = LoadUserData();
        }

        /// <summary>
        /// Method to load user data for Profil Page
        /// </summary>
        private async Task LoadUserData()
        {
            string? currentItineros = CurrentItinerosSession.CurrentItinerosId;
            if (!string.IsNullOrEmpty(currentItineros))
            {
                Result<ItinerosDto> currentUser = await _itinerosService.GetItinerosById(currentItineros, currentItineros);
                if (currentUser.IsFailure)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    FirstName = currentUser.Value.FirstName;
                    ProfilePictureUrl = currentUser.Value.ProfilPictureUrl;
                    ProfilDescription = currentUser.Value.Description;
                    Username = currentUser.Value.Username;
                    InscriptionDate = currentUser.Value.InscriptionDate;
                    ProfilCity = currentUser.Value.City;
                    ProfilCountry = currentUser.Value.Country;
                    VisitedPlacesCount = currentUser.Value.Reviews
                        .Select(review => review.PlaceId)
                        .Distinct()
                        .Count();
                    SetRandomGreeting();
                }
            }
        }

        /// <summary>
        /// Upload Image input
        /// </summary>
        public ImageSource UploadedImageSource
        {
            get => _uploadedImageSource;
            set
            {
                _uploadedImageSource = value;
                OnPropertyChanged(nameof(UploadedImageSource));
            }
        }


        public void SetRandomGreeting()
        {
            var greetings = _helloTranslations.Values.ToList();
            var random = new Random();
            int index = random.Next(greetings.Count);
            ProfilGreeting = greetings[index];
        }

        /// <summary>
        /// Logic to upload a picture with the device
        /// </summary>
        /// <returns></returns>
        private async Task UploadPhotoAsync()
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Choose a picture"
                });

                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    UploadedImageSource = ImageSource.FromStream(() => stream);
                }
            }
            catch (Exception ex)
            {
                var currentApp = Application.Current;
                if (currentApp?.Windows?.Count > 0)
                {
                    var mainPage = currentApp.Windows[0].Page;
                    if (mainPage != null)
                    {
                        await mainPage.DisplayAlert("Error", $"Cannot charge the picture: {ex.Message}", "Ok");
                    }
                }
            }
        }

        #region redirection
        /// <summary>
        /// Method to access Setting Page
        /// </summary>
        public async void ShowSettingPage()
        {
            await AppShell.Current.GoToAsync($"{nameof(SettingsPage)}");
        }

        /// <summary>
        /// Method to go back to profil page.
        /// </summary>
        public async void GetBackToProfilPage()
        {
            await AppShell.Current.GoToAsync("..", true);
        }
        #endregion
    }
}
