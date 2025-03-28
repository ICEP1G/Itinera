using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.DTOs.Itineros
{
    /// <summary>
    /// Use to update the informations about the Itineros which is currently using the application
    /// </summary>
    public class UpdateItinerosOwnProfilDto
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(15, ErrorMessage = "To small or to large", MinimumLength = 3)]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "First name is required")]
        [StringLength(20, ErrorMessage = "To small or to large", MinimumLength = 6)]
        public string FirstName { get; set; } = string.Empty;
        public IEnumerable<string>? SpokenLanguages { get; set; }
        public string? Description { get; set; }
        public string? InstagramUrl { get; set; }
        public string Country { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public StreamContent? ItinerosImageFile { get; set; }
    }
}
