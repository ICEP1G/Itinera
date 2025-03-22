using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.DTOs
{
    public class PlaceDto
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string PlacePrimaryType { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? InternationalPhoneNumber { get; set; }
        public string? WebSiteUrl { get; set; }
        public IEnumerable<string>? PictureUrls { get; set; }

        public string Country { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public FrozenDictionary<string, string>? WeekDaySchedules { get; set; }
        public IEnumerable<string>? PaymentOptions { get; set; }
        public string? StartPrice { get; set; }
        public string? EndPrice { get; set; }

        public bool IsRecommandedByCurrentUser { get; set; }
        public bool IsReviewedByCurrentUser { get; set; }
        public int ReviewsCount { get; set; }

        List<ReviewDto>? Reviews { get; set; }
        ReviewDto? CurrentUserReview { get; set; }
    }
}
