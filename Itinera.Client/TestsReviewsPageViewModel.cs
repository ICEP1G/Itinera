using CommunityToolkit.Maui.Core.Extensions;
using Itinera.Client.Helpers;
using Itinera.Client.Services;
using Itinera.Client.ViewModels.Components;
using Itinera.DTOs;
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
    public class TestsReviewsPageViewModel : INotifyPropertyChanged
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

        private ReviewViewModel reviewVm;
        private ObservableCollection<ReviewViewModel> reviewCollectionVm;
        #endregion

        #region Commands declaration
        #endregion

        public TestsReviewsPageViewModel(FakeDataService fakeDataService)
        {
            _fakeDataService = fakeDataService;

            ReviewVm = _fakeDataService.GetReviewViewModel();
            ReviewCollectionVm = _fakeDataService.GetReviewViewModelCollection().ToObservableCollection();
        }


        public ReviewViewModel ReviewVm
        {
            get { return reviewVm; }
            set { reviewVm = value; OnPropertyChanged(nameof(ReviewVm)); }
        }

        public ObservableCollection<ReviewViewModel> ReviewCollectionVm
        {
            get { return reviewCollectionVm; }
            set { reviewCollectionVm = value; OnPropertyChanged(nameof(ReviewCollectionVm)); }
        }


    }
}
