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


        public ReviewViewModel GetReviewViewModel()
        {
            ReviewViewModel reviewVm = new(ServiceProviderHelper.GetService<PlaceService>())
            {
                ReviewId = "1",
                ItinerosId = "1",
                ItinerosFirstName = "Meyling-Françoise",
                ItinerosProfilPictureUrl = "https://as2.ftcdn.net/jpg/05/77/44/79/1000_F_577447922_ftBwSdFt6yfAKPCoWuOPOGmuaxoXlWky.jpg",
                ItinerosCity = "Strasbourg",

                PlaceId = "1",
                PlaceName = "Picobello",
                PlaceType = "Restaurant",
                PlaceCity = "Strasbourg",
                PlaceFirstPictureUrl = "https://lh3.googleusercontent.com/p/AF1QipMpFRCh5R-A5Q3iJGQoe2lJAcvJ76W8mdjk0y8T=s680-w680-h510",
                LastModificationDate = DateTime.Now.AddDays(-3),
                ImageUrl = "https://lh3.googleusercontent.com/gps-cs-s/AB5caB8f5q_9hh2eEXiYBV1wOVeKLOPiysg_UNXXMX2tx-rVOGzP2G_H8rXmsihIHOqcSAs6BqFZuwBItoeVcOjbjNlV-2NoGliIN-rq_hrTWOVcPtdQwOXzza650jslWdIvvav179A=s680-w680-h510",
                Message = "The place is very charming, the food is excellent, the quantities are ideal to be able to enjoy a dessert and the staff is warm, attentive and professional."
            };

            return reviewVm;
        }

        public List<ReviewViewModel> GetReviewViewModelCollection()
        {
            List<ReviewViewModel> reviewVMs = new()
            {
                new ReviewViewModel(ServiceProviderHelper.GetService<PlaceService>())
                {
                    ReviewId = "23",
                    ItinerosId = "1",
                    ItinerosFirstName = "Meyling-Françoise",
                    ItinerosProfilPictureUrl = "https://as2.ftcdn.net/jpg/05/77/44/79/1000_F_577447922_ftBwSdFt6yfAKPCoWuOPOGmuaxoXlWky.jpg",
                    ItinerosCity = "Strasbourg",

                    PlaceId = "1",
                    PlaceName = "Picobello",
                    PlaceType = "Restaurant",
                    PlaceCity = "Strasbourg",
                    PlaceFirstPictureUrl = "https://lh3.googleusercontent.com/p/AF1QipMpFRCh5R-A5Q3iJGQoe2lJAcvJ76W8mdjk0y8T=s680-w680-h510",
                    LastModificationDate = DateTime.Now.AddDays(-3),
                    ImageUrl = "https://lh3.googleusercontent.com/gps-cs-s/AB5caB8f5q_9hh2eEXiYBV1wOVeKLOPiysg_UNXXMX2tx-rVOGzP2G_H8rXmsihIHOqcSAs6BqFZuwBItoeVcOjbjNlV-2NoGliIN-rq_hrTWOVcPtdQwOXzza650jslWdIvvav179A=s680-w680-h510",
                    Message = "The place is very charming, the food is excellent, the quantities are ideal to be able to enjoy a dessert and the staff is warm, attentive and professional.",

                    IsViewFromItinerosPage = false,
                    IsEven = false
                },
                new ReviewViewModel(ServiceProviderHelper.GetService<PlaceService>())
                {
                    ReviewId = "17",
                    ItinerosId = "7",
                    ItinerosFirstName = "Barbara",
                    ItinerosProfilPictureUrl = "https://media.irishpost.co.uk/uploads/2017/05/Redhead_8.jpg",
                    ItinerosCity = "Nancy",

                    PlaceId = "3",
                    PlaceName = "Alma",
                    PlaceType = "Restaurant",
                    PlaceCity = "Strasbourg",
                    PlaceFirstPictureUrl = "https://lh3.googleusercontent.com/p/AF1QipNLOFEP1Su3KNInzADW1GcwYBPMp9O58XdInLix=s680-w680-h510",
                    LastModificationDate = DateTime.Now.AddDays(-9),
                    ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipOWRfEhiuz8TLhPK-YIyvPdKcwew6pNt6Abx34k=s680-w680-h510",
                    Message = "How it is possible that I've never been to this restaurant! A gem of fusion cuisine, exquisite flavors, fresh and quality ingredients and all with a very attractive presentation of the dishes. In short, it's beautiful and very good, and what's more, the value for money is excellent for this level of restaurant.",

                    IsViewFromItinerosPage = false,
                    IsEven = true,
                },
                new ReviewViewModel(ServiceProviderHelper.GetService<PlaceService>())
                {
                    ReviewId = "10",
                    ItinerosId = "7",
                    ItinerosFirstName = "Philippe",
                    ItinerosProfilPictureUrl = "https://static7.depositphotos.com/1066655/745/i/450/depositphotos_7453661-Elderly-black-man-smiling.jpg",
                    ItinerosCity = "Strasbourg",

                    PlaceId = "3",
                    PlaceName = "Le Meteor",
                    PlaceType = "Bar",
                    PlaceCity = "Strasbourg",
                    PlaceFirstPictureUrl = "https://lh3.googleusercontent.com/p/AF1QipNM1g9FFyGsRVj_Y-aZGby_Woz-xwVyQm00W4CL=s680-w680-h510",
                    LastModificationDate = DateTime.Now.AddDays(-32),
                    ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipPYGzZbLAjcKb6tLZAfmsEXg9Uty6rpyHMPkJv1=s680-w680-h510",
                    Message = "A wonderful evening with friends. A top-notch brasserie setting with impeccable service and extraordinary beer.",

                    IsViewFromItinerosPage = true,
                    IsEven = false
                },
                new ReviewViewModel(ServiceProviderHelper.GetService<PlaceService>())
                {
                    ReviewId = "5",
                    ItinerosId = "11",
                    ItinerosFirstName = "Matthieu",
                    ItinerosProfilPictureUrl = "https://images.unsplash.com/photo-1535713875002-d1d0cf377fde?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8bWFsZSUyMHByb2ZpbGV8ZW58MHx8MHx8fDA%3D",
                    ItinerosCity = "Pont-à-Mousson",

                    PlaceId = "2",
                    PlaceName = "Cimetière Sud",
                    PlaceType = "Cemetery",
                    PlaceCity = "Strasbourg",
                    PlaceFirstPictureUrl = "https://lh3.googleusercontent.com/p/AF1QipOJdBkYu5rOZ8zYI3IbB7hMYhfByJzv9XSmzdbk=s680-w680-h510",
                    LastModificationDate = DateTime.Now.AddDays(-375),
                    ImageUrl = null,
                    Message = "A beautiful place of contemplation, a magnificent arboretum that offers a wide variety of atmospheres. In the background, there are the steles for foreign soldiers.",

                    IsViewFromItinerosPage = false,
                    IsEven = true,
                },
                new ReviewViewModel(ServiceProviderHelper.GetService<PlaceService>())
                {
                    ReviewId = "2",
                    ItinerosId = "1",
                    ItinerosFirstName = "Jason",
                    ItinerosProfilPictureUrl = "https://cdn.sortiraparis.com/images/80/69688/1018558-jason-momoa-surprend-avec-une-choregraphie-flashdance-dans-une-pub-pour-le-super-bowl-2024.jpg",
                    ItinerosCity = "Hawaï",

                    PlaceId = "2",
                    PlaceName = "Le Grincheux",
                    PlaceType = "Bar",
                    PlaceCity = "Strasbourg",
                    PlaceFirstPictureUrl = "https://lh3.googleusercontent.com/gps-cs-s/AB5caB9pIzo6WMr9Wv8Hqq8AJdrCfQ1ruPC1vEg9nbwZcbKJPB8ab1lbWwgbtoyesJMLTtpjw9h9xsEmOvd2k2IywmB7AX5S0NAqXNF2J6nGYtBV4EPeCOf95vxZsP5Ah-MzkfUvlkct=s680-w680-h510",
                    LastModificationDate = DateTime.Now.AddDays(-390),
                    ImageUrl = null,
                    Message = "Incredible. Crazy. Over 400 spirits. Passionate servers who know how to guide you according to your tastes. A 60s-style French pub/bar atmosphere. Brilliant.",

                    IsViewFromItinerosPage = false,
                    IsEven = false,
                }
            };

            return reviewVMs;
        }

    }
}
