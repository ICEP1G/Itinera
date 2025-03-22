using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.DTOs
{
    public class PlacelistDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Country { get; set; } = string.Empty;
        public string? Area { get; set; }
        public string? City { get; set; }
        public string? PictureUrl { get; set; }

        public string OwnerPseudo { get; set; } = string.Empty;
        public string? OwnerPictureUrl { get; set; }
        HashSet<string>? PlacesPrimaryType { get; set; }
        public int RecommendationsCount { get; set; }
        public bool IsRecommandedByCurrentUser { get; set; }
        public bool IsFollowedByCurrentUser { get; set; }

        public List<PlaceDto>? Places { get; set; }
    }
}
