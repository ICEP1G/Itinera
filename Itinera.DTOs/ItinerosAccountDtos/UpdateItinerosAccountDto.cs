using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.DTOs.AccountDtos
{
    /// <summary>
    /// Will only update the informations from the ItinerosAccount (not the Itineros itself)
    /// </summary>
    public class UpdateItinerosAccountDto
    {
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string EmailAddress { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, ErrorMessage = "To small or to large", MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;
    }
}
