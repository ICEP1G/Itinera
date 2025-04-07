using Itinera.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.ViewModels.Components
{
    public class RecommendationViewModel : INotifyPropertyChanged
    {
        #region Variables declaration
        public event PropertyChangedEventHandler? PropertyChanged;
        private string recommendations;
        #endregion

        public RecommendationViewModel()
        {
        }


        public string Recommendations
        {
            get { return recommendations; }
            set { recommendations = value; OnPropertyChanged(nameof(Recommendations)); }
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
