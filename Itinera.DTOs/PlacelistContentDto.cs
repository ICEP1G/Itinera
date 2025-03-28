using System.ComponentModel.DataAnnotations;


namespace Itinera.DTOs
{
    /// <summary>
    /// Display the detail about a Placelist and the basics informations about the Places contained inside it
    /// </summary>
    public class PlacelistContentDto
    {
        [Required]
        public string PlacelistId { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        [Required]
        public string ItinerosOwnerId { get; set; } = string.Empty;
        [Required]
        public string ItinerosOwnerUsername { get; set; } = string.Empty;
        public string? ItinerosOwnerPictureUrl { get; set; }

        [Required]
        public int RecommendationsCount { get; set; }
        [Required]
        public bool IsRecommandedByCurrentUser { get; set; }
        [Required]
        public bool IsFollowedByCurrentUser { get; set; }

        public List<PlaceHeaderDto>? PlaceHeaders { get; set; } = new();
    }
}
