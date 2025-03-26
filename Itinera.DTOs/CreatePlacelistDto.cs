using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.DTOs
{
    public class CreatePlacelistDto
    {
        [Required]
        public string ItinerosId { get; set; } = string.Empty;
        [Required]
        [StringLength(40, ErrorMessage = "Name is limited to 40 characters")]
        public string Name { get; set; } = string.Empty;
        [StringLength(200, ErrorMessage = "Description is limited to 200 characters")]
        public string? Description { get; set; }
        [Required]
        public string Country { get; set; } = string.Empty;
        public string? Area { get; set; }
        public string? City { get; set; }
        public StreamContent? PlacelistImageFile { get; set; }
    }
}
