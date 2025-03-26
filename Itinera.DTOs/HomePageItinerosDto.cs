using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.DTOs
{
    public class HomePageItinerosDto
    {
        public string ItinerosId { get; set; } = string.Empty;
        public string ItinerosName { get; set; } = string.Empty;
        public string? ItinerosProfilPictureUrl { get; set; }
        public IEnumerable<ReviewDto>? LastFollowedItinerosReviews { get; set; }
        public IEnumerable<PlaceHeaderDto>? PlacesNearItineros { get; set; }
    }
}
