using Itinera.Client.ViewModels.Components;
using System.ComponentModel;
using System.Windows.Input;

namespace Itinera.Client.ViewModels.Pages
{
    public class SettingsPageViewModel : INotifyPropertyChanged
    {

        #region NotifyChanges declaration
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Commands Declaration
        public ICommand SettingsCommand { get; }
        public ICommand GoBackCommand { get; }
        #endregion

        #region Variables declaration
        private TabMenuViewModel _tabMenu;
        private bool isUpdateProfilTabSelected;
        private bool isUpdateSettingAccountTabSelected;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public SettingsPageViewModel()
        {
            GoBackCommand = new Command(GetBackToProfilPage);

            TabMenu = new TabMenuViewModel("Update profil", null, "Update account", null);
            TabMenu.TabChanged += OnTabChanged;

            IsUpdateProfilTabSelected = true;
            IsUpdateSettingAccountTabSelected = false;
        }

        // TODO : Voir la possibilité de faire différemment car ProfilPage est dans la tabBar de AppShell donc impossible d'utiliser AppShell
        public async void GetBackToProfilPage()
        {
            await Shell.Current.GoToAsync("///ProfilPage");

        }

        public bool IsUpdateProfilTabSelected
        {
            get { return isUpdateProfilTabSelected; }
            set { isUpdateProfilTabSelected = value; OnPropertyChanged(nameof(isUpdateProfilTabSelected)); }
        }

        public bool IsUpdateSettingAccountTabSelected
        {
            get { return isUpdateSettingAccountTabSelected; }
            set { isUpdateSettingAccountTabSelected = value; 
                OnPropertyChanged(nameof(isUpdateSettingAccountTabSelected)); }
        }

        public TabMenuViewModel TabMenu
        {
            get { return _tabMenu; }
            set { _tabMenu = value; OnPropertyChanged(nameof(TabMenu)); }
        }

        private void OnTabChanged(object sender, int selectedTabIndex)
        {
            IsUpdateProfilTabSelected = selectedTabIndex == 0;
            IsUpdateSettingAccountTabSelected = selectedTabIndex == 1;

            OnPropertyChanged(string.Empty);
        }

    }
}
