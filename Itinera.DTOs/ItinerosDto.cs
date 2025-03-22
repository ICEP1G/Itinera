using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.DTOs
{
    public class ItinerosDto
    {
        public string Pseudo { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ProfilPictureUrl { get; set; }
        public string? InstagramLink { get; set; }
        public DateTime InscriptionDate { get; set; }
        public bool IsRecommandedByCurrentUser { get; set; }
        public bool IsFollowedByCurrentUser { get; set; }
        public int RecommendationsCount { get; set; }
        public int ReviewsCount { get; set; }

        List<PlacelistDto> Placelists = new();
        List<ReviewDto> Reviews = new();
    }
}
