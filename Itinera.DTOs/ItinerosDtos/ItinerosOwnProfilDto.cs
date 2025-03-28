using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.DTOs.Itineros
{
    /// <summary>
    /// Use to get the informations about the Itineros which is currently using the application
    /// </summary>
    public class ItinerosOwnProfilDto
    {
        public int ItinerosId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public StreamContent? ItinerosImageFile { get; set; }
        public IEnumerable<string>? SpokenLanguages { get; set; }
        public string City { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int ItinerosFollowersCount { get; set; }
        public int ItinerosFollowingCount { get; set; }
        public DateTime ItinerosCreationDate { get; set; }
    }
}
