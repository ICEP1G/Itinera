using Itinera.Client.Helpers;
using Itinera.Client.ViewModels.Components;
using Itinera.DTOs;
using Itinera.DTOs.Itineros;
using System.Collections.ObjectModel;

namespace Itinera.Client.Services
{
    public class FakeDataService
    {
        /// <summary>
        /// Constructor by default.
        /// </summary>
        public FakeDataService()
        {

        }


        #region Itineros Page
        public ItinerosDto GetItineros(string targetItinerosId, string currentItinerosId)
        {
            if (targetItinerosId == "1" && currentItinerosId == "1")
            {
                ItinerosDto itineros = new()
                {
                    ItinerosId = "1",
                    FirstName = "Meyling-Françoise",
                    Username = "Meyling1678",
                    Country = "France",
                    Area = "Bas-Rhin",
                    City = "Strasbourg",
                    Description = "Hi there! I'm Meyling-Françoise, 32 years old, and I live in the vibrant Krutenau neighborhood of Strasbourg. I'm a freelance graphic designer, which allows me to balance my love for design with my passion for culinary and cultural discoveries.",
                    ProfilPictureUrl = "https://as2.ftcdn.net/jpg/05/77/44/79/1000_F_577447922_ftBwSdFt6yfAKPCoWuOPOGmuaxoXlWky.jpg",
                    InscriptionDate = DateTime.Now.AddDays(-68),
                    RecommendationsCount = 127,
                    ReviewsCount = 23,
                    InstagramLink = "prideofgypsies",
                    IsFollowedByCurrentUser = false,
                    IsRecommandedByCurrentUser = false,
                    Placelists = this.GetPlacelistsHeaderByItinerosId(targetItinerosId).ToList(),
                    Reviews = this.GetReviewsByItinerosId(targetItinerosId).ToList()
                };
                return itineros;
            }
            if (targetItinerosId == "2" && currentItinerosId == "1")
            {
                ItinerosDto itineros = new()
                {
                    ItinerosId = "2",
                    FirstName = "Philippe",
                    Username = "PhilippeTheBest18",
                    Country = "France",
                    Area = "Meurthe-et-Moselle",
                    City = "Nancy",
                    Description = "Hi everyone, I'm a pretty down-to-earth person who loves to travel. My guilty pleasure? Food. :)",
                    ProfilPictureUrl = "https://static7.depositphotos.com/1066655/745/i/450/depositphotos_7453661-Elderly-black-man-smiling.jpg",
                    InscriptionDate = DateTime.Now.AddDays(-380),
                    RecommendationsCount = 30,
                    ReviewsCount = 5,
                    InstagramLink = "jimcarrey__",
                    IsFollowedByCurrentUser = false,
                    IsRecommandedByCurrentUser = false,
                    Placelists = this.GetPlacelistsHeaderByItinerosId(targetItinerosId).ToList(),
                    Reviews = this.GetReviewsByItinerosId(targetItinerosId).ToList()
                };
                return itineros;
            }

            return new ItinerosDto();
        }

        public IEnumerable<PlacelistHeaderDto> GetPlacelistsHeaderByItinerosId(string itinerosId)
        {
            List<PlacelistHeaderDto> placelistHeaders = new()
            {
                new PlacelistHeaderDto()
                {
                    ItinerosOwnerId = itinerosId,
                    PlacelistId = "1",
                    Name = "Ristoranti a Roma",
                    Description = "La mia lista dei migliori ristoranti che ho scoperto durante i miei soggiorni a Roma",
                    ImageUrl = "https://cdn.artphotolimited.com/images/57bc4cf405ac570df1c98c5f/300x300/rome-06.jpg",
                    PlacesPrimaryType = new HashSet<string>() { "Restaurant" },
                    RecommendationsCount = 87
                },
                new PlacelistHeaderDto()
                {
                    ItinerosOwnerId = itinerosId,
                    PlacelistId = "2",
                    Name = "Tokyo by daylight",
                    Description = "A bunch of places that you can only discover from 8AM to 7PM.",
                    ImageUrl = "https://citygame.com/wp-content/blogs.dir/1/files/sites/37/2023/02/City-Game-Tokyo-e1677225958158.jpg",
                    PlacesPrimaryType = new HashSet<string>() { "Restaurant", "Historic", "Library" },
                    RecommendationsCount = 103
                },
                new PlacelistHeaderDto()
                {
                    ItinerosOwnerId = itinerosId,
                    PlacelistId = "3",
                    Name = "Stay in Lapland",
                    Description = "Prepare your best stay in Lapland with this incredible placeslist",
                    ImageUrl = "https://www.destination-islande.com/uploads/sites/11/2018/06/bain-aurores-boreales-730x520.jpeg",
                    PlacesPrimaryType = new HashSet<string>() { "Restaurant", "Historic", "Park", "Camping", "Place" },
                    RecommendationsCount = 35
                },
                new PlacelistHeaderDto()
                {
                    ItinerosOwnerId = itinerosId,
                    PlacelistId = "5",
                    Name = "London 2025",
                    Description = "Places I want to visit next time I go to London.",
                    ImageUrl = "https://www.visitbritain.com/sites/cms/files/styles/page_header_ve_sm/public/lookatmedam/2283200f-48bc-4fb6-943a-dd17ee28d1cfl.jpg?h=d3c75ecd&itok=jRJj5uwX",
                    PlacesPrimaryType = new HashSet<string>() { "Restaurant", "Place", "Historic", "Park", "Camping", "Cemetery" },
                    RecommendationsCount = 17
                },
            };
            return placelistHeaders;
        }

