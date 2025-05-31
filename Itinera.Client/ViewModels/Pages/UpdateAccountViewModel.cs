using CommunityToolkit.Maui.Views;
using Itinera.Client.Views.Elements;
using System.ComponentModel;
using System.Windows.Input;

namespace Itinera.Client.ViewModels.Pages
{
    public class UpdateAccountViewModel : INotifyPropertyChanged
    {
        #region NotifyChanges declaration
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Commands Declaration
        public ICommand GoBackCommand { get; }
        public ICommand ForgotPasswordCommand { get; }
        #endregion

        /// <summary>
        ///  Constructor by defaut
        /// </summary>
        public UpdateAccountViewModel()
        {
            GoBackCommand = new Command(GetBackToProfilPage);
            ForgotPasswordCommand = new Command(ShowForgotPasswordPopup);
        }

        public async void GetBackToProfilPage()
        {
            await AppShell.Current.GoToAsync("..", true);
        }

        public async void ShowForgotPasswordPopup()
        {
            var popup = new PasswordForgot();
            await Application.Current.MainPage.ShowPopupAsync(popup);
        }
    }
}
