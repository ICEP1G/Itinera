using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.DTOs
{
    /// <summary>
    /// Display only the basics information about a Placelist. Will be mostly used in a List<PlacelistHeaderDto>
    /// </summary>
    public class PlacelistHeaderDto
    {
        [Required]
        public string PlacelistId { get; set; } = string.Empty;
        [Required]
        public string ItinerosOwnerId { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public HashSet<string>? PlacesPrimaryType { get; set; } = new(); // Use to get the place types without doublon
        [Required]
        public int RecommendationsCount { get; set; }
        [Required]
        public bool IsFollowedByCurrentUser { get; set; }
    }
}