        public IEnumerable<ReviewDto> GetReviewsByItinerosId(string itinerosId)
        {
            List<ReviewDto> reviews = new()
            {
                new ReviewDto()
                {
                    ReviewId = "1",
                    ItinerosId = itinerosId,
                    ItinerosFirstName = "Meyling-Françoise",
                    ItinerosProfilPictureUrl = "https://as2.ftcdn.net/jpg/05/77/44/79/1000_F_577447922_ftBwSdFt6yfAKPCoWuOPOGmuaxoXlWky.jpg",
                    ItinerosCity = "Strasbourg",

                    PlaceId = "5",
                    PlaceName = "Picobello",
                    PlaceType = "Restaurant",
                    PlaceCity = "Strasbourg",
                    PlaceFirstPictureUrl = "https://lh3.googleusercontent.com/p/AF1QipMpFRCh5R-A5Q3iJGQoe2lJAcvJ76W8mdjk0y8T=s680-w680-h510",
                    LastModificationDate = DateTime.Now.AddDays(-3),
                    ImageUrl = "https://lh3.googleusercontent.com/gps-cs-s/AB5caB8f5q_9hh2eEXiYBV1wOVeKLOPiysg_UNXXMX2tx-rVOGzP2G_H8rXmsihIHOqcSAs6BqFZuwBItoeVcOjbjNlV-2NoGliIN-rq_hrTWOVcPtdQwOXzza650jslWdIvvav179A=s680-w680-h510",
                    Message = "The place is very charming, the food is excellent, the quantities are ideal to be able to enjoy a dessert and the staff is warm, attentive and professional.",
                },
                new ReviewDto()
                {
                    ReviewId = "2",
                    ItinerosId = itinerosId,
                    ItinerosFirstName = "Meyling-Françoise",
                    ItinerosProfilPictureUrl = "https://as2.ftcdn.net/jpg/05/77/44/79/1000_F_577447922_ftBwSdFt6yfAKPCoWuOPOGmuaxoXlWky.jpg",
                    ItinerosCity = "Strasbourg",

                    PlaceId = "4",
                    PlaceName = "Alma",
                    PlaceType = "Restaurant",
                    PlaceCity = "Strasbourg",
                    PlaceFirstPictureUrl = "https://lh3.googleusercontent.com/p/AF1QipNLOFEP1Su3KNInzADW1GcwYBPMp9O58XdInLix=s680-w680-h510",
                    LastModificationDate = DateTime.Now.AddDays(-9),
                    ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipOWRfEhiuz8TLhPK-YIyvPdKcwew6pNt6Abx34k=s680-w680-h510",
                    Message = "How it is possible that I've never been to this restaurant! A gem of fusion cuisine, exquisite flavors, fresh and quality ingredients and all with a very attractive presentation of the dishes. In short, it's beautiful and very good, and what's more, the value for money is excellent for this level of restaurant.",
                },
                new ReviewDto()
                {
                    ReviewId = "7",
                    ItinerosId = itinerosId,
                    ItinerosFirstName = "Meyling-Françoise",
                    ItinerosProfilPictureUrl = "https://as2.ftcdn.net/jpg/05/77/44/79/1000_F_577447922_ftBwSdFt6yfAKPCoWuOPOGmuaxoXlWky.jpg",
                    ItinerosCity = "Strasbourg",

                    PlaceId = "3",
                    PlaceName = "Le Meteor",
                    PlaceType = "Bar",
                    PlaceCity = "Strasbourg",
                    PlaceFirstPictureUrl = "https://lh3.googleusercontent.com/p/AF1QipNM1g9FFyGsRVj_Y-aZGby_Woz-xwVyQm00W4CL=s680-w680-h510",
                    LastModificationDate = DateTime.Now.AddDays(-32),
                    ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipPYGzZbLAjcKb6tLZAfmsEXg9Uty6rpyHMPkJv1=s680-w680-h510",
                    Message = "A wonderful evening with friends. A top-notch brasserie setting with impeccable service and extraordinary beer.",
                },
                new ReviewDto()
                {
                    ReviewId = "15",
                    ItinerosId = itinerosId,
                    ItinerosFirstName = "Meyling-Françoise",
                    ItinerosProfilPictureUrl = "https://as2.ftcdn.net/jpg/05/77/44/79/1000_F_577447922_ftBwSdFt6yfAKPCoWuOPOGmuaxoXlWky.jpg",
                    ItinerosCity = "Strasbourg",

                    PlaceId = "2",
                    PlaceName = "Cimetière Sud",
                    PlaceType = "Cemetery",
                    PlaceCity = "Strasbourg",
                    PlaceFirstPictureUrl = "https://lh3.googleusercontent.com/p/AF1QipOJdBkYu5rOZ8zYI3IbB7hMYhfByJzv9XSmzdbk=s680-w680-h510",
                    LastModificationDate = DateTime.Now.AddDays(-375),
                    ImageUrl = null,
                    Message = "A beautiful place of contemplation, a magnificent arboretum that offers a wide variety of atmospheres. In the background, there are the steles for foreign soldiers.",
                },
                new ReviewDto()
                {
                    ReviewId = "30",
                    ItinerosId = itinerosId,
                    ItinerosFirstName = "Meyling-Françoise",
                    ItinerosProfilPictureUrl = "https://as2.ftcdn.net/jpg/05/77/44/79/1000_F_577447922_ftBwSdFt6yfAKPCoWuOPOGmuaxoXlWky.jpg",
                    ItinerosCity = "Strasbourg",

                    PlaceId = "1",
                    PlaceName = "Le Grincheux",
                    PlaceType = "Bar",
                    PlaceCity = "Strasbourg",
                    PlaceFirstPictureUrl = "https://lh3.googleusercontent.com/gps-cs-s/AB5caB9pIzo6WMr9Wv8Hqq8AJdrCfQ1ruPC1vEg9nbwZcbKJPB8ab1lbWwgbtoyesJMLTtpjw9h9xsEmOvd2k2IywmB7AX5S0NAqXNF2J6nGYtBV4EPeCOf95vxZsP5Ah-MzkfUvlkct=s680-w680-h510",
                    LastModificationDate = DateTime.Now.AddDays(-390),
                    ImageUrl = null,
                    Message = "Incredible. Crazy. Over 400 spirits. Passionate servers who know how to guide you according to your tastes. A 60s-style French pub/bar atmosphere. Brilliant.",
                }
            };
            return reviews;
        }
        #endregion

