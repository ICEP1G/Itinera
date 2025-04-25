using CommunityToolkit.Maui.Core.Extensions;
using CSharpFunctionalExtensions;
using Itinera.Client.Helpers;
using Itinera.Client.Models;
using Itinera.Client.Services;
using Itinera.Client.ViewModels.Components;
using Itinera.DTOs;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

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
        private readonly IPlacelistService _placelistService;

        private TabMenuViewModel tabMenu;
        private PlaceSearchFiltersViewModel placeSearchFiltersOwnedPlacelists;
        private PlaceSearchFiltersViewModel placeSearchFiltersFollowedPlacelists;
        private ObservableCollection<PlacelistHeaderViewModel> ownedPlacelists;
        private ObservableCollection<PlacelistHeaderViewModel> followedPlacelists;

        private ObservableCollection<PlacelistHeaderViewModel> originOwnedPlacelists;
        private ObservableCollection<PlacelistHeaderViewModel> originFollowedPlacelists;

        private bool isPlacelistsOwnedTabSelected;
        private bool isPlacelistsFollowedTabSelected;
        private bool isLoadingPlacelistsPage;
        private bool isLoadingOwnedPlacelists;
        private bool isLoadingFollowedPlacelists;
        private string errorLoadingPlacelistsPageData;
        private string errorLoadingOwnedPlacelistsPageData;
        private string errorLoadingFollowedPlacelistsPageData;
        #endregion

        #region Commands declaration
        public ICommand AddPlacelistCommand { get; }
        #endregion

        public PlacelistsPageViewModel(IPlacelistService placelistService)
        {
            _placelistService = placelistService;

            OwnedPlacelists = new();
            FollowedPlacelists = new();

            //AddPlacelistCommand = new Command(async () => await AddPlacelist());
        }


        public TabMenuViewModel TabMenu
        {
            get { return tabMenu; }
            set { tabMenu = value; OnPropertyChanged(nameof(TabMenu)); }
        }


        public PlaceSearchFiltersViewModel PlaceSearchFiltersOwnedPlacelists
        {
            get { return placeSearchFiltersOwnedPlacelists; }
            set { placeSearchFiltersOwnedPlacelists = value; OnPropertyChanged(nameof(PlaceSearchFiltersOwnedPlacelists)); }
        }

        public PlaceSearchFiltersViewModel PlaceSearchFiltersFollowedPlacelists
        {
            get { return placeSearchFiltersFollowedPlacelists; }
            set { placeSearchFiltersFollowedPlacelists = value; OnPropertyChanged(nameof(PlaceSearchFiltersFollowedPlacelists)); }
        }


        public ObservableCollection<PlacelistHeaderViewModel> OwnedPlacelists
        {
            get { return ownedPlacelists; }
            set { ownedPlacelists = value; OnPropertyChanged(nameof(OwnedPlacelists)); }
        }

        public ObservableCollection<PlacelistHeaderViewModel> FollowedPlacelists
        {
            get { return followedPlacelists; }
            set { followedPlacelists = value; OnPropertyChanged(nameof(FollowedPlacelists)); }
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


        #region Functional properties
        public bool IsLoadingPlacelistsPage
        {
            get { return isLoadingPlacelistsPage; }
            set { isLoadingPlacelistsPage = value; OnPropertyChanged(nameof(IsLoadingPlacelistsPage)); }
        }

        public bool IsLoadingOwnedPlacelists
        {
            get { return isLoadingOwnedPlacelists; }
            set { isLoadingOwnedPlacelists = value; OnPropertyChanged(nameof(IsLoadingOwnedPlacelists)); }
        }

        public bool IsLoadingFollowedPlacelists
        {
            get { return isLoadingFollowedPlacelists; }
            set { isLoadingFollowedPlacelists = value; OnPropertyChanged(nameof(IsLoadingFollowedPlacelists)); }
        }


        public string ErrorLoadingPlacelistsPageData
        {
            get { return errorLoadingPlacelistsPageData; }
            set { errorLoadingPlacelistsPageData = value; OnPropertyChanged(nameof(ErrorLoadingPlacelistsPageData)); }
        }

        public string ErrorLoadingOwnedPlacelistsPageData
        {
            get { return errorLoadingOwnedPlacelistsPageData; }
            set { errorLoadingOwnedPlacelistsPageData = value; OnPropertyChanged(nameof(ErrorLoadingOwnedPlacelistsPageData)); }
        }

        public string ErrorLoadingFollowedPlacelistsPageData
        {
            get { return errorLoadingFollowedPlacelistsPageData; }
            set { errorLoadingFollowedPlacelistsPageData = value; OnPropertyChanged(nameof(ErrorLoadingFollowedPlacelistsPageData)); }
        }
        #endregion



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


        private void LoadOriginOwnedPlacelistsData()
        {
            OwnedPlacelists.Clear();
            foreach (PlacelistHeaderViewModel placelist in originOwnedPlacelists)
            {
                OwnedPlacelists.Add(placelist);
            }
        }

        private void LoadOriginFollowedPlacelistsData()
        {
            FollowedPlacelists.Clear();
            foreach (PlacelistHeaderViewModel placelist in originFollowedPlacelists)
            {
                FollowedPlacelists.Add(placelist);
            }
        }

        public async Task LoadDataAsync()
        {
            if (string.IsNullOrEmpty(CurrentItinerosSession.CurrentItinerosId))
                return;

            IsPlacelistsOwnedTabSelected = true;
            IsPlacelistsFollowedTabSelected = false;
            TabMenu = new("Placelists Owned", null, "Placelists Followed", null);
            TabMenu.TabChanged += OnTabChanged;

            IsLoadingPlacelistsPage = true;
            Result<PlacelistsPageDto> placelistsPage = await _placelistService.GetPlacelistsForPageByItinerosId(CurrentItinerosSession.CurrentItinerosId);
            if (placelistsPage.IsFailure)
            {
                ErrorLoadingPlacelistsPageData = "An error occured during the Placelists retrieval. Please comeback later.";
                IsLoadingPlacelistsPage = false;
            }
            else
            {
                IsLoadingPlacelistsPage = false;

                Task loadOwnedPlacelists = LoadOwnedPlacelistsAsync(placelistsPage.Value.OwnedPlacelists);
                Task loadFollowedPlacelists = LoadFollowedPlacelistsAsync(placelistsPage.Value.FollowedPlacelists);

                await Task.WhenAll(loadOwnedPlacelists, loadFollowedPlacelists);
                await LoadPlaceSearchFilters();
            }
        }

        private async Task LoadOwnedPlacelistsAsync(IEnumerable<PlacelistHeaderDto> ownedPlacelists)
        {
            IsLoadingOwnedPlacelists = true;
            Result<List<PlacelistHeaderViewModel>> ownedPlacelistVMs = await _placelistService.GetPlacelistHeaderViewModels(ownedPlacelists);
            if (ownedPlacelistVMs.IsFailure)
            {
                ErrorLoadingOwnedPlacelistsPageData = "it's impossible to view the owned placelists at the moment. Please comeback later.";
            }
            else
            {
                originOwnedPlacelists = ownedPlacelistVMs.Value.ToObservableCollection();
                LoadOriginOwnedPlacelistsData();
            }
            IsLoadingOwnedPlacelists = false;
        }

        private async Task LoadFollowedPlacelistsAsync(IEnumerable<PlacelistHeaderDto> followedPlacelists)
        {
            IsLoadingFollowedPlacelists = true;
            Result<List<PlacelistHeaderViewModel>> followedPlacelistVMs = await _placelistService.GetPlacelistHeaderViewModels(followedPlacelists);
            if (followedPlacelistVMs.IsFailure)
            {
                ErrorLoadingFollowedPlacelistsPageData = "it's impossible to view the followed placelists at the moment. Please comeback later.";
            }
            else
            {
                originFollowedPlacelists = followedPlacelistVMs.Value.ToObservableCollection();
                LoadOriginFollowedPlacelistsData();
            }
            IsLoadingFollowedPlacelists = false;
        }

        private async Task LoadPlaceSearchFilters()
        {
            Result<PlaceSearchFiltersViewModel> placeSearchFilters = await this.PopulateSearchFilters(OwnedPlacelists);
            if (placeSearchFilters.IsSuccess)
            {
                PlaceSearchFiltersOwnedPlacelists = placeSearchFilters.Value;
                PlaceSearchFiltersOwnedPlacelists.FilterWasTaped += FilterPlaceListCollection;
            }

            Result<PlaceSearchFiltersViewModel> placeSearchFiltersFollowedPl = await this.PopulateSearchFilters(FollowedPlacelists);
            if (placeSearchFiltersFollowedPl.IsSuccess)
            {
                PlaceSearchFiltersFollowedPlacelists = placeSearchFiltersFollowedPl.Value;
                PlaceSearchFiltersFollowedPlacelists.FilterWasTaped += FilterPlaceListCollection;
            }
        }

        private async Task<Result<PlaceSearchFiltersViewModel>> PopulateSearchFilters(IEnumerable<PlacelistHeaderViewModel> placelistHeaders)
        {
            try
            {
                HashSet<string> allFiltersType = new();
                foreach (var placelist in placelistHeaders)
                {
                    foreach (string type in placelist.PlacesPrimaryTypes)
                    {
                        allFiltersType.Add(type);
                    }
                }

                PlaceSearchFiltersViewModel placeSearchFiltersVm = new(ServiceProviderHelper.GetService<IPlaceService>(), allFiltersType);
                return Result.Success(placeSearchFiltersVm);
            }
            catch (Exception ex)
            {
                return Result.Failure<PlaceSearchFiltersViewModel>($"Unexpected error: {ex.Message}");
            }
        }

        private void FilterPlaceListCollection(object sender, ObservableCollection<PlaceTypeFilterViewModel> placeTypeFilters)
        {
            List<string> filtersSelected = placeTypeFilters
                .Where(ptf => ptf.IsSelected)
                .Select(ptf => ptf.PlaceType)
                .ToList();

            if (IsPlacelistsOwnedTabSelected)
            {
                if (filtersSelected.Count == 0)
                {
                    LoadOriginOwnedPlacelistsData();
                    return;
                }

                var filteredValues = originOwnedPlacelists
                    .Where(pl => pl.PlacesPrimaryTypes
                    .Any(primaryType => filtersSelected.Contains(primaryType)))
                    .ToObservableCollection();

                OwnedPlacelists.Clear();
                foreach (PlacelistHeaderViewModel filteredValue in filteredValues)
                    OwnedPlacelists.Add(filteredValue);

            }
            else if (IsPlacelistsFollowedTabSelected)
            {
                if (filtersSelected.Count == 0)
                {
                    LoadOriginFollowedPlacelistsData();
                    return;
                }

                var filteredValues = originFollowedPlacelists
                    .Where(pl => pl.PlacesPrimaryTypes
                    .Any(primaryType => filtersSelected.Contains(primaryType)))
                    .ToObservableCollection();

                FollowedPlacelists.Clear();
                foreach (PlacelistHeaderViewModel filteredValue in filteredValues)
                    FollowedPlacelists.Add(filteredValue);
            }
        }



        public void Dispose()
        {
            if (TabMenu is not null)
                TabMenu.TabChanged -= OnTabChanged;

            if (placeSearchFiltersFollowedPlacelists is not null)
                PlaceSearchFiltersOwnedPlacelists.FilterWasTaped -= FilterPlaceListCollection;

            if (placeSearchFiltersFollowedPlacelists is not null)
                PlaceSearchFiltersFollowedPlacelists.FilterWasTaped -= FilterPlaceListCollection;

            ErrorLoadingPlacelistsPageData = string.Empty;
            ErrorLoadingOwnedPlacelistsPageData = string.Empty;
            ErrorLoadingFollowedPlacelistsPageData = string.Empty;
        }
    }
}
