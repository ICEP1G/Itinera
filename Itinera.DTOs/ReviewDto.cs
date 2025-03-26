using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.DTOs
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        public string ReviewDescription { get; set; } = string.Empty;
        public string? ReviewImageUrl { get; set; }
        public DateTime ReviewModificationDate { get; set; }
        public DateTime ReviewCreationDate { get; set; }

        public int ItinerosId { get; set; }
        public string ItinerosUsername { get; set; } = string.Empty;
        public string PlaceName { get; set; } = string.Empty;
        public string PlaceType { get; set; } = string.Empty;
        public string PlaceCity { get; set; } = string.Empty;
        public string? PlaceFirstPictureUrl { get; set; }

    }
}