        #region Placelists Page
        public PlacelistsPageDto GetPlacelistsByItinerosId(string itinerosId, bool includedfollowed = false)
        {
            PlacelistsPageDto placelistsPage = new();
            placelistsPage.OwnedPlacelists = new()
            {
                new PlacelistHeaderDto()
                {
                    ItinerosOwnerId = itinerosId,
                    PlacelistId = "1",
                    Name = "Strasbourg mon amour",
                    Description = "Placelist from my journey in Alsace in august 2024.",
                    ImageUrl = "https://www.visitfrenchwine.com/sites/default/files/niedermorschwihr-photo-zvardon-conseil-vins-alsace.jpg",
                    PlacesPrimaryType = new HashSet<string>() { "Restaurant", "Historic", "Park" },
                    RecommendationsCount = 103
                },
                new PlacelistHeaderDto()
                {
                    ItinerosOwnerId = itinerosId,
                    PlacelistId = "2",
                    Name = "London 2025",
                    Description = "Places I want to visit next time I go to London.",
                    ImageUrl = "https://www.visitbritain.com/sites/cms/files/styles/page_header_ve_sm/public/lookatmedam/2283200f-48bc-4fb6-943a-dd17ee28d1cfl.jpg?h=d3c75ecd&itok=jRJj5uwX",
                    PlacesPrimaryType = new HashSet<string>() { "Restaurant", "Place", "Historic", "Park", "Camping", "Cemetery" },
                    RecommendationsCount = 5
                }
            };

            if (includedfollowed)
            {
                placelistsPage.FollowedPlacelists = new()
                {
                    new PlacelistHeaderDto()
                    {
                        ItinerosOwnerId = "2",
                        PlacelistId = "3",
                        Name = "Ristoranti a Roma",
                        Description = "La mia lista dei migliori ristoranti che ho scoperto durante i miei soggiorni a Roma",
                        ImageUrl = "https://cdn.artphotolimited.com/images/57bc4cf405ac570df1c98c5f/300x300/rome-06.jpg",
                        PlacesPrimaryType = new HashSet<string>() { "Restaurant" },
                        RecommendationsCount = 87
                    },
                    new PlacelistHeaderDto()
                    {
                        ItinerosOwnerId = "2",
                        PlacelistId = "4",
                        Name = "Tokyo by daylight",
                        Description = "A bunch of places that you can only discover from 8AM to 7PM.",
                        ImageUrl = "https://citygame.com/wp-content/blogs.dir/1/files/sites/37/2023/02/City-Game-Tokyo-e1677225958158.jpg",
                        PlacesPrimaryType = new HashSet<string>() { "Restaurant", "Historic", "Library" },
                        RecommendationsCount = 18
                    },
                    new PlacelistHeaderDto()
                    {
                        ItinerosOwnerId = "3",
                        PlacelistId = "5",
                        Name = "Best movie theater from Paris",
                        Description = "All movie theater that I love from Paris",
                        ImageUrl = "https://www.urbansider.com/wp-content/uploads/Categories/Entertainment/Grande_Salle-e1621112670580.jpg",
                        PlacesPrimaryType = new HashSet<string>() { "Movie" },
                        RecommendationsCount = 233
                    }
                };
            }

            return placelistsPage;
        }
        #endregion

