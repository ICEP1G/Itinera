using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.ViewModels
{
    [QueryProperty(nameof(PlacelistId), "PlacelistId")]
    public class PlacelistPageViewModel : INotifyPropertyChanged
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

        public PlacelistPageViewModel()
        {
            
        }


        public string PlacelistId
        {
            get { return placelistId; }
            set { placelistId = value; OnPropertyChanged(nameof(PlacelistId)); }
        }
    }
}
