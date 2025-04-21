using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.ViewModels.Pages
{
    [QueryProperty(nameof(ItinerosId), "ItinerosId")]
    public class ItinerosPageViewModel : INotifyPropertyChanged
    {
        #region NotifyChanges declaration
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Variables declaration
        private string itinerosId;
        #endregion

        public ItinerosPageViewModel()
        {
            
        }

        public string ItinerosId
        {
            get { return itinerosId; }
            set { itinerosId = value; OnPropertyChanged(nameof(ItinerosId)); }
        }
    }
}
