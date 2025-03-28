

namespace Itinera.DTOs
{
    /// <summary>
    /// Represent the informations which will be displayed for the HomePage of the Itineros
    /// </summary>
    public class HomePageItinerosDto
    {
        public string ItinerosId { get; set; } = string.Empty;
        public string ItinerosName { get; set; } = string.Empty;
        public string? ItinerosProfilPictureUrl { get; set; }
        public IEnumerable<ReviewDto>? LastFollowedItinerosReviews { get; set; }
        public IEnumerable<PlaceHeaderDto>? PlacesNearItineros { get; set; }
    }
}
