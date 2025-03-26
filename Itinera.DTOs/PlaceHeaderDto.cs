using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.DTOs
{
    /// <summary>
    /// Display only the basics information about a Place. Will be mostly used in a List<PlaceHeaderDto>
    /// </summary>
    public class PlaceHeaderDto
    {
        [Required]
        public string PlaceId { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public string PlacePrimaryType { get; set; } = string.Empty;
        [Required]
        public string PlacePrimaryImageUrl { get; set; } = string.Empty;
        [Required]
        public string? TodaySchedules { get; set; }
    }
}