        #region PlacelistDetail Page

        public PlacelistContentDto GetPlacelistById(string placelistId)
        {
            if (placelistId == "1")
            {
                PlacelistContentDto placelist = new()
                {
                    PlacelistId = placelistId,
                    Name = "Strasbourg mon amour",
                    Description = "Placelist from my journey in Alsace in august 2024.",
                    ImageUrl = "https://www.visitfrenchwine.com/sites/default/files/niedermorschwihr-photo-zvardon-conseil-vins-alsace.jpg",
                    RecommendationsCount = 103,
                    IsFollowedByCurrentUser = false,
                    IsRecommandedByCurrentUser = false,
                    ItinerosOwnerId = "1",
                    ItinerosOwnerUsername = "Meyling1678",
                    ItinerosOwnerPictureUrl = "https://as2.ftcdn.net/jpg/05/77/44/79/1000_F_577447922_ftBwSdFt6yfAKPCoWuOPOGmuaxoXlWky.jpg",
                    PlaceHeaders = this.GetPlaceHeaders().ToList()
                };
                return placelist;
            }
            else if (placelistId == "4")
            {
                PlacelistContentDto placelist = new()
                {
                    PlacelistId = placelistId,
                    Name = "Tokyo by daylight",
                    Description = "A bunch of places that you can only discover from 8AM to 7PM.",
                    ImageUrl = "https://citygame.com/wp-content/blogs.dir/1/files/sites/37/2023/02/City-Game-Tokyo-e1677225958158.jpg",
                    RecommendationsCount = 18,
                    IsFollowedByCurrentUser = true,
                    IsRecommandedByCurrentUser = false,
                    ItinerosOwnerId = "2",
                    ItinerosOwnerUsername = "PhilippeTheBest18",
                    ItinerosOwnerPictureUrl = "https://static7.depositphotos.com/1066655/745/i/450/depositphotos_7453661-Elderly-black-man-smiling.jpg",
                    PlaceHeaders = this.GetPlaceHeaders().ToList()
                };

                return placelist;
            }

            return null;
        }

        public IEnumerable<PlaceHeaderDto> GetPlaceHeaders()
        {
            List<PlaceHeaderDto> placeHeaders = new()
            {
                new PlaceHeaderDto()
                {
                    PlaceId = "1",
                    Name = "Picobello",
                    Address = "21 Rue des Frères, 67000 Strasbourg",
                    PlacePrimaryType = "Restaurant",
                    TodaySchedules = "12:00 – 15:00, 19:00 – 22:00",
                    PlacePrimaryImageUrl = "https://lh3.googleusercontent.com/p/AF1QipMpFRCh5R-A5Q3iJGQoe2lJAcvJ76W8mdjk0y8T=s680-w680-h510"
                },
                new PlaceHeaderDto()
                {
                    PlaceId = "2",
                    Name = "Mama Bubbele",
                    Address = "2 Quai des Bateliers, 67000 Strasbourg",
                    PlacePrimaryType = "Restaurant",
                    TodaySchedules = "12:00 – 15:00, 18:00 – 23:30",
                    PlacePrimaryImageUrl = "https://lh3.googleusercontent.com/p/AF1QipNUkyYVJBXN_L8cxo3I43swFbs2lJSz3nVy7w-v=s680-w680-h510-rw"
                },
                new PlaceHeaderDto()
                {
                    PlaceId = "3",
                    Name = "Umaï Ramen",
                    Address = "5 Rue des Orphelins, 67000 Strasbourg",
                    PlacePrimaryType = "Place",
                    TodaySchedules = "12:00 – 14:00, 19:00 – 21:00",
                    PlacePrimaryImageUrl = "https://lh3.googleusercontent.com/p/AF1QipOri94Z3zC8Zhc3hacQ7FV7JUIZcLhf9VnroITG=s680-w680-h510"
                },
            };

            return placeHeaders;
        }

