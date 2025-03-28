

namespace Itinera.DTOs
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public DateTime LastModificationDate { get; set; }

        public int ItinerosId { get; set; }
        public string ItinerosUsername { get; set; } = string.Empty;
        public string? ItinerosProfilPictureUrl { get; set; }
        public string PlaceName { get; set; } = string.Empty;
        public string PlaceType { get; set; } = string.Empty;
        public string PlaceCity { get; set; } = string.Empty;
        public string? PlaceFirstPictureUrl { get; set; }

    }
}
