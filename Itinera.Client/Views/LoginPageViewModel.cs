using System.ComponentModel;
using System.Windows.Input;

namespace Itinera.Client.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        #region Variables declaration
        public event PropertyChangedEventHandler? PropertyChanged;
        private string _username;
        private string _password;
        private bool _isLoginAreaVisible;
        private bool _isRegisterAreaVisible;
        private ImageSource _uploadedImageSource;
        #endregion

        #region Commands Declaration
        public ICommand ShowLoginAreaCommand { get; }
        public ICommand HideLoginAreaCommand { get; }
        public ICommand LoginCommand { get; }
        public ICommand ShowRegisterAreaCommand { get; }
        public ICommand HideRegisterAreaCommand { get;  }
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
            ShowRegisterAreaCommand = new Command(() => IsRegisterAreaVisible = true);
            HideRegisterAreaCommand = new Command(() => IsRegisterAreaVisible = false);
            UploadPhotoCommand = new Command(async () => await UploadPhotoAsync());
            IsLoginAreaVisible = false;
            UploadedImageSource = null;
        }

        public bool IsLoginAreaVisible
        {
            get => _isLoginAreaVisible;
            set
            {
                _isLoginAreaVisible = value;
                OnPropertyChanged(nameof(IsLoginAreaVisible));
            }
        }

        public bool IsRegisterAreaVisible
        {
            get => _isRegisterAreaVisible;
            set
            {
                _isRegisterAreaVisible = value;
                OnPropertyChanged(nameof(IsRegisterAreaVisible));
            }
        }

        /// <summary>
        /// Username field
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


        /// <summary>
        /// Connection method 
        /// </summary>
        private void Login()
        {
           // Logic to transfert login / password to the back, service, dto...
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
        /// Method to manage dynamic modification
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