        #endregion

        #region Place Page
        public PlaceContentDto GetPlaceById(string placeId, string currentItinerosId)
        {
            if (placeId == "1")
            {
                PlaceContentDto place = new()
                {
                    PlaceId = placeId,
                    Name = "Picobello",
                    Address = "21 Rue des Frères, 67000 Strasbourg",
                    Description = "Restaurant italien branché avec pop art coloré et terrasse côté trottoir proposant pâtes, risotto et plats de viande.",
                    PlacePrimaryType = "Restaurant",
                    ImageUrls = new List<string>()
                    {
                        "https://lh3.googleusercontent.com/p/AF1QipMpFRCh5R-A5Q3iJGQoe2lJAcvJ76W8mdjk0y8T=s680-w680-h510-rw",
                        "https://lh3.googleusercontent.com/p/AF1QipMk1cmbkmNyGHA2BjfPxsK6aYBTpU1HhGkXzK9V=s680-w680-h510-rw",
                        "https://lh3.googleusercontent.com/gps-cs-s/AB5caB-uhRRDbMginVRHqRp3-tRzUlQTXSioxRUA8VayCGnQEaE_qJ-shnHskSIxl_psNpJpAE5iocR7EZvDOtOJ4D7jN7yM3gf6atXAahRdY8SpsGMbNW_mXpIP-dabfYyIGHdVPem6=s680-w680-h510-rw",
                        "https://lh3.googleusercontent.com/gps-cs-s/AB5caB-TNytXZiTXdhUug5KOWZAq5nUNcNXRje2etH8YkByezC49SXg-kFGPnXrg9NqOmNJiyjSPnHx-TSp3trSwdKun5vNGuu_durftYT4ESnkVKxGYp49Qys7Ezy1vu0b936OWc3RnDA=s680-w680-h510-rw",
                        "https://lh3.googleusercontent.com/gps-cs-s/AB5caB_TIxQOHgMz7-xapqJmPHbbtO_DsDM4VU2O46eO9l65cp6BFS1sPa1gJH4SyZUbT0r9con6PWnkSoz3xL8obwGm3DBiXJgJQOwFuKpv41oJCGZWfq6YF_7r3ef6tyNQb9r0VKI5IA=s680-w680-h510-rw"
                    },
                    WebSiteUrl = "https://www.restaurant-lepicobello.com/",
                    PhoneNumber = "03 88 35 47 25",
                    WeekDaySchedules = new Dictionary<string, string>()
                    {
                        { "Monday", "Closed" },
                        { "Tuesday", "12:00 – 14:30, 19:00 – 22:00" },
                        { "Wednesday", "12:00 – 14:30, 19:00 – 22:00" },
                        { "Thursday", "12:00 – 14:30, 19:00 – 22:00" },
                        { "Friday", "12:00 – 14:30, 19:00 – 22:00" },
                        { "Saturday", "12:00 – 14:30, 19:00 – 22:00" },
                        { "Sunday", "Closed" },
                    },
                    PaymentOptions = new List<string>() { "Pluxee", "Ticket Restaurant", "Bimpli", "Chèque Déjeuner" },
                    StartPrice = "20",
                    EndPrice = "30",
                    RecommendationsCount = 103,
                    IsRecommandedByCurrentUser = false,
                    IsReviewedByCurrentUser = false,
                    ReviewsCount = 4,
                    Reviews = this.GetReviewsByPlaceId(placeId).ToList()
                };
                return place;
            }
            else if (placeId == "2")
            {
                PlaceContentDto place = new()
                {
                    PlaceId = placeId,
                    Name = "Mama Bubbele",
                    Address = "2 Quai des Bateliers, 67000 Strasbourg",
                    Description = "Restaurant à l'ambiance détendue proposant 15 types de tartes flambées, salées ou sucrées.",
                    PlacePrimaryType = "Restaurant",
                    ImageUrls = new List<string>()
                    {
                        "https://lh3.googleusercontent.com/p/AF1QipNUkyYVJBXN_L8cxo3I43swFbs2lJSz3nVy7w-v=s680-w680-h510-rw",
                        "https://lh3.googleusercontent.com/p/AF1QipPK6cT0jkIWx-Aqj3SWwrr7P498BtIwYpvQimR-=s680-w680-h510-rw",
                        "https://lh3.googleusercontent.com/p/AF1QipPQcjTgvGx1cTrsqGF0thRCgulSwQY56jscOVey=s680-w680-h510-rw",
                        "https://lh3.googleusercontent.com/p/AF1QipNXpmnarppgDoCcdmH0SsKB67ddOY9CEgOER8Qs=s680-w680-h510-rw",
                    },
                    WebSiteUrl = "https://www.mama-bubbele.fr/",
                    PhoneNumber = "03 90 23 83 35",
                    WeekDaySchedules = new Dictionary<string, string>()
                    {
                        { "Monday", "12:00 – 14:30, 18:00 – 23:00" },
                        { "Tuesday", "12:00 – 14:30, 18:00 – 23:00" },
                        { "Wednesday", "12:00 – 14:30, 18:00 – 23:00" },
                        { "Thursday", "12:00 – 14:30, 18:00 – 23:00" },
                        { "Friday", "12:00 – 23:30" },
                        { "Saturday", "12:00 – 23:30" },
                        { "Sunday", "12:00 – 23:30" },
                    },
                    PaymentOptions = new List<string>() { "Pluxee" },
                    StartPrice = "20",
                    EndPrice = "30",
                    RecommendationsCount = 45,
                    IsRecommandedByCurrentUser = true,
                    IsReviewedByCurrentUser = true,
                    ReviewsCount = 2,
                    Reviews = this.GetReviewsByPlaceId(placeId).ToList()
                };
                return place;
            }

            return null;
        }

