

namespace Itinera.DTOs
{
    public class ReviewDto
    {
        public string ReviewId { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public DateTime LastModificationDate { get; set; }

        public string ItinerosId { get; set; } = string.Empty;
        public string ItinerosFirstName { get; set; } = string.Empty;
        public string? ItinerosCity { get; set; }
        public string? ItinerosProfilPictureUrl { get; set; }
        public string PlaceId { get; set; } = string.Empty;
        public string PlaceName { get; set; } = string.Empty;
        public string PlaceType { get; set; } = string.Empty;
        public string PlaceCity { get; set; } = string.Empty;
        public string? PlaceFirstPictureUrl { get; set; }

    }
}
