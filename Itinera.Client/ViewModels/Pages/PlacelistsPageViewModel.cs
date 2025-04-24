using Itinera.Client.ViewModels.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.ViewModels
{
    
    public class PlacelistsPageViewModel : INotifyPropertyChanged, IDisposable 
    {
        #region NotifyChanges declaration
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Variables declaration
        private TabMenuViewModel tabMenu;
        private PlaceSearchFiltersViewModel placeSearchFilters;
        private ObservableCollection<PlacelistHeaderViewModel> placelistHeaders;

        private bool isPlacelistsOwnedTabSelected;
        private bool isPlacelistsFollowedTabSelected;
        #endregion

        public PlacelistsPageViewModel()
        {
            
        }


        public TabMenuViewModel TabMenu
        {
            get { return tabMenu; }
            set { tabMenu = value; OnPropertyChanged(nameof(TabMenu)); }
        }

        public PlaceSearchFiltersViewModel PlaceSearchFilters
        {
            get { return placeSearchFilters; }
            set { placeSearchFilters = value; OnPropertyChanged(nameof(PlaceSearchFilters)); }
        }
        public ObservableCollection<PlacelistHeaderViewModel> PlacelistHeaders
        {
            get { return placelistHeaders; }
            set { placelistHeaders = value; OnPropertyChanged(nameof(PlacelistHeaders)); }
        }


        public bool IsPlacelistsOwnedTabSelected
        {
            get { return isPlacelistsOwnedTabSelected; }
            set { isPlacelistsOwnedTabSelected = value; OnPropertyChanged(nameof(IsPlacelistsOwnedTabSelected)); }
        }

        public bool IsPlacelistsFollowedTabSelected
        {
            get { return isPlacelistsFollowedTabSelected; }
            set { isPlacelistsFollowedTabSelected = value; OnPropertyChanged(nameof(IsPlacelistsFollowedTabSelected)); }
        }



        private void OnTabChanged(object sender, int selectedTabIndex)
        {
            if (selectedTabIndex == 0)
            {
                IsPlacelistsOwnedTabSelected = true;
                IsPlacelistsFollowedTabSelected = false;
            }
            else if (selectedTabIndex == 1)
            {
                IsPlacelistsFollowedTabSelected = true;
                IsPlacelistsOwnedTabSelected = false;
            }
        }



        public async Task LoadDataAsync()
        {
            IsPlacelistsOwnedTabSelected = true;
            TabMenu = new("Placelists Owned", null, "Placelists Followed", null);
            TabMenu.TabChanged += OnTabChanged;
        }



        public void Dispose()
        {
            TabMenu.TabChanged -= OnTabChanged;
        }
    }
}
