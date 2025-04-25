using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.ViewModels.Pages
{
    [QueryProperty(nameof(PlacelistId), "PlacelistId")]
    public class PlacelistDetailPageViewModel : INotifyPropertyChanged
    {
        #region NotifyChanges declaration
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Variables declaration
        private string placelistId;
        #endregion



        public PlacelistDetailPageViewModel()
        {
            
        }


        public string PlacelistId
        {
            get { return placelistId; }
            set { placelistId = value; OnPropertyChanged(nameof(PlacelistId)); }
        }
    }
}