        public IEnumerable<ReviewDto> GetReviewsByPlaceId(string placeId)
        {
            if (placeId == "1")
            {
                List<ReviewDto> reviews = new()
                {
                    new ReviewDto()
                    {
                        ReviewId = "1",
                        ItinerosId = "2",
                        ItinerosFirstName = "Barbara",
                        ItinerosProfilPictureUrl = "https://media.irishpost.co.uk/uploads/2017/05/Redhead_8.jpg",
                        ItinerosCity = "Nancy",

                        PlaceId = placeId,
                        PlaceName = "Picobello",
                        PlaceType = "Restaurant",
                        PlaceCity = "Strasbourg",
                        PlaceFirstPictureUrl = "https://lh3.googleusercontent.com/p/AF1QipMpFRCh5R-A5Q3iJGQoe2lJAcvJ76W8mdjk0y8T=s680-w680-h510",
                        LastModificationDate = DateTime.Now.AddDays(-3),
                        ImageUrl = "https://lh3.googleusercontent.com/gps-cs-s/AB5caB8f5q_9hh2eEXiYBV1wOVeKLOPiysg_UNXXMX2tx-rVOGzP2G_H8rXmsihIHOqcSAs6BqFZuwBItoeVcOjbjNlV-2NoGliIN-rq_hrTWOVcPtdQwOXzza650jslWdIvvav179A=s680-w680-h510",
                        Message = "The service was impeccable and the dishes were carefully presented, generous without being overly filling. We were seated in the small room at the back of the restaurant.",
                    },
                    new ReviewDto()
                    {
                        ReviewId = "2",
                        ItinerosId = "3",
                        ItinerosFirstName = "Philippe",
                        ItinerosProfilPictureUrl = "https://static7.depositphotos.com/1066655/745/i/450/depositphotos_7453661-Elderly-black-man-smiling.jpg",
                        ItinerosCity = "Strasbourg",

                        PlaceId = placeId,
                        PlaceName = "Picobello",
                        PlaceType = "Restaurant",
                        PlaceCity = "Strasbourg",
                        PlaceFirstPictureUrl = "https://lh3.googleusercontent.com/p/AF1QipMpFRCh5R-A5Q3iJGQoe2lJAcvJ76W8mdjk0y8T=s680-w680-h510",
                        LastModificationDate = DateTime.Now.AddDays(-9),
                        ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipOWRfEhiuz8TLhPK-YIyvPdKcwew6pNt6Abx34k=s680-w680-h510",
                        Message = "We arrived, our drinks were served very quickly and then the food. Of course it was pleasant and good! I recommend",
                    },
                    new ReviewDto()
                    {
                        ReviewId = "7",
                        ItinerosId = "4",
                        ItinerosFirstName = "Matthieu",
                        ItinerosProfilPictureUrl = "https://images.unsplash.com/photo-1535713875002-d1d0cf377fde?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8bWFsZSUyMHByb2ZpbGV8ZW58MHx8MHx8fDA%3D",
                        ItinerosCity = "Pont-à-Mousson",

                        PlaceId = placeId,
                        PlaceName = "Picobello",
                        PlaceType = "Restaurant",
                        PlaceCity = "Strasbourg",
                        PlaceFirstPictureUrl = "https://lh3.googleusercontent.com/p/AF1QipMpFRCh5R-A5Q3iJGQoe2lJAcvJ76W8mdjk0y8T=s680-w680-h510",
                        LastModificationDate = DateTime.Now.AddDays(-32),
                        ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipPYGzZbLAjcKb6tLZAfmsEXg9Uty6rpyHMPkJv1=s680-w680-h510",
                        Message = "Italian restaurant on Rue des Frères. It's not very big, and there's a tiny terrace in front of the restaurant. It's best to make a reservation. Warm welcome. The menu consists mainly of pasta, risottos, salads, and meat dishes; no pizzas. The prices are reasonable.",
                    },
                    new ReviewDto()
                    {
                        ReviewId = "15",
                        ItinerosId = "5",
                        ItinerosFirstName = "Jason",
                        ItinerosProfilPictureUrl = "https://cdn.sortiraparis.com/images/80/69688/1018558-jason-momoa-surprend-avec-une-choregraphie-flashdance-dans-une-pub-pour-le-super-bowl-2024.jpg",
                        ItinerosCity = "Hawaï",

                        PlaceId = placeId,
                        PlaceName = "Picobello",
                        PlaceType = "Restaurant",
                        PlaceCity = "Strasbourg",
                        PlaceFirstPictureUrl = "https://lh3.googleusercontent.com/p/AF1QipMpFRCh5R-A5Q3iJGQoe2lJAcvJ76W8mdjk0y8T=s680-w680-h510",
                        LastModificationDate = DateTime.Now.AddDays(-375),
                        ImageUrl = null,
                        Message = "Une perle rare au Picobello !\r\nUn service irréprochable, une élégance naturelle, un sourire qui illumine la salle : la serveuse blonde (bulgare) du Picobello est tout simplement parfaite à tous les niveaux. ",
                    }
                };
                return reviews;
            }
            else if (placeId == "2")
            {
                List<ReviewDto> reviews = new()
                {
                    new ReviewDto()
                    {
                        ReviewId = "10",
                        ItinerosId = "1",
                        ItinerosFirstName = "Meyling-Françoise",
                        ItinerosProfilPictureUrl = "https://as2.ftcdn.net/jpg/05/77/44/79/1000_F_577447922_ftBwSdFt6yfAKPCoWuOPOGmuaxoXlWky.jpg",
                        ItinerosCity = "Strasbourg",

                        PlaceId = placeId,
                        PlaceName = "Mama Bubbele",
                        PlaceType = "Restaurant",
                        PlaceCity = "Strasbourg",
                        PlaceFirstPictureUrl = "https://lh3.googleusercontent.com/p/AF1QipNUkyYVJBXN_L8cxo3I43swFbs2lJSz3nVy7w-v=s680-w680-h510-rw",
                        LastModificationDate = DateTime.Now,
                        ImageUrl = "https://lh3.googleusercontent.com/gps-cs-s/AB5caB-8irn-c0IDDhydO5YRVOjGqFkcchSJhXDy6tKPGvpao4f5snWz5jVPOIQzoi69-P50pgu1VnmiMHIHkP5c3Bo-jz2rE_aSi2nvGoCwdEuotwPqMoAHSW2e_IYkSTsZh7UViuFu=s680-w680-h510-rw",
                        Message = "An excellent Strasbourg address.\r\nWe appreciated the warm welcome, the speed of the service, and the excellent quality of the products, including the three tartes flambées of the moment and the one with dried beef/Comté cheese.",
                    },
                    new ReviewDto()
                    {
                        ReviewId = "11",
                        ItinerosId = "2",
                        ItinerosFirstName = "Philippe",
                        ItinerosProfilPictureUrl = "https://static7.depositphotos.com/1066655/745/i/450/depositphotos_7453661-Elderly-black-man-smiling.jpg",
                        ItinerosCity = "Strasbourg",

                        PlaceId = placeId,
                        PlaceName = "Mama Bubbele",
                        PlaceType = "Restaurant",
                        PlaceCity = "Strasbourg",
                        PlaceFirstPictureUrl = "https://lh3.googleusercontent.com/p/AF1QipNUkyYVJBXN_L8cxo3I43swFbs2lJSz3nVy7w-v=s680-w680-h510-rw",
                        LastModificationDate = DateTime.Now.AddDays(-9),
                        ImageUrl = "https://lh3.googleusercontent.com/p/AF1QipNRQ-EFNSnhUIt0NoaTrMvuXbRDfrv231X3O2oZ=s680-w680-h510-rw",
                        Message = "There were 3 of us on Sunday evening, we were seated upstairs. The first tart took a while to arrive, we wanted to try the truffled ham one, and we were quite disappointed, the truffle flavor is not very pronounced and the cream is not very generous.",
                    }
                };
                return reviews;
            }

            return new List<ReviewDto>();
        }
        #endregion








