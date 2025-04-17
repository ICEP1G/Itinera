using System.ComponentModel;
using System.Windows.Input;

namespace Itinera.Client.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        #region Variables declaration
        public event PropertyChangedEventHandler? PropertyChanged;
        private string _username;
        private string _firstName;
        private string _phoneNumber;
        private string _email;
        private string _password;
        private string _retryPassword;
        private bool _isLoginAreaVisible;
        private bool _isRegisterAreaVisible;
        private ImageSource _uploadedImageSource;
        #endregion

        #region Commands Declaration
        public ICommand ShowLoginAreaCommand { get; }
        public ICommand HideLoginAreaCommand { get; }
        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand ShowRegisterAreaCommand { get; }
        public ICommand HideRegisterAreaCommand { get; }
        public ICommand UploadPhotoCommand { get; }
        #endregion

        /// <summary>
        /// Constructor By Default
        /// </summary>
        public LoginPageViewModel()
        {
            ShowLoginAreaCommand = new Command(() => IsLoginAreaVisible = true);
            HideLoginAreaCommand = new Command(() => IsLoginAreaVisible = false);
            LoginCommand = new Command(Login);
            RegisterCommand = new Command(Register);
            ShowRegisterAreaCommand = new Command(() => IsRegisterAreaVisible = true);
            HideRegisterAreaCommand = new Command(() => IsRegisterAreaVisible = false);
            UploadPhotoCommand = new Command(async () => await UploadPhotoAsync());
            IsLoginAreaVisible = false;
            UploadedImageSource = null;
        }

        #region Login or Register visible
        /// <summary>
        /// Manage Login area visibility
        /// </summary>
        public bool IsLoginAreaVisible
        {
            get => _isLoginAreaVisible;
            set
            {
                _isLoginAreaVisible = value;
                OnPropertyChanged(nameof(IsLoginAreaVisible));
            }
        }

        /// <summary>
        /// Manage Register area visibility
        /// </summary>
        public bool IsRegisterAreaVisible
        {
            get => _isRegisterAreaVisible;
            set
            {
                _isRegisterAreaVisible = value;
                OnPropertyChanged(nameof(IsRegisterAreaVisible));
            }
        }
        #endregion

        /// <summary>
        /// User name field
        /// </summary>
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        /// <summary>
        /// First name field
        /// </summary>
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        /// <summary>
        /// Phone number field
        /// </summary>
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        /// <summary>
        /// Email field
        /// </summary>
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        /// <summary>
        /// Password field
        /// </summary>
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        /// <summary>
        /// Retry Password field
        /// </summary>
        public string RetryPassword
        {
            get => _retryPassword;
            set
            {
                _retryPassword = value;
                OnPropertyChanged(nameof(RetryPassword));
            }
        }


        /// <summary>
        /// Upload Image
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


        /// <summary>
        /// Login Connection
        /// </summary>
        private void Login()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                Shell.Current.DisplayAlert("Sorry Itineros", "All fields are required.", "OK");
                return;
            }
            // Else -> Send the credentials to the back, service or whatever
            // -> Lien qui envoi vers la homepage
            // TODO : Si rien ne correspond, il faudrait afficher un message : "Uknown user" 
        }

        /// <summary>
        /// Register connection 
        /// </summary>
        private async void Register()
        {
            if (Password != RetryPassword)
            {
                await Shell.Current.DisplayAlert("Whooops", "Passwords do not match.", "OK");
                return;
            }

            // TODO : Implémenter une méthode qui en cas de réussite
            await AppShell.Current.GoToAsync($"{nameof(HomePage)}");
        }

        /// <summary>
        /// Method to manage dynamic modification
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
