using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.DTOs.AccountDtos
{
    public class ItinerosAccountProfilDto
    {
        public int CurrentItinerosId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public IEnumerable<string>? SpokenLanguages { get; set; }
        public string City { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public StreamContent? ItinerosImageFile { get; set; }
    }
}
