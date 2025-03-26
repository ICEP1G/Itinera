using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.DTOs.AccountDtos
{
    public class LoginItinerosAccountDto
    {
        [Required]
        public string Login { get; set; } = string.Empty; // Can be Email or Phone number
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
