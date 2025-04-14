using Itinera.Client.Helpers;
using Itinera.Client.ViewModels.Components;
using Itinera.Client.Views.Components;
using Itinera.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.Services
{
    public class FakeDataService
    {
        public FakeDataService()
        {
        }


        public PlacelistHeaderViewModel GetPlacelistViewModel()
        {
            PlacelistHeaderViewModel placeListVm = new(ServiceProviderHelper.GetService<PlaceService>())
            {
                Id = "5",
                Name = "Tournée des bars",
                Description = "Les bars les plus tendances de strasbourg pour l'année 2025 et plus à venir. :)",
                ImageUrl = "https://medias.student-factory.com/_medias-student-prod_/d496499b-a7e3-4a66-8e67-62867f19087f/Maltdown.webp",
                PlacesPrimaryTypes = new HashSet<string>() { "Restaurant", "Bar" },
                RecommendationCount = 107
            };

            return placeListVm;
        }


        public List<PlacelistHeaderViewModel> GetPlacelistHeaderViewModelsCollection()
        {
            List<PlacelistHeaderViewModel> placelistHeaderVMs = new()
            {
                new PlacelistHeaderViewModel(ServiceProviderHelper.GetService<PlaceService>())
                {
                    Id = "1",
                    Name = "Strasbourg mon amour",
                    Description = "Placelist from my journey in Alsace in august 2024.",
                    ImageUrl = "https://www.visitfrenchwine.com/sites/default/files/niedermorschwihr-photo-zvardon-conseil-vins-alsace.jpg",
                    PlacesPrimaryTypes = new HashSet<string>() { "Restaurant", "Museum", "Historic", "Place" },
                    RecommendationCount = 123
                },
                new PlacelistHeaderViewModel(ServiceProviderHelper.GetService<PlaceService>())
                {
                    Id = "3",
                    Name = "London 2025",
                    Description = "Places I want to visit next time I go to London.",
                    ImageUrl = "https://www.visitbritain.com/sites/cms/files/styles/page_header_ve_sm/public/lookatmedam/2283200f-48bc-4fb6-943a-dd17ee28d1cfl.jpg?h=d3c75ecd&itok=jRJj5uwX",
                    PlacesPrimaryTypes = new HashSet<string>() { "Restaurant", "Place", "Historic", "Park", "Camping", "Cemetery" },
                    RecommendationCount = 17
                },
            };

            return placelistHeaderVMs;
        }


        public List<PlaceHeaderViewModel> GetPlaceHeaderViewModelCollection()
        {
            List<PlaceHeaderViewModel> placeHeaderVMs = new()
            {
                new PlaceHeaderViewModel(ServiceProviderHelper.GetService<PlaceService>()) 
                {   
                    Id = "18", 
                    Name = "Picobello", 
                    Address = "21 Rue des Frères, 67000 Strasbourg", 
                    PrimaryType = "Restaurant",
                    TodaySchedules = "12:00 – 15:00, 19:00 – 22:00", 
                    PrimaryImageUrl = "https://lh3.googleusercontent.com/p/AF1QipMpFRCh5R-A5Q3iJGQoe2lJAcvJ76W8mdjk0y8T=s680-w680-h510"
                },
                new PlaceHeaderViewModel(ServiceProviderHelper.GetService<PlaceService>()) 
                { 
                    Id = "19",
                    Name = "Mama Bubbele", 
                    Address = "2 Quai des Bateliers, 67000 Strasbourg", 
                    PrimaryType = "Restaurant",
                    TodaySchedules = "12:00 – 15:00, 18:00 – 22:30", 
                    PrimaryImageUrl = "https://lh3.googleusercontent.com/p/AF1QipNUkyYVJBXN_L8cxo3I43swFbs2lJSz3nVy7w-v=s680-w680-h510-rw"
                },
                new PlaceHeaderViewModel(ServiceProviderHelper.GetService<PlaceService>()) 
                { 
                    Id = "20", 
                    Name = "Umaï Ramen", 
                    Address = "5 Rue des Orphelins, 67000 Strasbourg", 
                    PrimaryType = "Place",
                    TodaySchedules = "12:00 – 14:00, 19:00 – 21:00", 
                    PrimaryImageUrl = "https://lh3.googleusercontent.com/p/AF1QipOri94Z3zC8Zhc3hacQ7FV7JUIZcLhf9VnroITG=s680-w680-h510"
                }
            };

            return placeHeaderVMs;
        }
    }
}
