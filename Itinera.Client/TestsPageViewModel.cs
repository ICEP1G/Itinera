using CommunityToolkit.Maui.Core.Extensions;
using Itinera.Client.Helpers;
using Itinera.Client.Services;
using Itinera.Client.ViewModels.Components;
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
    public class TestsPageViewModel : INotifyPropertyChanged
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

            PlacelistHeaderList = _fakeDataService.GetPlacelistHeaderViewModelsCollection().ToObservableCollection();
            PlaceHeaderList = _fakeDataService.GetPlaceHeaderViewModelCollection();

            RecommendationCount = 222;

            UpdatePropertyCommand = new Command(UpdateProperty);
            AddPlacelistCommand = new Command(AddPlacelist);
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


        public int RecommendationCount
        {
            get { return recommendationCount; }
            set { recommendationCount = value; OnPropertyChanged(nameof(RecommendationCount)); }
        }





        public ICommand UpdatePropertyCommand { get; }
        public ICommand AddPlacelistCommand { get; }

        private void AddPlacelist()
        {
            PlacelistHeaderViewModel placeList = _fakeDataService.GetPlacelistViewModel();
            PlacelistHeaderList.Add(placeList);
        }

        private void UpdateProperty()
        {
            RecommendationCount += 1;
        }

    }
}
