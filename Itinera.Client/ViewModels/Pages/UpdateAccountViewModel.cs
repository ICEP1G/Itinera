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
        #endregion

        /// <summary>
        ///  Constructor by defaut
        /// </summary>
        public UpdateAccountViewModel()
        {
            GoBackCommand = new Command(GetBackToProfilPage);
        }

        public async void GetBackToProfilPage()
        {
            await Shell.Current.GoToAsync("///ProfilPage");
        }
    }
}