        // Old -> component test
        public PlacelistHeaderViewModel GetPlacelistViewModel()
        {
            PlacelistHeaderViewModel placeListVm = new(ServiceProviderHelper.GetService<IPlaceService>())
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
                new PlacelistHeaderViewModel(ServiceProviderHelper.GetService<IPlaceService>())
                {
                    Id = "1",
                    Name = "Strasbourg mon amour",
                    Description = "Placelist from my journey in Alsace in august 2024.",
                    ImageUrl = "https://www.visitfrenchwine.com/sites/default/files/niedermorschwihr-photo-zvardon-conseil-vins-alsace.jpg",
                    PlacesPrimaryTypes = new HashSet<string>() { "Restaurant", "Museum", "Historic" },
                    RecommendationCount = 123
                },
                new PlacelistHeaderViewModel(ServiceProviderHelper.GetService<IPlaceService>())
                {
                    Id = "3",
                    Name = "London 2025",
                    Description = "Places I want to visit next time I go to London.",
                    ImageUrl = "https://www.visitbritain.com/sites/cms/files/styles/page_header_ve_sm/public/lookatmedam/2283200f-48bc-4fb6-943a-dd17ee28d1cfl.jpg?h=d3c75ecd&itok=jRJj5uwX",
                    PlacesPrimaryTypes = new HashSet<string>() { "Restaurant", "Place", "Historic", "Park", "Camping", "Cemetery" },
                    RecommendationCount = 53
                },
            };

