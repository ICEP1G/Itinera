using CommunityToolkit.Maui.Core.Extensions;
using Itinera.Client.Helpers;
using Itinera.Client.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Itinera.Client.ViewModels.Components
{
    public class PlaceSearchFiltersViewModel : INotifyPropertyChanged
    {
        #region NotifyChanges declaration
        public event EventHandler<ObservableCollection<PlaceTypeFilterViewModel>>? FilterWasTaped;
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Variables declaration
        private readonly IPlaceService _placeService;

        private ObservableCollection<PlaceTypeFilterViewModel> placeTypeFilters;
        #endregion

        #region Commands declaration
        public ICommand SelectFilterCommand { get; }
        #endregion

        public PlaceSearchFiltersViewModel(IPlaceService placeService, HashSet<string> placeTypes)
        {
            _placeService = placeService;

            PlaceTypeFilters = new();
            if (placeTypes is not null && placeTypes.Count > 0)
            {
                AddPlaceTypeFilter(placeTypes);
            }

            SelectFilterCommand = new Command<PlaceTypeFilterViewModel>(OnFilterSelected);
        }


        public ObservableCollection<PlaceTypeFilterViewModel> PlaceTypeFilters
        {
            get { return placeTypeFilters; }
            set { placeTypeFilters = value; OnPropertyChanged(nameof(PlaceTypeFilters)); }
        }


        private void OnFilterSelected(PlaceTypeFilterViewModel filter)
        {
            filter.IsSelected = !filter.IsSelected;
            FilterWasTaped?.Invoke(this, PlaceTypeFilters);
        }


        /// <summary>
        /// Add only one filter to the collection (it doesn't add the filter if it's already in the filter collection)
        /// </summary>
        /// <param name="placeTypeFilter"></param>
        public void AddPlaceTypeFilter(string placeTypeFilter)
        {
            (bool isFound, string iconUri) iconUri = _placeService.GetCorrectPlaceIconUri(placeTypeFilter);
            if (iconUri.isFound)
            {
                bool alreadyExist = PlaceTypeFilters.Any(p => p.PlaceType == iconUri.iconUri);
                if (!alreadyExist)
                {
                    PlaceTypeFilterViewModel newPlaceTypeFilter = new(placeTypeFilter, iconUri.iconUri, false);
                    PlaceTypeFilters.Add(newPlaceTypeFilter);

                    FilterWasTaped?.Invoke(this, placeTypeFilters);
                }
            }
        }

        /// <summary>
        /// Add multiple filters to the collection (it doesn't add the filter if it's already in the filter collection)
        /// </summary>
        /// <param name="placePrimaryTypes"></param>
        public void AddPlaceTypeFilter(HashSet<string> placePrimaryTypes)
        {
            Dictionary<string, string> typesAndUris = _placeService.GetCorrectPlaceIconUrisAndTypes(placePrimaryTypes);
            foreach (var kvp in typesAndUris)
            {
                bool alreadyExist = PlaceTypeFilters.Any(p => p.PlaceType == kvp.Key);
                if (!alreadyExist)
                {
                    PlaceTypeFilterViewModel newPlaceTypeFilter = new(kvp.Key, kvp.Value, false);
                    PlaceTypeFilters.Add(newPlaceTypeFilter);

                    FilterWasTaped?.Invoke(this, placeTypeFilters);
                }
            }
        }

        /// <summary>
        /// Remove only one filter to the collection
        /// </summary>
        /// <param name="placeTypeFilter"></param>
        public void RemovePlaceTypeFilter(string placeTypeFilter)
        {
            PlaceTypeFilterViewModel? existingFilter = PlaceTypeFilters.FirstOrDefault(ptf =>  ptf.PlaceType == placeTypeFilter);
            if (existingFilter is not null)
            {
                PlaceTypeFilters.Remove(existingFilter);
            }
        }

        /// <summary>
        /// Remove multiple filters to the collection
        /// </summary>
        /// <param name="placePrimaryTypes"></param>
        public void RemovePlaceTypeFilter(HashSet<string> placePrimaryTypes)
        {
            List<PlaceTypeFilterViewModel>? existingFilters = PlaceTypeFilters
                .Where(ptf => placePrimaryTypes
                .Contains(ptf.PlaceType)).ToList();

            if (existingFilters is not null)
            {
                foreach (PlaceTypeFilterViewModel filter in existingFilters)
                {
                    PlaceTypeFilters.Remove(filter);
                }
            }
        }


        public void Dispose()
        {
            FilterWasTaped = null;
        }
    }
}
