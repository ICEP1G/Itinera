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


        public string ProfilePictureUrl
        {
            get => _profilePictureUrl;
            set
            {
                _profilePictureUrl = value;
                OnPropertyChanged(nameof(ProfilePictureUrl));
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
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
