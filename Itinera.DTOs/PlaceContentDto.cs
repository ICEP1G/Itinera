using System.Collections.Frozen;
using System.ComponentModel.DataAnnotations;


namespace Itinera.DTOs
{
    /// <summary>
    /// Display the detail about a Place and all it's Reviews
    /// </summary>
    public class PlaceContentDto
    {
        [Required]
        public string PlaceId { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required]
        public string PlacePrimaryType { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? InternationalPhoneNumber { get; set; }
        public string? WebSiteUrl { get; set; }
        public IEnumerable<string>? ImageUrls { get; set; }
        public FrozenDictionary<string, string>? WeekDaySchedules { get; set; } // Key: Weekday - Value: Schedules
        public IEnumerable<string>? PaymentOptions { get; set; }
        public string? StartPrice { get; set; }
        public string? EndPrice { get; set; }

        [Required]
        public bool IsRecommandedByCurrentUser { get; set; }
        [Required]
        public bool IsReviewedByCurrentUser { get; set; }
        [Required]
        public int RecommendationsCount { get; set; }

        public List<ReviewDto>? Reviews { get; set; }
    }
}
