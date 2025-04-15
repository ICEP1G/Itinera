using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.ViewModels
{
    [QueryProperty(nameof(PlaceId), "PlaceId")]
    public class PlacePageViewModel : INotifyPropertyChanged
    {
        #region NotifyChanges declaration
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Variables declaration
        private string placeId;
        #endregion

        public PlacePageViewModel()
        {
            
        }


        public string PlaceId
        {
            get { return placeId; }
            set { placeId = value; OnPropertyChanged(nameof(PlaceId)); }
        }

    }
}
