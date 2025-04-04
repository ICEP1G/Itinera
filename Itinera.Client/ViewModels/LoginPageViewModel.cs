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
        #endregion

        #region Commands Declaration
        public ICommand ShowLoginAreaCommand { get; }
        public ICommand HideLoginAreaCommand { get; }
        public ICommand LoginCommand { get; }
        public ICommand ShowRegisterAreaCommand { get; }
        public ICommand HideRegisterAreaCommand { get;  }
        #endregion

        /// <summary>
        /// Constructor By Default
        /// </summary>
        public LoginPageViewModel()
        {
            ShowLoginAreaCommand = new Command(() => IsLoginAreaVisible = true);
            HideLoginAreaCommand = new Command(() => IsLoginAreaVisible = false);
            LoginCommand = new Command(Login);
            IsLoginAreaVisible = false;
            ShowRegisterAreaCommand = new Command(() => IsRegisterAreaVisible = true);
            HideRegisterAreaCommand = new Command(() => IsRegisterAreaVisible = false);
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
        /// Connection method 
        /// </summary>
        private void Login()
        {
           // Logic to transfert login / password to the back, service, dto...
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
