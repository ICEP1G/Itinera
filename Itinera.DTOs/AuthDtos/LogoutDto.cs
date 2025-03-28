using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.DTOs.AuthDtos
{
    /// <summary>
    /// Used when the Itineros want to be disconnected in order to revoke the RefreshToken
    /// </summary>
    public class LogoutDto
    {
        [Required]
        public string RefreshToken { get; set; } = string.Empty;
    }
}
