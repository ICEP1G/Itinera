using Itinera.Client.Helpers;
using Itinera.Client.ViewModels.Components;
using Itinera.DTOs;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Itinera.Client
{
    public class TestsPageViewModel : INotifyPropertyChanged
    {
        #region Variables declaration
        public event PropertyChangedEventHandler? PropertyChanged;
        private List<PlaceHeaderViewModel> placeHeaderList;
        private PlaceHeaderViewModel placeHeader;
        #endregion

        public TestsPageViewModel()
        {

            PlaceHeaderList = new();
            List<PlaceHeaderDto> newPlaceHeaderList = new()
            {
                new PlaceHeaderDto() { PlaceId = "18", Name = "Picobello", Address = "21 Rue des Frères, 67000 Strasbourg", PlacePrimaryType = "Restaurant",
                    TodaySchedules = "12:00 – 15:00, 19:00 – 22:00", PlacePrimaryImageUrl = "https://lh3.googleusercontent.com/p/AF1QipMpFRCh5R-A5Q3iJGQoe2lJAcvJ76W8mdjk0y8T=s680-w680-h510"},
                new PlaceHeaderDto() { PlaceId = "19", Name = "Mama Bubbele", Address = "2 Quai des Bateliers, 67000 Strasbourg", PlacePrimaryType = "Restaurant",
                    TodaySchedules = "12:00 – 15:00, 18:00 – 22:30", PlacePrimaryImageUrl = "https://lh3.googleusercontent.com/p/AF1QipNUkyYVJBXN_L8cxo3I43swFbs2lJSz3nVy7w-v=s680-w680-h510-rw"},
                new PlaceHeaderDto() { PlaceId = "20", Name = "Umaï Ramen", Address = "5 Rue des Orphelins, 67000 Strasbourg", PlacePrimaryType = "Resaurant",
                    TodaySchedules = "12:00 – 14:00, 19:00 – 21:00", PlacePrimaryImageUrl = "https://lh3.googleusercontent.com/p/AF1QipOri94Z3zC8Zhc3hacQ7FV7JUIZcLhf9VnroITG=s680-w680-h510"}
            };

            foreach (var item in newPlaceHeaderList)
            {
                PlaceHeaderViewModel placeHeaderVm = ServiceProviderHelper.GetService<PlaceHeaderViewModel>();
                placeHeaderVm.Id = item.PlaceId;
                placeHeaderVm.Name = item.Name;
                placeHeaderVm.Address = item.Address;
                placeHeaderVm.PrimaryType = item.PlacePrimaryType;
                placeHeaderVm.PrimaryImageUrl = item.PlacePrimaryImageUrl;
                placeHeaderVm.TodaySchedules = item.TodaySchedules;

                PlaceHeaderList.Add(placeHeaderVm);
            }

            PlaceHeaderDto placeHeaderDto = new()
            {
                PlaceId = "18",
                Name = "Picobello",
                Address = "21 Rue des Frères, 67000 Strasbourg",
                PlacePrimaryType = "Restaurant",
                TodaySchedules = "12:00 – 15:00, 19:00 – 22:00",
                PlacePrimaryImageUrl = "https://lh3.googleusercontent.com/p/AF1QipMpFRCh5R-A5Q3iJGQoe2lJAcvJ76W8mdjk0y8T=s680-w680-h510"
            };
            PlaceHeaderViewModel placeHeaderVM = ServiceProviderHelper.GetService<PlaceHeaderViewModel>();
            placeHeaderVM.Name = placeHeaderDto.Name;
            placeHeaderVM.Address = placeHeaderDto.Address;
            placeHeaderVM.PrimaryType = placeHeaderDto.PlacePrimaryType;
            placeHeaderVM.PrimaryImageUrl = placeHeaderDto.PlacePrimaryImageUrl;
            placeHeaderVM.TodaySchedules = placeHeaderDto.TodaySchedules;
            PlaceHeader = placeHeaderVM;

            RecommendationCount = 222;

            UpdatePropertyCommand = new Command(UpdateProperty);
        }


        public List<PlaceHeaderViewModel> PlaceHeaderList
        {
            get { return placeHeaderList; }
            set { placeHeaderList = value; OnPropertyChanged(nameof(PlaceHeaderList)); }
        }

        public PlaceHeaderViewModel PlaceHeader
        {
            get { return placeHeader; }
            set { placeHeader = value; OnPropertyChanged(nameof(PlaceHeader)); }
        }


        private int recommendationCount;
        public int RecommendationCount
        {
            get { return recommendationCount; }
            set { recommendationCount = value; OnPropertyChanged(nameof(RecommendationCount)); }
        }





        public ICommand UpdatePropertyCommand { get; }

        private void UpdateProperty()
        {
            RecommendationCount += 1;
        }




        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
