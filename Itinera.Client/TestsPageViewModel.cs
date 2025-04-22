using CommunityToolkit.Maui.Core.Extensions;
using Itinera.Client.Helpers;
using Itinera.Client.Services;
using Itinera.Client.ViewModels.Components;
using Itinera.Client.Views.Components;
using Itinera.DTOs;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Itinera.Client
{
    public class TestsPageViewModel : INotifyPropertyChanged, IDisposable
    {
        #region NotifyChanges declaration
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Variables declaration
        private readonly FakeDataService _fakeDataService;

        private List<PlaceHeaderViewModel> placeHeaderList;
        private ObservableCollection<PlacelistHeaderViewModel> placelistHeaderList;
        private int recommendationCount;
        #endregion

        public TestsPageViewModel(FakeDataService fakeDataService)
        {
            _fakeDataService = fakeDataService;


            TabMenu = new("Overview", null, "Review", 23);
            TabMenu.TabChanged += OnTabChanged;

            originalPlaceListHeaderVm = _fakeDataService.GetPlacelistHeaderViewModelsCollection().ToObservableCollection();
            PlacelistHeaderList = new();
            if (originalPlaceListHeaderVm is not null)
            {
                foreach (PlacelistHeaderViewModel placelist in originalPlaceListHeaderVm)
                {
                    PlacelistHeaderList.Add(placelist);
                }
            }

            PlaceHeaderList = _fakeDataService.GetPlaceHeaderViewModelCollection();

            HashSet<string> allFiltersType = new();
            foreach (var placeList in PlacelistHeaderList)
            {
                foreach (string type in placeList.PlacesPrimaryTypes)
                {
                    allFiltersType.Add(type);
                }
            }

            PlaceSearchFiltersVm = new(ServiceProviderHelper.GetService<IPlaceService>(), allFiltersType);
            PlaceSearchFiltersVm.FilterWasTaped += FilterPlaceListCollection;

            RecommendationCount = 222;

            AddPlacelistCommand = new Command(AddPlacelist);
        }


        private void OnTabChanged(object sender, int selectedTabIndex)
        {
            if (selectedTabIndex == 0)
            {
                TabChanged = "Premier onglet activé";
            }
            else if (selectedTabIndex == 1)
            {
                TabChanged = "Deuxième onglet activé";
            }
        }


        private ObservableCollection<PlacelistHeaderViewModel> originalPlaceListHeaderVm;

        private void FilterPlaceListCollection(object sender, ObservableCollection<PlaceTypeFilterViewModel> placeTypeFilters)
        {
            List<string> filtersSelected = placeTypeFilters
                .Where(ptf => ptf.IsSelected)
                .Select(ptf => ptf.PlaceType)
                .ToList();

            if (filtersSelected.Count == 0)
            {
                //PlacelistHeaderList = new ObservableCollection<PlacelistHeaderViewModel>(originalPlaceListHeaderVm); ;
                PlacelistHeaderList.Clear();
                foreach (PlacelistHeaderViewModel originalPlacelist in originalPlaceListHeaderVm)
                {
                    PlacelistHeaderList.Add(originalPlacelist);
                }
                return;
            }

            var filteredValues = originalPlaceListHeaderVm
                .Where(pl => pl.PlacesPrimaryTypes
                    .Any(primaryType => filtersSelected.Contains(primaryType)))
                .ToObservableCollection();

            PlacelistHeaderList.Clear();
            foreach (PlacelistHeaderViewModel filteredValue in filteredValues)
            {
                PlacelistHeaderList.Add(filteredValue);
            }
        }


        private string tabChanged;

        public string TabChanged
        {
            get { return tabChanged; }
            set { tabChanged = value; OnPropertyChanged(nameof(TabChanged)); }
        }


        private PlaceSearchFiltersViewModel placeSearchFiltersVm;

        public PlaceSearchFiltersViewModel PlaceSearchFiltersVm
        {
            get { return placeSearchFiltersVm; }
            set { placeSearchFiltersVm = value; OnPropertyChanged(nameof(PlaceSearchFiltersVm)); }
        }



        public ObservableCollection<PlacelistHeaderViewModel> PlacelistHeaderList
        {
            get { return placelistHeaderList; }
            set { placelistHeaderList = value; OnPropertyChanged(nameof(PlacelistHeaderList)); }
        }


        public List<PlaceHeaderViewModel> PlaceHeaderList
        {
            get { return placeHeaderList; }
            set { placeHeaderList = value; OnPropertyChanged(nameof(PlaceHeaderList)); }
        }

        private TabMenuViewModel tabMenu;

        public TabMenuViewModel TabMenu
        {
            get { return tabMenu; }
            set { tabMenu = value; OnPropertyChanged(nameof(TabMenu)); }
        }


        public int RecommendationCount
        {
            get { return recommendationCount; }
            set { recommendationCount = value; OnPropertyChanged(nameof(RecommendationCount)); }
        }



        public ICommand AddPlacelistCommand { get; }

        private void AddPlacelist()
        {
            PlacelistHeaderViewModel placeList = _fakeDataService.GetPlacelistViewModel();
            PlacelistHeaderList.Add(placeList);
            originalPlaceListHeaderVm.Add(placeList);
            PlaceSearchFiltersVm.AddPlaceTypeFilter(placeList.PlacesPrimaryTypes);
        }



        public void Dispose()
        {
            // Allow the ViewModel to dispose the resources from the child ContentView
            TabMenu.TabChanged -= OnTabChanged;
            PlaceSearchFiltersVm.FilterWasTaped -= FilterPlaceListCollection;
        }
    }
}
