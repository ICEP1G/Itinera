using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.DTOs.AccountDtos
{
    public class UpdateItinerosAccountDto
    {
        [Required(ErrorMessage = "Login is required")]
        [StringLength(15, ErrorMessage = "To small or to large", MinimumLength = 3)]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "First name is required")]
        [StringLength(20, ErrorMessage = "To small or to large", MinimumLength = 6)]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string EmailAddress { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, ErrorMessage = "To small or to large", MinimumLength = 6)]
        public IEnumerable<string>? SpokenLanguages { get; set; }
        public string Password { get; set; } = string.Empty;
        public StreamContent? UserImageFile { get; set; }
    }
}
