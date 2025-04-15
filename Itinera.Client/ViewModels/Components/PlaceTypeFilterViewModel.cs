using Itinera.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.ViewModels.Components
{
    public class PlaceTypeFilterViewModel : INotifyPropertyChanged
    {
        #region NotifyChanges declaration
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Variables declaration
        private string placeType;
        private string placeIconUri;
        private bool isSelected;
        #endregion

        public PlaceTypeFilterViewModel(string placeType, string placeIconUri, bool isSelected = false)
        {
            PlaceType = placeType;
            PlaceIconUri = placeIconUri;
            IsSelected = isSelected;
        }


        public string PlaceType
        {
            get { return placeType; }
            set { placeType = value; OnPropertyChanged(nameof(PlaceType)); }
        }

        public string PlaceIconUri
        {
            get { return placeIconUri; }
            set { placeIconUri = value; OnPropertyChanged(nameof(PlaceIconUri)); }
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; OnPropertyChanged(nameof(IsSelected)); }
        }


    }
}