            return placelistHeaderVMs;
        }

        public List<PlaceHeaderViewModel> GetPlaceHeaderViewModelCollection()
        {
            List<PlaceHeaderViewModel> placeHeaderVMs = new()
            {
                new PlaceHeaderViewModel(ServiceProviderHelper.GetService<IPlaceService>())
                {
                    Id = "18",
                    Name = "Picobello",
                    Address = "21 Rue des Frères, 67000 Strasbourg",
                    PrimaryType = "Restaurant",
                    TodaySchedules = "12:00 – 15:00, 19:00 – 22:00",
                    PrimaryImageUrl = "https://lh3.googleusercontent.com/p/AF1QipMpFRCh5R-A5Q3iJGQoe2lJAcvJ76W8mdjk0y8T=s680-w680-h510"
                },
                new PlaceHeaderViewModel(ServiceProviderHelper.GetService<IPlaceService>())
                {
                    Id = "19",
                    Name = "Mama Bubbele",
                    Address = "2 Quai des Bateliers, 67000 Strasbourg",
                    PrimaryType = "Restaurant",
                    TodaySchedules = "12:00 – 15:00, 18:00 – 23:30",
                    PrimaryImageUrl = "https://lh3.googleusercontent.com/p/AF1QipNUkyYVJBXN_L8cxo3I43swFbs2lJSz3nVy7w-v=s680-w680-h510-rw"
                },
                new PlaceHeaderViewModel(ServiceProviderHelper.GetService<IPlaceService>())
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
            ReviewViewModel reviewVm = new(ServiceProviderHelper.GetService<IPlaceService>())
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
                new ReviewViewModel(ServiceProviderHelper.GetService<IPlaceService>())
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

                    IsViewedFromItinerosPage = false,
                    IsViewedFromPlacePage = false,
                    IsEven = false
                },
                new ReviewViewModel(ServiceProviderHelper.GetService<IPlaceService>())
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

                    IsViewedFromItinerosPage = false,
                    IsViewedFromPlacePage = false,
                    IsEven = true,
                },
                new ReviewViewModel(ServiceProviderHelper.GetService<IPlaceService>())
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

                    IsViewedFromItinerosPage = false,
                    IsViewedFromPlacePage = true,

                    IsEven = false
                },
                new ReviewViewModel(ServiceProviderHelper.GetService<IPlaceService>())
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

                    IsViewedFromItinerosPage = false,
                    IsViewedFromPlacePage = false,
                    IsEven = true,
                },
                new ReviewViewModel(ServiceProviderHelper.GetService<IPlaceService>())
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

                    IsViewedFromItinerosPage = true,
                    IsViewedFromPlacePage = false,
                    IsEven = false,
                }
            };

            return reviewVMs;
        }

    }
}
