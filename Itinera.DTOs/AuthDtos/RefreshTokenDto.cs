using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.DTOs.AuthDtos
{
    /// <summary>
    /// Used when the AccessToken is expired in order to get a new AccessToken and a new RefreshToken 
    /// </summary>
    class RefreshTokenDto
    {
        [Required]
        public string RefreshToken { get; set; } = string.Empty;
    }
}
