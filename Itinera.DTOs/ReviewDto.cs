using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.DTOs
{
    public class ReviewDto
    {
        public string ReviewDescription { get; set; } = string.Empty;
        public string? ReviewPictureUrl { get; set; }
        public DateTime ReviewModificationDate { get; set; }
        public DateTime ReviewCreationDate { get; set; }

        public string ItinerosName { get; set; } = string.Empty;
        public string PlaceName { get; set; } = string.Empty;
        public string PlaceType { get; set; } = string.Empty;
        public string PlaceCity { get; set; } = string.Empty;
        public string? PlaceFirstPictureUrl { get; set; }

    }
}
